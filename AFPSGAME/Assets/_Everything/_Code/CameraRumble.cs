using System;
using UnityEngine;

public class CameraRumble : MonoBehaviour
{
    //Its not really rumble more like sway

    static Vector3 Rumble(double time, RumbleInfo outer, RumbleInfo inner)
    {
        //MATH!!!
        const double twoPI = Mathf.PI * 2.0;
        double x, y;

        //allow the camera to sway in a sort of circlular motion
        //x = cos(((sin((inner.phase + time) * (pi * 2) * inner.frequency) * inner amplitude.x) + (outer.phase + time)) * (pi * 2) * outer.frequency) * outer.amplitude.x
        //with this we can by each frame, calucalate the x position on a circular path
        x = Math.Sin((inner.phase + time) * twoPI * inner.frequency) * inner.amplitude.x;
        x = Math.Cos((x + (outer.phase + time)) * twoPI * outer.frequency) * outer.amplitude.x;

        y = Math.Cos((inner.phase + time) * twoPI * inner.frequency) * inner.amplitude.y;
        y = Math.Sin((y + (outer.phase + time)) * twoPI * outer.frequency) * outer.amplitude.y;

        return new Vector3((float)x, (float)y, 0f);
    }

    [Serializable]
    public struct RumbleInfo
    {
        public float phase;
        public float frequency;
        public Vector2 amplitude;
    }

    public RumbleInfo outerDisplacement = new RumbleInfo
    {
        phase = 0f,
        frequency = 0.1f,
        amplitude = new Vector2(0.3f, 0.3f)
    };
    public RumbleInfo innerDisplacement = new RumbleInfo
    {
        phase = 0.3f,
        frequency = 0.01f,
        amplitude = new Vector2(0.01f, 0.01f)
    };

    public RumbleInfo outerRotation = new RumbleInfo
    {
        phase = 0.5f,
        frequency = 0.01f,
        amplitude = new Vector2(0.01f, 0.01f)
    };
    public RumbleInfo innerRotation = new RumbleInfo
    {
        phase = 0.5f,
        frequency = 0.1f,
        amplitude = new Vector2(0.001f, 0.001f)
    };

    double _time;

    protected void OnValidate()
    {
        _time = 0;
    }

    protected void OnEnable()
    {
        _time = 0;
    }

    void LateUpdate()
    {
        _time += Time.deltaTime;

        //Grab position Rumber();
        var position = Rumble(_time, outerDisplacement, innerDisplacement);
        //Get the rotation with LookRotation() & rumber()
        var rotation = Quaternion.LookRotation(Vector3.forward + Rumble(_time, outerRotation, innerRotation));

        transform.localPosition = position;
        transform.localRotation = rotation;
    }
}

