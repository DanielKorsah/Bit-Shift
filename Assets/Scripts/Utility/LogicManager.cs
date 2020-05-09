using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{

    public static bool?[] InputByteData = new bool?[8];
    public static bool?[] OutputByteData = new bool?[8];
    public bool[] TargetByteData = new bool[8];

    public List<InputNode> InputNodes;
    public List<OutputNode> OutputNodes;
    public List<TargetBit> TargetNodes;

    private GameObject inputContainer;
    private GameObject outputContainer;
    private GameObject targetContainer;

    // Start is called before the first frame update
    private void Start()
    {
        //get parent objects for each byte
        inputContainer = GameObject.Find("InputByte");
        outputContainer = GameObject.Find("OutputByte");
        targetContainer = GameObject.Find("TargetByte");

        //get individual bytes in lowest-first order
        InputNodes = new List<InputNode>(inputContainer.GetComponentsInChildren<InputNode>());
        OutputNodes = new List<OutputNode>(outputContainer.GetComponentsInChildren<OutputNode>());
        TargetNodes = new List<TargetBit>(targetContainer.GetComponentsInChildren<TargetBit>());

        //RefreshLogic();
        SetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (TargetBit t in TargetNodes)
        {
            t.DisplayBit();
        }
    }

    public void RefreshLogic()
    {
        //force all outputs to update
        foreach (TargetBit t in TargetNodes)
        {
            Debug.Log(t.name);
        }
    }

    private void SetTarget()
    {
        for (int i = 0; i < TargetNodes.Count; i++)
        {
            TargetNodes[i].TargetValue = TargetByteData[i];
        }
    }
}