using System;
using Core;
using Nodes.NodeLogic;
using TMPro;

namespace Nodes.NodeDefinitions
{
    public class InputNode : Node
    {
        private int index;
        public OutputNode[] Outputs = new OutputNode[8];

        public override bool? GetOutput()
        {
            return LogicManager.InputByteData[index];
        }

        private TextMeshProUGUI BitText;

        void Awake()
        {
            BitText = GetComponentInChildren<TextMeshProUGUI>();
            index = Int32.Parse(gameObject.name);

            //inform the manager what the starting state was
            if (BitText.text == "1")
            {
                LogicManager.InputByteData[index] = true;
            }
            else if (BitText.text == "0")
            {
                LogicManager.InputByteData[index] = false;
            }

        }

        private void Update()
        {

        }

        public void FlipBit()
        {
            if (BitText.text == "1")
            {
                BitText.text = "0";
                LogicManager.InputByteData[index] = false;
                SoundManager.FlipBitOff.Invoke();
            }
            else if (BitText.text == "0")
            {
                BitText.text = "1";
                LogicManager.InputByteData[index] = true;
                SoundManager.FlipBitOn.Invoke();
            }
            else
            {
                BitText.text = "?";
                LogicManager.InputByteData[index] = null;
            }

            //LogicManager.RefreshLogic();
        }

    }
}