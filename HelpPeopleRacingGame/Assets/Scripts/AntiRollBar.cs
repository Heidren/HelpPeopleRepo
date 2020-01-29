using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRollBar : MonoBehaviour
{
    public WheelCollider WheelL;
    public WheelCollider WheelR;
    private Rigidbody carRigidbody;

    public float AntiRollStrength = 5000f;

    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        WheelHit hit = new WheelHit();
        float travelL = 1.0f;
        float travelR = 1.0f;

        bool groundedL = WheelL.GetGroundHit(out hit);

        if (groundedL)
        {
            travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y
                    - WheelL.radius) / WheelL.suspensionDistance;
        }

        bool groundedR = WheelR.GetGroundHit(out hit);

        if (groundedR)
        {
            travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y
                    - WheelR.radius) / WheelR.suspensionDistance;
        }

        var antiRollForce = (travelL - travelR) * AntiRollStrength;

        if (groundedL)
            carRigidbody.AddForceAtPosition(WheelL.transform.up * -antiRollForce,
                WheelL.transform.position);
        if (groundedR)
            carRigidbody.AddForceAtPosition(WheelR.transform.up * antiRollForce,
                WheelR.transform.position);
    }
}
