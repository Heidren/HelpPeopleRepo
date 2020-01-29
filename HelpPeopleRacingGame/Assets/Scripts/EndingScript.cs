using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingScript : MonoBehaviour
{
    public AudioSource engineSource;
    public GameObject buttonPanel;
    public TextMeshProUGUI messageText;
    public GameObject messagePanel;

    public List<string> messages;
    public float timeBetweenMessages;

    private bool mustEnd = false;
    private float timeCounter = 0f;
    private int counter = 0;

    void Update()
    {
        timeCounter += Time.deltaTime;
        if (mustEnd)
        {
            engineSource.volume = 0;
            
            if (counter < messages.Count)
            {
                if (timeCounter > timeBetweenMessages)
                {
                    timeCounter = 0f;
                    messagePanel.SetActive(true);
                    messageText.text = messages[counter];
                    counter++;
                }
            }
            else
            {
                if (timeCounter > timeBetweenMessages)
                {
                    messageText.text = "";
                    buttonPanel.SetActive(true);
                }
            }
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            mustEnd = true;
        }
    }
}
