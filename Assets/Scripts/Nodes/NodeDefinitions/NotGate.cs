using UnityEngine;

namespace Nodes.NodeDefinitions
{
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
            if (this.Inputs[0].GetOutput() == null)
                Debug.LogWarning("Null node input");
            return !this.Inputs[0].GetOutput();
        }
    }
}