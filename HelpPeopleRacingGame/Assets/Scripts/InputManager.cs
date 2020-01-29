using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float throttle;
    public float steer;
    public bool brake;

    void Update()
    {
        throttle = -Input.GetAxis("Vertical");
        steer = Input.GetAxis("Horizontal");
        //Debug.Log("Throttle: " + throttle + ", Steer: " + steer);
        brake = Input.GetButton("Jump");
    }
}
