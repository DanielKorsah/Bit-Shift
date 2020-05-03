using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class Node : MonoBehaviour
{

    [SerializeField] protected List<LineRenderer> lines = new List<LineRenderer>();

    [SerializeField] protected Material lineMaterial;

    public List<Node> Inputs;

    public Color color;

    //nullable bool. retun null be default if ther is a problem
    public virtual bool? GetOutput()
    {
        Debug.LogWarning("Default Node");
        return null;
    }

    public virtual void AddConnections()
    {
        //for nodes with inputs
        if (Inputs.Count != 0 && Inputs[0] != null)
        {
            for (int i = 0; i < Inputs.Count; i++)
            {

                LineRenderer lr = transform.GetChild(i).GetComponents<LineRenderer>() [0];
                lr.material = lineMaterial;
                lr.startWidth = 0.1f;;
                lr.endWidth = 0.1f;
                lr.numCapVertices = 2;

                if (Inputs[i].GetOutput() == false)
                {
                    lr.startColor = Settings.WireColours[Settings.OffWireIndex].Colour;
                    lr.endColor = Settings.WireColours[Settings.OffWireIndex].Colour;
                }
                else if (Inputs[i].GetOutput() == true)
                {
                    lr.startColor = Settings.WireColours[Settings.OnWireIndex].Colour;
                    lr.endColor = Settings.WireColours[Settings.OnWireIndex].Colour;
                }
                else
                {
                    lr.startColor = Color.blue;
                    lr.endColor = Color.blue;
                }

                lines.Add(lr);
                lines[i].SetPositions(new Vector3[] { lr.transform.position, Inputs[i].transform.position });

                //if input has an allignment component set it's output transform equal to the correct input pointon this node
                if (Inputs[i].TryGetComponent(out NodeAllignment allingment))
                {
                    allingment.OutputTransform = lr.transform;
                }
            }
        }
        //for nodes without inputs or null inputs
        else
        {
            for (int i = 0; i < Inputs.Count; i++)
            {
                LineRenderer lr = transform.GetChild(i).GetComponents<LineRenderer>() [0];
                lr.positionCount = 0;
            }

        }

    }

    public virtual void UpdateConnections()
    {
        if (Inputs.Count != 0 && Inputs[0] != null)
        {
            for (int i = 0; i < Inputs.Count; i++)
            {
                if (Inputs[i].GetOutput() == false)
                {
                    lines[i].startColor = Settings.WireColours[Settings.OffWireIndex].Colour;
                    lines[i].endColor = Settings.WireColours[Settings.OffWireIndex].Colour;
                }
                else if (Inputs[i].GetOutput() == true)
                {
                    lines[i].startColor = Settings.WireColours[Settings.OnWireIndex].Colour;
                    lines[i].endColor = Settings.WireColours[Settings.OnWireIndex].Colour;
                }
                else
                {
                    lines[i].startColor = Color.blue;
                    lines[i].endColor = Color.blue;
                }
                lines[i].SetPositions(new Vector3[] { lines[i].transform.position, Inputs[i].transform.position });
            }
        }

    }

    public void DebugIO()
    {
        Debug.Log(this.gameObject.name + "\nInput 1: " + Inputs[0].GetOutput() + "\nOutput: " + GetOutput());
    }

}