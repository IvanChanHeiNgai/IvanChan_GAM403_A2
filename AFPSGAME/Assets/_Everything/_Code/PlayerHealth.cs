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
    public Rigidbody RBC;
    public PlayerMovement PM;
    public GameObject Weapons;

    void Awake()
    {
        RBC.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Debug.Log("Died");
            PM.enabled = false;
            ML.enabled = false;
            RBC.isKinematic = false;
            Weapons.SetActive(false);
        }
        BloodFace.color = new Color(1, 0, 0, (1 - ((float)Health/(float)MaxHealth))/4);
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
            ML.Recoil(5f, 5f);
        }
    }
}
