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
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            
            if (hit.CompareTag("Player"))
            {
                target = hit.gameObject;
            }
            PlayerHealth P_HP = hit.GetComponent<PlayerHealth>();
            if (P_HP != null)
            {
                P_HP.TakeDamage(120 - (int)(Vector3.Distance(transform.position, target.transform.position) * 10));
            }
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, power);
            }
        }
    }
}
