using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    [SerializeField]
    protected List<Node> inputs;

    [SerializeField]
    protected List<LineRenderer> lines = new List<LineRenderer>();

    //nullable bool. retun null be default if ther is a problem
    public virtual bool? GetOutput()
    {
        Debug.LogWarning("Default Node");
        return null;
    }

    public virtual void AddConnections()
    {
        if (inputs.Count != 0)
        {
            for (int i = 0; i < inputs.Count; i++)
            {

                LineRenderer[] lr = transform.GetChild(0).GetComponents<LineRenderer>();
                lr.startWidth = 0.1f;;
                lr.endWidth = 0.1f;

                if (inputs[i] == false)
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

    public virtual void UpdateConnections()
    {
        if (inputs.Count != 0)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                if (inputs[i] == false)
                {
                    lines[i].startColor = Color.red;
                    lines[i].endColor = Color.red;
                }
                else if (inputs[i] == true)
                {
                    lines[i].startColor = Color.green;
                    lines[i].endColor = Color.green;
                }
                else
                {
                    lines[i].startColor = Color.blue;
                    lines[i].endColor = Color.blue;
                }
                lines[0].SetPositions(new Vector3[] { transform.position, inputs[0].transform.position });
            }
        }

    }

}