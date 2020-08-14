using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grenadeThrow : MonoBehaviour
{
    //Input Systen Setup
    _Input input;
    bool gre;
    public int AmountOfGrenades = 3;
    public Animator anim;
    public GameObject GrenadeAnim;
    public GameObject GrenadeSpawn;
    public Rigidbody Grenade;
    float nttt;
    public Text Amount;

    void Awake()
    {
        //input System
        input = new _Input();

        input.Player.Grenade.performed += ctx => gre = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if player hits the grenade key and there are grenades left to throw, throw the grenades
        if(gre && AmountOfGrenades > 0)
        {
            gre = false;
            if(nttt <= Time.time)
            {
                //set a delay before throwing another
                nttt = Time.time + 1f;
                StartCoroutine(throwing());
            }
        }
        
        //display the amount of grreandes
        Amount.text = AmountOfGrenades.ToString();

        //change text color when there is no grenades left
        if (AmountOfGrenades > 0)
            Amount.color = Color.white;
        else
            Amount.color = Color.red;
    }

    IEnumerator throwing()
    {
        //hide weapons aniamtion
        anim.SetBool("hide", true);
        yield return new WaitForSeconds(0.25f);
        //play grenade throwing aniamtions
        GrenadeAnim.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        //spawn grenade
        Rigidbody g = (Rigidbody)Instantiate(Grenade, GrenadeSpawn.transform.position, GrenadeSpawn.transform.rotation);
        g.velocity = GrenadeSpawn.transform.TransformDirection(Vector3.forward * 12.5f);
        //decrease grenade amount
        AmountOfGrenades--;
        yield return new WaitForSeconds(0.15f);
        GrenadeAnim.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        anim.SetBool("hide", false);
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
