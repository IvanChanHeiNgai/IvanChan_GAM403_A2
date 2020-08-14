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

        //do a 50/50 chance that the enmy takes cover or aggresively attack the player when the player enters the arena
        if (Random.Range(0, 101) > 50)
            hide = true;
        else
            hide = false;

        //get all the colliders in the ragdol then aet the rigidbody to kinematic so the ragdol does not effect the character's animations
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
            //if enemy reach it's destination set walking aniamtions off and rotate the enemy to face the player
            if (Vector3.Distance(transform.position, AI.destination) <= 1.25f)
            {
                anim.SetBool("Walk", false);
                float angle = Mathf.Atan2(transform.position.z - Player.transform.position.z, transform.position.x - Player.transform.position.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, -angle - 77.5f, 0);

                //if player choose not to take cover,
                if (!hide)
                {
                    //we shoot a linecast from the enemy to the player to check if there is a direct line of sights, if not we reposition the enemy
                    if (Physics.Linecast(Point.transform.position, Player.transform.position, LM) && nttm <= Time.time)
                    {
                        //this block of code does a continues loop until they find a position on the navmesh that has a direct line of sights to the player
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
                        //aet the next time to reposition to take cover
                        hide = true;
                    }
                    else
                    {
                        //if there is a direct line of sight, shoot player
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
                        //if player choose to take cover, we shoot a linecast from the enemy to the player to check if there is a direct line of sights, if so we reposition the enemy
                        if (!Physics.Linecast(Point.transform.position, Player.transform.position, LM))
                        {
                            //this block of code does a continues loop until they find a position on the navmesh that has no direct line of sights to the player
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
                        ///else shoot
                        if (ntts <= Time.time && !Physics.Linecast(Point.transform.position + new Vector3(0, 1, 0), Player.transform.position, LM))
                        {
                            StartCoroutine(shoot());
                        }
                    }
                }
            }
            else
            {
                //if enemy have not reach their destination, play walking aniamtions
                anim.SetBool("Walk", true);
            }
        }
        //we health is less then 1, they DIE!!!!!!!!!!
        if (Health <= 0)
        {
            Died();
        }
        //if enemy is hurt spawn a blood decal on the floor
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
        //play shoot sound
        AS.PlayOneShot(AC);
        //set a delay before next shot
        ntts = Time.time + 0.2f;
        MuzzleFlash.SetActive(true);
        //spawn a bullet that travels forward (with a some spread)
        Rigidbody bullet = (Rigidbody)Instantiate(b, MuzzleFlash.transform.position + new Vector3(0, 0, 0), Quaternion.Euler(MuzzleFlash.transform.rotation.x, MuzzleFlash.transform.rotation.y, MuzzleFlash.transform.rotation.z));
        bullet.velocity = MuzzleFlash.transform.TransformDirection(-Vector3.right * 100f + Vector3.forward * Random.Range(-5, 5) + Vector3.up * Random.Range(-5, 5));
        Destroy(bullet, 3f);
        yield return new WaitForSeconds(0.1f);
        MuzzleFlash.SetActive(false);
    }

    void Died()
    {
        //disable the navmesh agent and animations
        AI.enabled = false;
        this.gameObject.GetComponent<Animator>().enabled = false;
        //set all the rigidbody's kinematic back to false to enable a ragdol effect
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
