using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    public AudioClip engineSound;

    private CarController carController;
    private AudioSource audioSource;

    void Start()
    {
        carController = GetComponent<CarController>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = engineSound;
    }

    void Update()
    {
        audioSource.pitch = (carController.currentRPM / carController.maxRPM) / 1.5f;
    }
}
