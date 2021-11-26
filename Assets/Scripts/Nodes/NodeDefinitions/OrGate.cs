using UnityEngine;

namespace Nodes.NodeDefinitions
{
    public class OrGate : Node
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

            //error checking
            if (Inputs[0].GetOutput() == null || Inputs[1].GetOutput() == null)
            {
                Debug.LogError("Null node input");
            }

            if (Inputs[0].GetOutput() == true || Inputs[1].GetOutput() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}