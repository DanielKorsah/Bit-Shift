using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

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
    private bool completed = false;
    private UnityEvent byteMatchEvent = new UnityEvent();

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
        byteMatchEvent.AddListener(Win);
        SetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (TargetBit t in TargetNodes)
        {
            t.DisplayBit();
        }
        CheckAnswer();
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

    private void CheckAnswer()
    {
        bool[] answerByte = new bool[8];
        for (int i = 0; i < TargetNodes.Count; i++)
        {
            //construct our output array for comparisson, cast nulls to false
            answerByte[i] = OutputByteData[i].GetValueOrDefault();
        }

        if (answerByte.SequenceEqual(TargetByteData) && !completed)
        {
            completed = true;
            byteMatchEvent.Invoke();
            SoundManager.CorrectSequence.Invoke();
        }
    }

    private void Win()
    {
        print("Winner winner chicken dinner");
    }
}