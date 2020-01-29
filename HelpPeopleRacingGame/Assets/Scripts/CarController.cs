using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public UIManager uim;
    public List<WheelCollider> throttleWheels;
    public List<GameObject> steeringWheels;
    public List<GameObject> meshes;
    public float strengthCoefficient = 20000f;
    public float maxTurn = 20f;
    public float brakeStrength;
    public Transform centerOfMass;

    private InputManager im;
    private Rigidbody rb;

    private int gear = 1;
    int[] maxSpeedsPerGear =
    {
        30, 60, 80, 100, 130
    };

    int[] minSpeedsPerGear =
    {
        -10000, 30, 60, 80, 100
    };

    public float currentRPM;
    public float maxRPM = 7000;
    private float actualSpeed;
    private float speed;

    void Start()
    {
        im = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();

        if (centerOfMass)
        {
            rb.centerOfMass = centerOfMass.localPosition;
        }
    }

    void Update()
    {
        uim.ChangeText(transform.InverseTransformVector(rb.velocity).z);
    }

    void FixedUpdate()
    {
        //Debug.Log("Gear: " + gear + ", New Speed: " + speed + " , CurrentRPM: " + currentRPM);
        if (im.throttle > 0)
        {
            if (currentRPM < maxRPM)
            {
                currentRPM += 65 * im.throttle / gear;
            }
        }
        else if (im.throttle < 0)
        {
            if (currentRPM > 0)
            {
                currentRPM += 65 * im.throttle / gear;
            }
        }
            

        speed = (currentRPM / maxRPM) * maxSpeedsPerGear[gear - 1];
        actualSpeed = (transform.InverseTransformVector(rb.velocity).z) * 3.6f;

        if (actualSpeed > maxSpeedsPerGear[gear - 1])
        {
            if (gear < maxSpeedsPerGear.Length)
            {
                gear++;
                currentRPM = Mathf.Min(maxRPM, maxRPM * speed / maxSpeedsPerGear[gear - 1]);
            }
        }
        else if (actualSpeed <= minSpeedsPerGear[gear - 1])
        {
            gear--;
            currentRPM = Mathf.Min(maxRPM, maxRPM * speed / maxSpeedsPerGear[gear - 1]);
        }

        foreach(WheelCollider wheel in throttleWheels)
        {
            if (im.brake)
            {
                //Debug.Log("Braking");
                wheel.motorTorque = 0f;
                wheel.brakeTorque = brakeStrength * Time.deltaTime;
            }
            else
            {
                //Debug.Log("Not Braking");
                wheel.motorTorque = currentRPM * strengthCoefficient * Time.deltaTime * im.throttle;
                wheel.brakeTorque = 0;
            }
        }

        foreach (GameObject wheel in steeringWheels)
        {
            wheel.GetComponent<WheelCollider>().steerAngle = maxTurn * im.steer;
            wheel.transform.localEulerAngles = new Vector3(0f, im.steer * maxTurn, 0f);
        }

        foreach (GameObject mesh in meshes)
        {
            mesh.transform.Rotate(rb.velocity.magnitude * (transform.InverseTransformDirection(rb.velocity).z >= 0 ? 1 : -1) / (2 * Mathf.PI * 0.317f), 0f, 0f);
        }
    }
}
