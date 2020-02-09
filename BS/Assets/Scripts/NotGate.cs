using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGate : Node
{

    private void Start()
    {
        base.AddConnections();
    }

    private void Update()
    {
        base.UpdateConnections();
    }

    public override bool? GetOutput()
    {
        if (this.inputs[0].GetOutput() == null)
            Debug.LogWarning("Null node input");
        return !this.inputs[0].GetOutput();
    }
}