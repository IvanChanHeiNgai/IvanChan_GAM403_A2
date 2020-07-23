using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //Apply camera shake when called from another script
    //Why i don't use CineMachine for this?
    //I have no idea, I just like it this way.
    public IEnumerator Shake(float DURATION, float MAGNITUDE)
    {
        float elapsed = 0;
        //shake it for a set duration
        while(elapsed < DURATION)
        {
            //set camera to shake in a random value mutiple by the set magnitude
            float x = Random.Range(-1f, 1f) * MAGNITUDE;
            float y = Random.Range(-1f, 1f) * MAGNITUDE;

            //set the transform to the generated number
            transform.localPosition = new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }
        //After all the shaking, set it back!!!
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
