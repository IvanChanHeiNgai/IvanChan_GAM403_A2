using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssultRifle : MonoBehaviour
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

    [Header("Audio")]
    public AudioSource AS;
    public AudioClip shoot;
    public AudioClip Reload;

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
    public GameObject blood;
    public GameObject BloodDecal;

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
        //input System
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
        //display amount of ammo for the ui
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


        //make sure you don't go above the max ammo amount
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }

        //if player press the shoot key,
        if (fire1)
        {
            //and if thegun is allowed to shoot this frame, current ammo is not 0, not reloading and also not spriting, fire weapon
            if (nttf < Time.time && currentAmmo > 0 && !isReloading && !sprit)
            {
                //set a delay before able to fire again
                nttf = Time.time + (1 / fireRate);
                //jump to a coroutine to fire a raycast out
                StartCoroutine(fire());
                //jump to coroutine to animate the gun fire
                StartCoroutine(animateFire());
                //if player is aimming down sights, apply the right amount of recoil to the camera
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

        //if player is walking or idle, animate the crosshair properly
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

        //if player pressed the ads key and is not reloading AND is not spritng, let the player Aim Down Sights
        if (firesec && !isReloading && !sprit)
        {
            //animate the crosshair to ads
            anim.SetBool("ADS", true);
            //animate the gun to ads
            AnimUI.SetBool("Ads", true);
            //disable the weapon sway and camera rumble script script and reset the transform of the weapon
            WS.enabled = false;
            CR.enabled = false;
            CR.transform.localPosition = Vector3.zero;
            CR.transform.localRotation = Quaternion.Euler(Vector3.zero);
            WS.transform.localPosition = Vector3.zero;
            ads = true;
            //change the fov of camera to zoom in
            MainCamera.fieldOfView = 35.98339f;
        }
        else
        {
            anim.SetBool("ADS", false);
            AnimUI.SetBool("Ads", false);
            //renable the weapon sway and camera rumble script 
            WS.enabled = true;
            CR.enabled = true;
            ads = false;
            //reset the camera fov
            MainCamera.fieldOfView = 58.71551f;
        }

        //if weapon is not reloading and the ammo is empty AND we have some reserved ammo left AND we no spriting, reload
        if (!isReloading && currentAmmo <= 0 && ReservedAmmo != 0 && !sprit)
        {
            //jump to a coroutine to reload
            StartCoroutine(reload());
        }
        //if the player hit the reload button and current ammo is not equal to the max ammo AND we are not reloading AND we have some reserved ammo ANDDDDDD we are not spriting, then reload
        if (reloadpress && currentAmmo != maxAmmo && !isReloading && ReservedAmmo != 0 && !sprit)
        {
            reloadpress = false;
            StartCoroutine(reload());
        }
        else
        {
            reloadpress = false;
        }
    }

    IEnumerator fire()
    {
        RaycastHit hit;
        /*
        set the random spread for the bullets

        if player is ads, we will use the ads bullet spread variable

        if player is just standing or crouching, we will use the idle bullet spread variable

        if player is walking, we will use the walking bullet spread variable
        */
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

        //after that we randomize the min and max value to get a vertical and horizontal position of the bullet
        var vertical = Random.Range(mV, MV);
        var horizontal = Random.Range(mH, MH);
        //shoot recast and apply the bullet spread
        if (Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward + (MainCamera.transform.right * vertical) + (MainCamera.transform.up * horizontal), out hit, range))
        {
            //if there is no rigidbody we will Instantiate a bullet decal onto the surface
            if (hit.rigidbody == null)
            {
                GameObject hole = Instantiate(BulletHole, hit.point, Quaternion.LookRotation(hit.normal));
            }
            //if we hit and enemy, do damage
            if((hit.collider.CompareTag("Enemy")))
            {
                //get the enemy script from the parent of the collider
                Enemy E_HP = hit.collider.GetComponentInParent<Enemy>();
                if (E_HP != null)
                {
                    //spawn blood particles on the enemy and blood decals on them
                    GameObject b = Instantiate(blood, hit.point, blood.transform.rotation);
                    Destroy(b, 2f);
                    Instantiate(BloodDecal, hit.point, Quaternion.Euler(270, 0, 90), hit.collider.gameObject.transform);
                    //if the collider we hit is the head do MORE DAMAGE!!!!!!!!!!
                    if (hit.collider.name == "mixamorig:Head")
                    {
                        E_HP.Health -= damage * 2;
                    }
                    else
                    {
                        E_HP.Health -= damage;
                    }
                }
            }
            else
            {
                //if we didnt hit an enemy just spawn some smoke particles
                GameObject impactGO = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f);
            }
            yield return new WaitForSeconds(0.1f);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitforce);
            }
        }
    }

    IEnumerator animateFire()
    {
        //decrease ammo
        currentAmmo--;
        //play sfx
        AS.PlayOneShot(shoot);
        //animate gun to shoot and enable muzzle flash
        anim.SetBool("Fire", true);
        MuzzleFlash.SetActive(true);
        //apply camera shake
        StartCoroutine(CS.Shake(0.0625f, 0.25f));
        yield return new WaitForSeconds(0.166f);
        //Spawn bullet caseing
        Rigidbody bu = (Rigidbody)Instantiate(Bullets, BulletOutput.transform.position, BulletOutput.transform.rotation);
        bu.velocity = BulletOutput.transform.TransformDirection(-Vector3.forward * Random.Range(0.5f, 1f));
        Destroy(bu, 4f);
        //disable muzzle falsh
        MuzzleFlash.SetActive(false);
        anim.SetBool("Fire", false);
    }

    IEnumerator reload()
    {
        firesec = false;
        isReloading = true;
        //play reload sfx and animations
        AS.PlayOneShot(Reload);
        anim.SetBool("Reload", true);
        yield return new WaitForSeconds(reloadTime / 2f);
        //set current ammo to max ammo
        currentAmmo = maxAmmo;
        //deccrease reserved ammo
        ReservedAmmo -= maxAmmo;
        yield return new WaitForSeconds(reloadTime / 2f);
        anim.SetBool("Reload", false);
        isReloading = false;
    }

    void OnDisable()
    {
        input.Player.Disable();
    }
}
