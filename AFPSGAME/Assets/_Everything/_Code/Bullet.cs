using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    /*
    this is a physical bullet that the enemy shoots out
    */
    public GameObject BulletHole;
    public GameObject Blood;
    public GameObject Smoke;

    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ///destroy this gameobject after 3 seconds
        Destroy(this.gameObject, 3f);
    }

    void OnCollisionEnter(Collision collision)
    {
        //get all collision contact position
        var contact = collision.contacts[0];
        if (collision.gameObject.GetComponent<Bullet>() == null)
        {
            //if wbullet hits player do damage then destroy self
            if (collision.gameObject.GetComponent<PlayerHealth>() != null)
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
                Destroy(this.gameObject);
            }
            else
            {
                //if bullet hit another enemy spawn blood particles
                if (collision.gameObject.GetComponentInParent<NavMeshAgent>() != null)
                {
                    GameObject blood = Instantiate(Blood, contact.point, Quaternion.LookRotation(contact.normal));
                    Destroy(blood, 1.9f);
                }
                else
                {
                    //if we hit an object with no rigidbody spawn a bullet hole decals 
                    if(collision.gameObject.GetComponent<Rigidbody>() == null)
                    {
                        Instantiate(BulletHole, contact.point, Quaternion.LookRotation(contact.normal));
                        Destroy(this.gameObject);
                    }
                    if(collision.collider.name != "Physics" && collision.collider.name != "Camera")
                    {
                        //spawn smoke decals
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
