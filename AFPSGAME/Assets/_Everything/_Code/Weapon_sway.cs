using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_sway : MonoBehaviour {

    public float amount = 0.02f;
    public float maxAmount = 0.05f;
    public float smoothAmount = 5f;

    private Vector3 initialPosition;

    private float move;
    private bool hi;

    // Use this for initialization
    void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = -Input.GetAxis("Mouse X") * amount;
        float movementY = -Input.GetAxis("Mouse Y") * amount;
        //float movementx = -Input.GetAxis("Horizontal") * amount;
        //float movementy = -Input.GetAxis("Vertical") * amount;
        movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);
        movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);
        //movementx = Mathf.Clamp(movementx, -maxAmount, maxAmount);
        //movementy = Mathf.Clamp(movementy, -maxAmount, maxAmount);

        Vector3 finalPosition = new Vector3(movementX, movementY, 0);
        //Vector3 finalposition2 = new Vector3(movementx, 0, movementy);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * smoothAmount);
        //transform.localPosition = Vector3.Lerp(transform.localPosition, finalposition2 + initialPosition, Time.deltaTime * smoothAmount);
    }
}
