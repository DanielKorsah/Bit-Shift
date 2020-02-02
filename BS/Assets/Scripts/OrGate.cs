using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrGate : Node
{

    private void Start()
    {
        base.ShowConnections();
    }

    private void Update()
    {
        base.ShowConnections();
    }

    public override bool? GetOutput()
    {

        //error checking
        if (inputs[0].GetOutput() == null || inputs[1].GetOutput() == null)
        {
            Debug.LogError("Null node input");
        }

        if (inputs[0].GetOutput() == true || inputs[1].GetOutput() == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}