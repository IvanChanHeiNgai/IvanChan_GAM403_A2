using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Slowmo : MonoBehaviour
{
    //Input Systen Setup
    _Input input;

    public float TimeSlowAmount = 0.25f;
    public Volume PP;
    bool sm;

    void Awake()
    {
        //input System
        input = new _Input();

        input.Player.SlowMo.performed += ctx => SM();
    }

    void SM()
    {
        sm = !sm;
        if (sm)
        {
            Time.timeScale = TimeSlowAmount;
            StartCoroutine(activate());
        }
        else
        {
            Time.timeScale = 1f;
            StartCoroutine(deactivate());
        }
    }

    IEnumerator activate()
    {
        while(PP.weight < 1)
        {
            yield return new WaitForSeconds(0.01f);
            PP.weight += 0.2f;
        }
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
