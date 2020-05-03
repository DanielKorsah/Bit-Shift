using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{

    public static bool?[] InputByteData = new bool?[8];
    public static bool?[] OutputByteData = new bool?[8];

    public List<OutputNode> OutputNodes;

    // Start is called before the first frame update
    private void Start()
    {
        RefreshLogic();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshLogic();
    }

    public void RefreshLogic()
    {
        //force all outputs to update
        foreach (OutputNode o in OutputNodes)
        {
            Debug.Log(o.name);
            //o.OutputBit();
        }
    }
}