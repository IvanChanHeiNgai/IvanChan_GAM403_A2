using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    public GameObject BulletHole;
    public GameObject Blood;
    public GameObject Smoke;

    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 3f);
    }

    void OnCollisionEnter(Collision collision)
    {
        var contact = collision.contacts[0];
        if (collision.gameObject.GetComponent<Bullet>() == null)
        {
            if (collision.gameObject.GetComponent<PlayerHealth>() != null)
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
                Destroy(this.gameObject);
            }
            else
            {
                if (collision.gameObject.GetComponentInParent<NavMeshAgent>() != null)
                {
                    GameObject blood = Instantiate(Blood, contact.point, Quaternion.LookRotation(contact.normal));
                    Destroy(blood, 1.9f);
                }
                else
                {
                    if(collision.gameObject.GetComponent<Rigidbody>() == null)
                    {
                        Instantiate(BulletHole, contact.point, Quaternion.LookRotation(contact.normal));
                        Destroy(this.gameObject);
                    }
                    if(collision.collider.name != "Physics" && collision.collider.name != "Camera")
                    {
                        GameObject smoke = Instantiate(Smoke, contact.point, Quaternion.LookRotation(contact.normal));
                        Destroy(smoke, 1.9f);
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(1);
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}
