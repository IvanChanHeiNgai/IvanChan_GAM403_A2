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
        //if a single enemy get's hit then all enemy in a squad will go into a attack mode
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
        //if player enters a trigger volume then all enemy goes into an attack mode
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
