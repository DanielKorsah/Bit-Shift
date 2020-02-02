using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGate : Node
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
        if (this.inputs[0].GetOutput() == null)
            Debug.LogError("Null node input");
        return !this.inputs[0].GetOutput();
    }
}