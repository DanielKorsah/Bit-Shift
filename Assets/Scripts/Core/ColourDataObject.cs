using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Core
{
    //the Json writable/readable object
    public class ColourDataObject
    {
        //<Singleton Boilerplate>
        private static ColourDataObject instance = null;
        private static readonly object padlock = new object();
        ColourDataObject() {}
        public static ColourDataObject Instance
        {
            get
            {
                lock(padlock)
                {
                    if (instance == null)
                    {
                        instance = new ColourDataObject();
                    }
                    return instance;
                }
            }
        }
        //</Singletone Boilerplate>

        [JsonProperty("BackgroundIndex")]
        public int BackgroundIndex { get; set; }

        [JsonProperty("OnWireIndex")]
        public int OnWireIndex { get; set; }

        [JsonProperty("OffWireIndex")]
        public int OffWireIndex { get; set; }

        [JsonProperty("BackgroundColourObjects")]
        public List<ColourObject> BackgroundColourObjects { get; set; }

        [JsonProperty("WireColourObjects")]
        public List<ColourObject> WireColourObjects { get; set; }
    }

//the unit objects that represent a colour
    public class ColourObject
    {
        public ColourObject(string name, Color value)
        {
            Name = name;
            Colour = value;
        }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Colour")]
        public Color Colour { get; set; }
    }
}