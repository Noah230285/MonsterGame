using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System;
using AFewScrewsLoose.Editor.CustomEditors;

[CustomEditor(typeof(HallwayPiece))]
public class HallwayPieceEditor : DefaultEditor
{
    [Serializable]
    public struct NewHallway
    {
        HallwayPiece.HallwayType type;
        
        public void CreateNewHallway()
        {

        }
    }

    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new();
        root.Add(base.CreateInspectorGUI());
        return root;
    }
}
