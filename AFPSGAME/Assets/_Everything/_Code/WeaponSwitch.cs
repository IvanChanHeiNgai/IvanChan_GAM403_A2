using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    //Input Systen Setup
    _Input input;
    public GameObject[] Weapons;
    public int CurrentWeapon;

    public Animator anim;

    public GameObject[] WeaponIcons;

    int csw;

    void Awake()
    {
        //input System
        input = new _Input();

        input.Player.Pistol.performed += ctx => StartCoroutine(ChangeWeapon(0));
        input.Player.Shotgun.performed += ctx => StartCoroutine(ChangeWeapon(1));
        input.Player.AssultRifle.performed += ctx => StartCoroutine(ChangeWeapon(2));
        input.Player.NextWeapon.performed += ctx => StartCoroutine(ChangeWeapon(CurrentWeapon - ((int)ctx.ReadValue<float>()) / 120));
        input.Player.NextWeapon.canceled += ctx => csw = 0;
    }

    IEnumerator ChangeWeapon(int weapon)
    {
        //if the selected weapon and curretn weapon is not the same change weapon
        if(CurrentWeapon != weapon)
        {
            if (weapon > 2)
                weapon = 0;
            else if (weapon < 0)
                weapon = 2;
            CurrentWeapon = weapon;
            //play weapon switch animations
            anim.SetBool("hide", true);
            yield return new WaitForSeconds(0.15f);
            //disable current weapon and enable next weapon
            for (int i = 0; i < Weapons.Length; i++)
            {
                if (i == CurrentWeapon)
                {
                    Weapons[i].SetActive(true);
                    WeaponIcons[i].SetActive(true);
                }
                else
                {
                    Weapons[i].SetActive(false);
                    WeaponIcons[i].SetActive(false);
                }
            }
            anim.SetBool("hide", false);
        }
    }

    //Enable and disable Input System
    void OnEnable()
    {
        input.Player.Enable();
    }

    void OnDisable()
    {
        input.Player.Disable();
    }
}
