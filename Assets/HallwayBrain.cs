using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static HallwayPiece;

public class HallwayBrain : MonoBehaviour
{
    [SerializeField] PrefabContainer[] _typePrefabs;
    [SerializeField] Transform _endConnectPoint;
    [SerializeField] HallwayPiece _endHallway;


#if UNITY_EDITOR
    [SerializeField, HideInInspector] HallwayType _createType;
#endif

    public void CreateNewHallway(HallwayType type)
    {
        Transform createPoint = _endHallway == null ? _endConnectPoint : _endHallway.endConnectPoint;
        PrefabContainer container = _typePrefabs[(int)type];



        GameObject instatiateObject = container.FindRandomPrefab();
        if (instatiateObject == null)
        {
            Debug.LogError($"Prefab in PrefabContainer {container} is null", this);
            return;
        }
        GameObject hallwayObject = Instantiate(instatiateObject, transform);
#if UNITY_EDITOR
        Undo.RegisterCreatedObjectUndo(hallwayObject, "Hallway part created");
        Undo.RegisterCompleteObjectUndo(this, "Hallway part created");
#endif
        HallwayPiece hallwayPiece = hallwayObject.GetComponent<HallwayPiece>();
        if (hallwayPiece == null)
        {
            Debug.LogError($"Prefab {hallwayObject} in PrefabContainer {container} does not contain a HallwayPiece MonoBehaviour", this);
            return;
        }
        // Rotation
        hallwayObject.transform.rotation = hallwayPiece.startConnectPoint.rotation * createPoint.rotation;

        // Position
        Vector3 startOffset = hallwayObject.transform.position - hallwayPiece.startConnectPoint.position;
        Debug.Log(startOffset);
        hallwayObject.transform.position = createPoint.position + startOffset;

        hallwayPiece.brain = this;
        _endHallway = hallwayPiece;
    }
}
