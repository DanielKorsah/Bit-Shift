using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public TextMeshProUGUI bg_indicator;
    public Image bg_sample;
    public int BackgroundIndex;
    public int OnWireIndex;
    public int OffWireIndex;
    public List<ColourObject> BackgroundColours = new List<ColourObject>();
    public List<ColourObject> WireColours = new List<ColourObject>();

    public string ColourName = "NewColour";

    public void AddBackgroundColourObject(string name, Color value)
    {
        ColourObject c = new ColourObject(name, value);
        BackgroundColours.Add(c);
    }

    public void AddWireColourObject(string name, Color value)
    {
        ColourObject c = new ColourObject(name, value);
        WireColours.Add(c);
    }

    public void SaveColours()
    {
        //JsonConvert.DefaultSettings().Converters.Add(new Newtonsoft.Json.Converters.ColorConverter());
        ColourDataObject colourData = ColourDataObject.Instance;
        colourData.BackgroundIndex = BackgroundIndex;
        colourData.OnWireIndex = OnWireIndex;
        colourData.OffWireIndex = OffWireIndex;
        colourData.BackgroundColourObjects = BackgroundColours;
        colourData.WireColourObjects = WireColours;

        //serialise list of people, indented, with type info
        var jsonString = JsonConvert.SerializeObject(colourData, Formatting.Indented, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        });

        string path = Path.Combine(Application.dataPath, "Data/ColourData.json");
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }

        File.WriteAllText(path, jsonString);
        Debug.Log("Saved");
    }

    public void LoadColours()
    {
        //JsonConvert.DefaultSettings().Converters.Add(new Newtonsoft.Json.Converters.ColorConverter());

        string path = Path.Combine(Application.dataPath, "Data/ColourData.json");
        string debug = Path.Combine(Application.dataPath, "Data/debug.json");
        if (!File.Exists(path))
        {
            Debug.Log("NO SAVE FILE RECOGNISED");
        }
        else
        {
            ColourDataObject colourData = ColourDataObject.Instance;
            string jsonString = File.ReadAllText(path);

            //check that the file is read correctly
            File.WriteAllText(debug, jsonString);

            colourData = JsonConvert.DeserializeObject<ColourDataObject>(jsonString, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            BackgroundIndex = colourData.BackgroundIndex;
            OnWireIndex = colourData.OnWireIndex;
            OffWireIndex = colourData.OffWireIndex;
            BackgroundColours = colourData.BackgroundColourObjects;

            foreach (ColourObject colour in BackgroundColours)
            {
                Debug.Log(colour.Name + "loaded from save.");
            }

            foreach (ColourObject colour in BackgroundColours)
            {
                Debug.Log(colour.Name + "loaded from save.");
            }
            Debug.Log("Finished Loading Colours");
        }
    }

    void Start()
    {
        LoadColours();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (BackgroundIndex + 1 < BackgroundColours.Count)
            {
                BackgroundIndex++;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && BackgroundIndex > 0)
        {
            BackgroundIndex--;
        }

        bg_indicator.text = "Background: " + BackgroundColours[BackgroundIndex].Name;
        bg_sample.color = BackgroundColours[BackgroundIndex].Colour;

    }

}