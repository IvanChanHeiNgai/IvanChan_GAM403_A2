using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class Pistol : MonoBehaviour
{
    //Input Systen Setup
    _Input input;
    [Header("Base Stats")]
    public int damage = 5;
    public float range = 1000f;
    public float fireRate = 4f;
    public float hitforce = 1500f;
    [Header("Hip Fire Spread")]
    public float MinimalVerticalSpread = -5f;
    public float MaximalVerticalSpread = 5f;
    public float MinimalHorizontalSpread = -5f;
    public float MaximalHorizontalSpread = 5f;
    [Header("ADS Spread")]
    public float ADSMinimalVerticalSpread = -1f;
    public float ADSMaximalVerticalSpread = 1f;
    public float ADSMinimalHorizontalSpread = -1f;
    public float ADSMaximalHorizontalSpread = 1f;
    [Header("Walking Spread")]
    public float WalkingMinimalVerticalSpread = -1f;
    public float WalkingMaximalVerticalSpread = 1f;
    public float WalkingMinimalHorizontalSpread = -1f;
    public float WalkingMaximalHorizontalSpread = 1f;
    [Header("Hit Fire Recoil")]
    public float VerticalRecoil = 7.5f;
    public float HorizontalRecoil = 2.8125f;
    [Header("ADS Recoil")]
    public float ADSVerticalRecoil = 2.25f;
    public float ADSHorizontalRecoil = 1f;
    [Header("Ammo")]
    public int maxAmmo = 15;
    public int currentAmmo;
    public int ReservedAmmo = 150;
    public float reloadTime = 1.75f;
    [HideInInspector]
    public bool isReloading = false;
    [Header("Muzzle Flash")]
    public GameObject MuzzleFlash;
    [Header("User Interface")]
    public int LowAmmoAmount = 3;
    public Text AmmoUI;
    public Text MaxAmmoUI;
    public Animator AnimUI;
    //I am commenting this out cause i don't have any sfx yet
    //but in the future i will add it
    /*
    [Header("Audio")]
    public GameObject AS;
    public GameObject Reload;
    public GameObject HitSFX;
    */
    [Header("Others")]
    public PlayerMovement PM;
    public Weapon_sway WS;
    public CameraRumble CR;
    public GameObject HitEffect;
    public GameObject BulletHole;
    public Camera MainCamera;
    public Animator anim;
    public CameraShake CS;
    public MouseLook ML;
    public Rigidbody Bullets;
    public GameObject BulletOutput;
    /*
    public GameObject blood;
    public GameObject BloodDecal;
    */

    [Header("Hidden")]
    bool sprit;
    bool walk;
    bool shooted;
    float nttf;
    [HideInInspector]
    public bool ads;
    bool fire1;
    [HideInInspector]
    public bool firesec;
    bool reloadpress;

    void Awake()
    {
        input = new _Input();

        input.Player.Fire.performed += ctx => fire1 = true;
        input.Player.Fire.canceled += ctx => fire1 = false;
        input.Player.Secondary.performed += ctx => firesec = true;
        input.Player.Secondary.canceled += ctx => firesec = false;
        input.Player.Reload.performed += ctx => reloadpress = true;
    }

    void OnEnable()
    {
        isReloading = false;
        anim.SetBool("Reload", false);
        anim.SetBool("Fire", false);
        input.Player.Enable();
    }


    // Update is called once per frame
    void Update()
    {
        AmmoUI.text = currentAmmo.ToString();
        MaxAmmoUI.text = ReservedAmmo.ToString();
        if (currentAmmo <= LowAmmoAmount)
        {
            AmmoUI.color = Color.red;
        }
        else
        {
            AmmoUI.color = Color.white;
        }



        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }

        if (fire1)
        {
            //fire1 = false;
            if (nttf < Time.time && currentAmmo > 0 && !isReloading && !sprit)
            {
                nttf = Time.time + (1 / fireRate);
                StartCoroutine(fire());
                StartCoroutine(animateFire());
                if (ads)
                {
                    ML.Recoil(ADSVerticalRecoil, ADSHorizontalRecoil);
                }
                else
                {
                    ML.Recoil(VerticalRecoil, HorizontalRecoil);
                }
            }
        }
        if (PM.x == 0 && PM.z == 0)
        {
            walk = false;
            AnimUI.SetBool("Walking", false);
            sprit = false;
        }
        else
        {
            if (!PM.crouch)
            {
                walk = true;
                AnimUI.SetBool("Walking", true);
                if (PM.Spriting)
                {
                    sprit = true;
                }
                else
                {
                    sprit = false;
                }
            }
            else
            {
                walk = false;
                AnimUI.SetBool("Walking", false);
                sprit = false;
            }
        }
        if (firesec && !isReloading && !sprit)
        {
            anim.SetBool("ADS", true);
            AnimUI.SetBool("Ads", true);
            WS.enabled = false;
            CR.enabled = false;
            CR.transform.localPosition = Vector3.zero;
            CR.transform.localRotation = Quaternion.Euler(Vector3.zero);
            WS.transform.localPosition = Vector3.zero;
            ads = true;
            MainCamera.fieldOfView = 46.69212f;
        }
        else
        {
            anim.SetBool("ADS", false);
            AnimUI.SetBool("Ads", false);
            WS.enabled = true;
            CR.enabled = true;
            ads = false;
            MainCamera.fieldOfView = 58.71551f;
        }

        if (!isReloading && currentAmmo <= 0 && ReservedAmmo != 0 && !sprit)
        {
            StartCoroutine(reload());
        }
        if (reloadpress && currentAmmo != maxAmmo && !isReloading && ReservedAmmo != 0 && !sprit)
        {
            reloadpress = false;
            StartCoroutine(reload());
        }
    }

    IEnumerator fire()
    {
        RaycastHit hit;
        var mV = 0f;
        var MV = 0f;
        var mH = 0f;
        var MH = 0f;
        if (ads)
        {
            mV = ADSMinimalVerticalSpread / 100;
            MV = ADSMaximalVerticalSpread / 100;
            mH = ADSMinimalHorizontalSpread / 100;
            MH = ADSMaximalHorizontalSpread / 100;
        }
        else
        {
            if (!walk)
            {
                mV = MinimalVerticalSpread / 100;
                MV = MaximalVerticalSpread / 100;
                mH = MinimalHorizontalSpread / 100;
                MH = MaximalHorizontalSpread / 100;
            }
            else
            {
                mV = WalkingMinimalVerticalSpread / 100;
                MV = WalkingMaximalVerticalSpread / 100;
                mH = WalkingMinimalHorizontalSpread / 100;
                MH = WalkingMaximalHorizontalSpread / 100;
            }
        }
        var vertical = Random.Range(mV, MV);
        var horizontal = Random.Range(mH, MH);
        if (Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward + (MainCamera.transform.right * vertical) + (MainCamera.transform.up * horizontal), out hit, range))
        {
            if (hit.rigidbody == null)
            {
                GameObject hole = Instantiate(BulletHole, hit.point, Quaternion.LookRotation(hit.normal));
            }
            GameObject impactGO = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
            yield return new WaitForSeconds(0.1f);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitforce);
            }
        }
    }

    IEnumerator animateFire()
    {
        //GameObject fire = Instantiate(AS, MuzzleFlash.transform.position, AS.transform.rotation);
        //Destroy(fire, 1.6275f);
        anim.SetBool("Fire", true);
        MuzzleFlash.SetActive(true);
        StartCoroutine(CS.Shake(0.25f, 1f));
        yield return new WaitForSeconds(0.125f);
        Rigidbody bu = (Rigidbody)Instantiate(Bullets, BulletOutput.transform.position, BulletOutput.transform.rotation);
        bu.velocity = BulletOutput.transform.TransformDirection(Vector3.forward * Random.Range(0.3125f, 0.375f));
        Destroy(bu, 4f);
        MuzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.125f);
        anim.SetBool("Fire", false);
        int c = 0;
        currentAmmo--;
    }

    IEnumerator reload()
    {
        if(ReservedAmmo >= maxAmmo)
        {
            firesec = false;
            isReloading = true;
            //var r = Instantiate(Reload, this.gameObject.transform);
            //Destroy(r, 3f);
            anim.SetBool("Reload", true);
            yield return new WaitForSeconds(reloadTime / 2f);
            currentAmmo = maxAmmo;
            ReservedAmmo -= maxAmmo;
            yield return new WaitForSeconds(reloadTime / 2f);
            anim.SetBool("Reload", false);
            isReloading = false;
        }
    }

    void OnDisable()
    {
        input.Player.Disable();
    }
}