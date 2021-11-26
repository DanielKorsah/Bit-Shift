using Nodes.NodeDefinitions;
using UnityEngine;

namespace Nodes
{
    [ExecuteInEditMode]
    public class NodeAlignment : MonoBehaviour
    {
        public enum HorizontalAlignment
        {
            None,
            ToInput,
            ToOutput
        }

        public enum VerticalAlignment
        {
            None,
            ToInput,
            ToOutput
        }

        public HorizontalAlignment horizontal;
        public VerticalAlignment vertical;
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
                case HorizontalAlignment.ToInput:
                    transform.position = new Vector3(InputTransform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    break;
                case HorizontalAlignment.ToOutput:
                    transform.position = new Vector3(OutputTransform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    break;
                default:
                    break;

            }

            switch (vertical)
            {
                case VerticalAlignment.ToInput:
                    transform.position = new Vector3(gameObject.transform.position.x, InputTransform.position.y, gameObject.transform.position.z);
                    break;
                case VerticalAlignment.ToOutput:
                    transform.position = new Vector3(gameObject.transform.position.x, OutputTransform.position.y, gameObject.transform.position.z);
                    break;
                default:
                    break;

            }
        }
    }
}