using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad : MonoBehaviour
{
    public Enemy[] enemy;
    public BoxCollider col;
    public bool alloutattack;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if(!alloutattack)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                if(enemy[i].attack)
                {
                    attaqck();
                }
            }
        }
        else
        {
            anim.SetBool("Open", true);
            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i].Health > 0)
                {
                    anim.SetBool("Open", false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attaqck();
        }
    }

    void attaqck()
    {
        col.enabled = false;
        alloutattack = true;
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].attack = true;
        }
    }
}
