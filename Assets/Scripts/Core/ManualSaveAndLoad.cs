using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if Unity_Editor
[CustomEditor(typeof(Settings))]
public class ManualSaveAndLoad : Editor
{
    Color newColour = Color.white;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Settings set = (Settings) target;

        newColour = EditorGUILayout.ColorField("New Colour", newColour);
        if (GUILayout.Button("Add Background Colour "))
        {
            set.AddBackgroundColourObject(set.ColourName, newColour);
        }
        if (GUILayout.Button("Add Wire Colour "))
        {
            set.AddWireColourObject(set.ColourName, newColour);
        }

        if (GUILayout.Button("Save "))
        {
            set.SaveColours();
        }

        if (GUILayout.Button("Load "))
        {
            set.LoadColours();
        }

    }
}
#endif