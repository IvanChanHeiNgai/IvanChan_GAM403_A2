using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    GameObject target;

    void Start()
    {
        //set the explosion position
        Vector3 explosionPos = transform.position;
        //get all the colliders inside the effected area
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            
            //if player is inside the effecteed area, do damage
            if (hit.CompareTag("Player"))
            {
                PlayerHealth P_HP = hit.GetComponent<PlayerHealth>();
                if (P_HP != null)
                {
                    //the closer the player is to the center of the explosion the more damage it does
                    P_HP.TakeDamage(120 - (int)(Vector3.Distance(transform.position, P_HP.transform.position) * 10));
                }
            }
            //if enemy is inside the effecteed area, do damage
            if (hit.CompareTag("Enemy"))
            {
                Enemy E_HP = hit.GetComponentInParent<Enemy>();
                if (E_HP != null)
                {
                    //the closer the enemy is to the center of the explosion the more damage it does
                    E_HP.Health -= (120 - (int)(Vector3.Distance(transform.position, E_HP.transform.position))) / 10;
                }
            }


            if (rb != null)
            {
                //add an explosion force to all rigidbodies
                rb.AddExplosionForce(power, explosionPos, radius, power);
            }
        }
    }
}
