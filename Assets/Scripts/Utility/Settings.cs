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
    public TextMeshProUGUI on_indicator;
    public TextMeshProUGUI off_indicator;
    public Image bg_sample;
    public Image on_sample;
    public Image off_sample;
    public int BackgroundIndex;
    public static int OnWireIndex = 0;
    public static int OffWireIndex = 0;
    public static List<ColourObject> BackgroundColours = new List<ColourObject>();
    public static List<ColourObject> WireColours = new List<ColourObject>();

    public string ColourName = "NewColour";

    void Awake()
    {
        //Comment out colour serialisation to make the browser build easier
        //LoadColours();
        BackgroundColours.Add(new ColourObject("PCB Green", new Color(0, 0.2358491f, 0, 1)));
        BackgroundColours.Add(new ColourObject("Deep Black", new Color(0, 0, 0, 1)));
        BackgroundColours.Add(new ColourObject("Neutral Grey", new Color(0.47f, 0.47f, 0.47f, 1)));
        BackgroundColours.Add(new ColourObject("Blueprint Blue", new Color(0, 0.3423839f, 0.8773585f, 1)));
        BackgroundColours.Add(new ColourObject("Deep Blue", new Color(0, 0.06236897f, 0.1603774f, 1)));

        WireColours.Add(new ColourObject("Copper Orange", new Color(0.7830189f, 0.3215815f, 0, 1)));
        WireColours.Add(new ColourObject("Hot Orange", new Color(1, 0.5964087f, 0, 1)));
        WireColours.Add(new ColourObject("Plain White", new Color(1, 1, 1, 1)));
        WireColours.Add(new ColourObject("Deep Black", new Color(0, 0, 0, 1)));
        WireColours.Add(new ColourObject("Pure Red", new Color(1, 0, 0, 1)));
        WireColours.Add(new ColourObject("Pure Green", new Color(0, 1, 0, 1)));

        //initialise the position of the user feedbback indicatiors
        bg_sample.color = BackgroundColours[BackgroundIndex].Colour;
        bg_indicator.text = "Background: " + BackgroundColours[BackgroundIndex].Name;
        on_sample.color = WireColours[OnWireIndex].Colour;
        on_indicator.text = "Live Wire: " + WireColours[OnWireIndex].Name;
        off_sample.color = WireColours[OffWireIndex].Colour;
        off_indicator.text = "Off Wire: " + WireColours[OffWireIndex].Name;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
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
            Camera.main.backgroundColor = BackgroundColours[BackgroundIndex].Colour;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (OnWireIndex + 1 < WireColours.Count)
                {
                    OnWireIndex++;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && OnWireIndex > 0)
            {
                OnWireIndex--;
            }

            on_indicator.text = "Live Wire: " + WireColours[OnWireIndex].Name;
            on_sample.color = WireColours[OnWireIndex].Colour;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (OffWireIndex + 1 < WireColours.Count)
                {
                    OnWireIndex++;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && OffWireIndex > 0)
            {
                OffWireIndex--;
            }

            off_indicator.text = "Off Wire: " + WireColours[OffWireIndex].Name;
            off_sample.color = WireColours[OffWireIndex].Colour;
        }

    }

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

}