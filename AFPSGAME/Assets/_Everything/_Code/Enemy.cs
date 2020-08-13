using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public int Health = 100;
    int MaxHealth;
    public Animator anim;
    public GameObject BloodDecal;
    public GameObject Point;
    public LayerMask LM;
    public List<Collider> Rag_c = new List<Collider>();
    public NavMeshAgent AI;
    public GameObject Player;

    public GameObject MuzzleFlash;
    public Rigidbody b;
    float ntts;
    float nttm;
    bool hide;
    [HideInInspector]
    public bool attack;
    public AudioSource AS;
    public AudioClip AC;
    /*
     i KNOW THIS IS NOT A  VERY SMART AI!!!
    */

    void Awake()
    {
        MaxHealth = Health;
        if (Random.Range(0, 101) > 50)
            hide = true;
        else
            hide = false;

        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();

        foreach (Collider c in colliders)
        {
            if (c.gameObject.GetComponent<Rigidbody>() != null)
            {
                c.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                Rag_c.Add(c);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(attack)
        {
            if (Vector3.Distance(transform.position, AI.destination) <= 1.25f)
            {
                anim.SetBool("Walk", false);
                float angle = Mathf.Atan2(transform.position.z - Player.transform.position.z, transform.position.x - Player.transform.position.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, -angle - 77.5f, 0);

                if (!hide)
                {
                    if (Physics.Linecast(Point.transform.position, Player.transform.position, LM) && nttm <= Time.time)
                    {
                        Vector3 finalPosition = transform.position;
                        var t = 0;
                        while (true)
                        {
                            t++;
                            float ran = Random.Range(5f, 50f);
                            Vector3 randomDirection = Random.insideUnitSphere * ran;
                            randomDirection += this.transform.position;
                            NavMeshHit hit;
                            NavMesh.SamplePosition(randomDirection, out hit, ran, NavMesh.AllAreas);
                            finalPosition = hit.position;
                            if (!Physics.Linecast(finalPosition, Player.transform.position) || t >= 666)
                                break;
                        }
                        nttm = Time.time + 10f;
                        AI.SetDestination(finalPosition);
                        hide = true;
                    }
                    else
                    {
                        if (ntts <= Time.time && !Physics.Linecast(Point.transform.position + new Vector3(0, 1, 0), Player.transform.position, LM))
                        {
                            StartCoroutine(shoot());
                        }
                    }
                }
                else
                {
                    if (nttm <= Time.time)
                    {
                        if (!Physics.Linecast(Point.transform.position, Player.transform.position, LM))
                        {
                            Vector3 finalPosition = transform.position;
                            var t = 0;
                            while (true)
                            {
                                t++;
                                float ran = Random.Range(5f, 50f);
                                Vector3 randomDirection = Random.insideUnitSphere * ran;
                                randomDirection += this.transform.position;
                                NavMeshHit hit;
                                NavMesh.SamplePosition(randomDirection, out hit, ran, NavMesh.AllAreas);
                                finalPosition = hit.position;
                                if (Physics.Linecast(finalPosition, Player.transform.position) || t >= 666)
                                    break;
                            }
                            nttm = Time.time + 10f;
                            AI.SetDestination(finalPosition);
                            hide = false;
                        }
                    }
                    else
                    {
                        if (ntts <= Time.time && !Physics.Linecast(Point.transform.position + new Vector3(0, 1, 0), Player.transform.position, LM))
                        {
                            StartCoroutine(shoot());
                        }
                    }
                }
            }
            else
            {
                anim.SetBool("Walk", true);
            }
        }
        if (Health <= 0)
        {
            Died();
        }
        if(Health < MaxHealth)
        {
            attack = true;
            MaxHealth = Health;
            RaycastHit hit;
            if (Physics.Raycast(Point.transform.position, Vector3.down, out hit, 2.5f, LM))
            {
                Instantiate(BloodDecal, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }

    IEnumerator shoot()
    {
        AS.PlayOneShot(AC);
        ntts = Time.time + 0.2f;
        MuzzleFlash.SetActive(true);
        Rigidbody bullet = (Rigidbody)Instantiate(b, MuzzleFlash.transform.position + new Vector3(0, 0, 0), Quaternion.Euler(MuzzleFlash.transform.rotation.x, MuzzleFlash.transform.rotation.y, MuzzleFlash.transform.rotation.z));
        bullet.velocity = MuzzleFlash.transform.TransformDirection(-Vector3.right * 100f + Vector3.forward * Random.Range(-5, 5) + Vector3.up * Random.Range(-5, 5));
        Destroy(bullet, 3f);
        yield return new WaitForSeconds(0.1f);
        MuzzleFlash.SetActive(false);
    }

    void Died()
    {
        AI.enabled = false;
        this.gameObject.GetComponent<Animator>().enabled = false;
        foreach (Collider c in Rag_c)
        {
            //c.enabled = true;
            if (c.gameObject.GetComponent<Rigidbody>() != null)
            {
                c.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
