using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System;
using AFewScrewsLoose.Editor.CustomEditors;
using UnityEditor.UIElements;

[CustomEditor(typeof(HallwayBrain))]
public class HallwayBrainEditor : DefaultEditor
{
    public override VisualElement CreateInspectorGUI()
    {
        serializedObject.Update();
        VisualElement root = new();
        root.Add(base.CreateInspectorGUI());

        var brain = target as HallwayBrain;
        SerializedProperty createType = serializedObject.FindProperty("_createType");
        root.Add(CreateHallwayButton(brain, createType));
        serializedObject.ApplyModifiedProperties();
        return root;
    }

    public static VisualElement CreateHallwayButton(HallwayBrain brain, SerializedProperty typeProperty)
    {
        VisualElement root = new();
        var spacing = new VisualElement();
        spacing.style.height = 20.0f;
        root.Add(spacing);
        root.Add(new Label("Create new piece"));
        root.Add(new PropertyField(typeProperty));
        var button = new Button(() => brain.CreateNewHallway((HallwayPiece.HallwayType)typeProperty.enumValueIndex));
        button.text = "Press to create";
        root.Add(button);
        return root;
    }
}
