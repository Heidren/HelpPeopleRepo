using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroScript : MonoBehaviour
{
    public GameObject controlScheme;
    public TextMeshProUGUI messageText;
    public List<string> messages;
    public float timeBetweenMessages;
    public string sceneName;

    private int counter = 0;
    private float timeCounter = 0f;

    void Update()
    {
        if (counter < messages.Count)
        {
            if (timeCounter > timeBetweenMessages)
            {
                timeCounter = 0f;
                messageText.text = messages[counter];
                counter++;
            }
        }
        else
        {
            if (timeCounter > timeBetweenMessages)
            {
                messageText.text = "";
                controlScheme.SetActive(true);
                if (timeCounter > timeBetweenMessages + 6)
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
        }

        timeCounter += Time.deltaTime;
    }
}
