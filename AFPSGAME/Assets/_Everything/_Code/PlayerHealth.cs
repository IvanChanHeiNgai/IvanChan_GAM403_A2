using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 100;
    public int MaxHealth = 100;
    public Image BloodFace;
    public MouseLook ML;
    float ntth;

    // Update is called once per frame
    void Update()
    {
        BloodFace.color = new Color(1, 0, 0, (1 - ((float)Health/(float)MaxHealth))/2);
        if (Health < MaxHealth && ntth <= Time.time)
        {
            ntth = Time.time + 0.125f;
            Health++;
        }
    }

    public void TakeDamage(int dmg)
    {
        if(dmg > 0)
        {
            ntth = Time.time + 5f;
            Health -= dmg;
            ML.Recoil(45, 2.5f);
        }
    }
}
