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

    void Awake()
    {
        //input System
        input = new _Input();

        input.Player.Pistol.performed += ctx => StartCoroutine(ChangeWeapon(0));
        input.Player.Shotgun.performed += ctx => StartCoroutine(ChangeWeapon(1));
        input.Player.AssultRifle.performed += ctx => StartCoroutine(ChangeWeapon(2));
    }

    IEnumerator ChangeWeapon(int weapon)
    {
        if(CurrentWeapon != weapon)
        {
            CurrentWeapon = weapon;
            anim.SetBool("hide", true);
            yield return new WaitForSeconds(0.15f);
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
