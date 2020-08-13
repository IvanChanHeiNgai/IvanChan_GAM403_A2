using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Slowmo : MonoBehaviour
{
    //Input Systen Setup
    _Input input;

    [Range(0.1f, 0.9f)]
    public float TimeSlowAmount = 0.25f;
    public int SlowDownMeter = 100;
    public Image MeterUI;
    public Volume PP;
    bool sm;
    float nttsm;
    float nttRC;

    void Awake()
    {
        //input System
        input = new _Input();

        input.Player.SlowMo.performed += ctx => SM();
    }

    void Update()
    {
        MeterUI.fillAmount = (float)SlowDownMeter / 100;
        if(sm && nttsm <= Time.time && SlowDownMeter > 0)
        {
            nttsm = Time.time + 0.025f;
            SlowDownMeter--;
        }
        if(SlowDownMeter <= 0 && sm)
        {
            SM();
        }
        if(!sm && nttRC <= Time.time && SlowDownMeter < 100)
        {
            nttRC = Time.time + 0.1f;
            SlowDownMeter++;
        }
    }

    void SM()
    {
        sm = !sm;
        if (sm)
        {
            if(SlowDownMeter > 0)
            {
                Time.timeScale = TimeSlowAmount;
                StartCoroutine(activate());
            }
            else
            {
                sm = false;
            }
        }
        else
        {
            Time.timeScale = 1f;
            StartCoroutine(deactivate());
            nttRC = Time.time + 5f;
        }
    }

    IEnumerator activate()
    {
        while(PP.weight < 1)
        {
            yield return new WaitForSeconds(0.01f);
            PP.weight += 0.2f;
        }
        nttsm = Time.time + 0.1f;
    }

    IEnumerator deactivate()
    {
        while (PP.weight > 0)
        {
            yield return new WaitForSeconds(0.01f);
            PP.weight -= 0.2f;
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
