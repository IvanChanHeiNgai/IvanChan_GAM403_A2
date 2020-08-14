using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float ExplodeTime;
    public GameObject explosion;
    float ntte;

    void Start()
    {
        //explode after a small amount of time
        ntte = Time.time + ExplodeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(ntte <= Time.time)
        {
            ntte = Time.time + 2;
            var CS = GameObject.FindGameObjectWithTag("CS");
            //spawn explosion particles
            var e = Instantiate(explosion, transform.position, explosion.transform.rotation);
            //apply camera shake
            StartCoroutine(CS.GetComponent<CameraShake>().Shake(0.75f, 1.25f));
            Destroy(e, 1f);
            Destroy(this.gameObject, 1.5f);
        }
    }
}
