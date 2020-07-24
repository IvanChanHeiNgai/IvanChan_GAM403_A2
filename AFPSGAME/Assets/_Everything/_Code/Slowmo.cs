using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowmo : MonoBehaviour
{
    //Input Systen Setup
    _Input input;

    public float TimeSlowAmount = 0.25f;
    public GameObject PP;
    bool sm;


    void Awake()
    {
        //input System
        input = new _Input();

        input.Player.SlowMo.performed += ctx => sm = !sm;
    }

    // Update is called once per frame
    void Update()
    {
        if(sm)
        {
            Time.timeScale = TimeSlowAmount;
            PP.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            PP.SetActive(false);
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
