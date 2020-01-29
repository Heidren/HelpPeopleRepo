using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MessageManager : MonoBehaviour
{
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;
    public string sceneName;

    private bool mustEnd = false;
    private float currentTime = 0;
    private float timeToWait = 1;

    void Update()
    {
        if (mustEnd)
        {
            Debug.Log("mustEnd true");
            currentTime += Time.deltaTime;
            Debug.Log(currentTime);
            if (currentTime > timeToWait)
            {
                Debug.Log("Reloading Scene");
                messagePanel.SetActive(false);
                mustEnd = false;
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    public void SetMessageAndReset(string message, float time)
    {
        if (messageText.text == "")
        {
            messageText.text = message;
            messagePanel.SetActive(true);
            mustEnd = true;
            currentTime = 0;
            timeToWait = time;
        }
    }
}
