using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().pitch = Time.timeScale;
    }
}
