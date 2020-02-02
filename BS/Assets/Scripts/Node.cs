using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    [SerializeField]
    protected List<Node> inputs;



    //nullable bool. retun null be default if ther is a problem
    public virtual bool? GetOutput()
    {
        Debug.LogWarning("Default Node");
        return null;
    }

    public virtual void ShowConnections()
    {
        List<LineRenderer> lines = new List<LineRenderer>();
        for(int i = 0; i < inputs.Count; i++)
        {
            LineRenderer lr = gameObject.AddComponent<LineRenderer>();
            lr.startWidth = 0.1f; ;
            lr.endWidth = 0.1f;
            
            if(inputs[i] == false)
            {
                lr.startColor = Color.red;
                lr.endColor = Color.red;
            }
            else if (inputs[i] == true)
            {
                lr.startColor = Color.green;
                lr.endColor = Color.green;
            }
            else
            {
                lr.startColor = Color.blue;
                lr.endColor = Color.blue;
            }

            lines.Add(lr);
            lines[0].SetPositions(new Vector3[] { transform.position, inputs[0].transform.position });
        }
        
    }

}