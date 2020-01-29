using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float currentTime = 0.0f;
    public float timeNeeded;
    public bool hasLost = false;

    public GameObject messagePanel;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI timerText;
    public MessageManager messageManager;

    void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("F1") + "s";
        
        if (currentTime > timeNeeded && !hasLost)
        {
            hasLost = true;
            messageManager.SetMessageAndReset("You weren't fast enough.", 4.0f);
        }
    }
}
