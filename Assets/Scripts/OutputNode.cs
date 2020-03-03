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
        OutputBit();
    }

    private void Update()
    {
        base.UpdateConnections();
        OutputBit();
    }

    public void OutputBit()
    {
        //if it has input
        if (Inputs.Count != 0)
        {
            //error check
            try
            {
                if (Inputs[0].GetOutput() == true)
                {
                    LogicManager.OutputByteData[index] = true;
                    BitTextOut.text = "1";
                }
                else
                {
                    LogicManager.OutputByteData[index] = false;
                    BitTextOut.text = "0";
                }
            }
            catch (NullReferenceException e)
            {
                BitTextOut.text = "E";
                Debug.LogError("Invalid Node Params - Check input size matches connected inputs on: " + gameObject.name);
                Debug.LogError(e);
            }

            //Debug.Log(LogicManager.OutputByteData.ToString());
        }
        //default to zero
        else
        {
            BitTextOut.text = "0";
        }

    }

}