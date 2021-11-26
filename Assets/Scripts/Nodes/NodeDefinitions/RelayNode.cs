using UnityEngine;

namespace Nodes.NodeDefinitions
{
    public class RelayNode : Node
    {
        // Start is called before the first frame update
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
            if (this.Inputs[0].GetOutput() == null)
                Debug.LogWarning("Null node input");
            return this.Inputs[0].GetOutput();
        }
    }
}