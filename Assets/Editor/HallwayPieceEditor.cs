using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System;
using AFewScrewsLoose.Editor.CustomEditors;
using UnityEditor.UIElements;

[CustomEditor(typeof(HallwayPiece))]
public class HallwayPieceEditor : DefaultEditor
{

    public override VisualElement CreateInspectorGUI()
    {
        serializedObject.Update();
        VisualElement root = new();
        root.Add(base.CreateInspectorGUI());

        var brain = serializedObject.FindProperty("_brain").objectReferenceValue as HallwayBrain;
        SerializedProperty createType = serializedObject.FindProperty("_createType");
        root.Add(HallwayBrainEditor.CreateHallwayButton(brain, createType));
        serializedObject.ApplyModifiedProperties();
        return root;
    }
}
