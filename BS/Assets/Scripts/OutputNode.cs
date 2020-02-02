using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutputNode : Node
{
    private TextMeshProUGUI BitTextOut;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = Int32.Parse(gameObject.name);
        BitTextOut = GetComponentInChildren<TextMeshProUGUI>();
        base.AddConnections();
    }

    private void Update()
    {
        base.UpdateConnections();
    }

    public void OutputBit()
    {
        if (inputs.Count != 0)
        {
            //error check
            if (inputs[0].GetOutput() == null)
            {
                Debug.LogError("Null input");
            }

            if (inputs[0].GetOutput() == true)
            {
                LogicManager.OutputByteData[index] = true;
                BitTextOut.text = "1";
            }
            else
            {
                LogicManager.OutputByteData[index] = false;
                BitTextOut.text = "0";
            }

            Debug.Log(LogicManager.OutputByteData.ToString());
        }

    }

}