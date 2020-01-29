using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void ChangeText(float speed)
    {
        float actualSpeed = speed * 3.6f;
        text.text = Mathf.Clamp(actualSpeed, 0, 1000).ToString("F1");
    }
}
