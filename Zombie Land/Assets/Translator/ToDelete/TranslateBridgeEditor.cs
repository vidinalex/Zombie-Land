using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TranslateBridge))]
public class TranslateBridgeEditor : Editor
{    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var translateBridge = target as TranslateBridge;

        if (GUILayout.Button("Translate"))
        {
            translateBridge.Replace();
        }
    }
}
