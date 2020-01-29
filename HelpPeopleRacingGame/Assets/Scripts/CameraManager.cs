using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject focusObj;
    public float distance = 5f;
    public float height = 2f;
    public float dampening = 1f;
    public float h2 = 0f;
    public float d2 = 0f;
    public float l = 0f;

    private Camera mainCam;
    private int camMode = 0;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            camMode = (camMode + 1) % 2;
        }

        switch (camMode)
        {
            case 1:
                transform.position = focusObj.transform.position + focusObj.transform.TransformDirection(new Vector3(l, h2, d2));
                transform.rotation = focusObj.transform.rotation;
                mainCam.fieldOfView = 90f;
                break;

            default:
                transform.position = Vector3.Lerp(transform.position, focusObj.transform.position + focusObj.transform.TransformDirection(new Vector3(0f, height, -distance)), dampening * Time.deltaTime);
                transform.LookAt(focusObj.transform);
                mainCam.fieldOfView = 60f;
                break;
        }
            
    }
}
