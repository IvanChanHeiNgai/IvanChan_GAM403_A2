using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Look Settings")]
    public float mouseXSensitivity = 100f;
    public float mouseYSensitivity = 100f;
    public bool invertY;
    public bool invertX;
    [Header("Player Set-Up")]
    public Transform playerBody;
    [Header("Hidden Variables")]
    [HideInInspector]
    public float xRotation = 0;
    float yRotation;
    [Header("Enable Mouse Look?")]
    public bool movecamera = true;

    // Start is called before the first frame update
    void Start()
    {
        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = 0;
        float mouseY = 0;
        if (movecamera)
        {
            //Get Camera Rotation amount with GetAxis mutiple by sensitivity and delta time
            if(Time.timeScale != 0)
            {
                mouseX = (Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime) / Time.timeScale;
                mouseY = (Input.GetAxis("Mouse Y") * mouseYSensitivity * Time.deltaTime) / Time.timeScale;
            }

            //invert Mouse if needed
            if(invertX)
            {
                mouseX = -mouseX;
            }
            if (invertY)
            {
                mouseY = -mouseY;
            }
        }

        yRotation = mouseX;
        xRotation -= mouseY;

        //Clamp vertical camera rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //rotate camera vertically
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //rotate player horizontally
        playerBody.Rotate(Vector3.up * yRotation);
    }

    public void Recoil(float VerticalValue, float HorizontalValue)
    {
        xRotation -= VerticalValue;
        playerBody.Rotate(Vector3.up * Random.Range(-HorizontalValue, HorizontalValue));
        StartCoroutine(ComeBack(VerticalValue));
    }

    IEnumerator ComeBack(float vv)
    {
        float timing = (vv * Random.Range(0.5f, 1.5f)) / 50;
        yield return new WaitForSeconds(0.075f);
        for (int i = 0; i < 50; i++)
        {
            xRotation += timing;
            yield return new WaitForSeconds(0.00125f);
        }
    }
}
