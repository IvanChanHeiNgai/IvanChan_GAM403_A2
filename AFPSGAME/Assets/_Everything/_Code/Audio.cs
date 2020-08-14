using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //audio scources with this script will chnage the pitch of the sfx dedpending on the time scale for slow-mo
        GetComponent<AudioSource>().pitch = Time.timeScale;
    }
}
