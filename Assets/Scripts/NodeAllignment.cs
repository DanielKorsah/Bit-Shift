using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class NodeAllignment : MonoBehaviour
{
    public enum HorizontalAllignment
    {
        None,
        ToInput,
        ToOutput
    }

    public enum VerticalAllignment
    {
        None,
        ToInput,
        ToOutput
    }

    public HorizontalAllignment horizontal;
    public VerticalAllignment vertical;
    public Transform OutputTransform;
    [SerializeField] Transform InputTransform;

    void Start()
    {
        InputTransform = gameObject.GetComponent<Node>().Inputs[0].gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        switch (horizontal)
        {
            case HorizontalAllignment.ToInput:
                transform.position = new Vector3(InputTransform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                break;
            case HorizontalAllignment.ToOutput:
                transform.position = new Vector3(OutputTransform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                break;
            default:
                break;

        }

        switch (vertical)
        {
            case VerticalAllignment.ToInput:
                transform.position = new Vector3(gameObject.transform.position.x, InputTransform.position.y, gameObject.transform.position.z);
                break;
            case VerticalAllignment.ToOutput:
                transform.position = new Vector3(gameObject.transform.position.x, OutputTransform.position.y, gameObject.transform.position.z);
                break;
            default:
                break;

        }
    }
}