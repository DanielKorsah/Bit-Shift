using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetBit : MonoBehaviour
{

    public bool? TargetValue;

    private TextMeshProUGUI BitText;

    // Start is called before the first frame update

    void Awake()
    {
        BitText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void DisplayBit()
    {
        if (TargetValue == true)
        {
            BitText.text = "1";
        }
        else if (TargetValue == false)
        {
            BitText.text = "0";
        }
        else
        {
            BitText.text = "E";
        }
    }
}