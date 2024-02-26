using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayPiece : MonoBehaviour
{
    public enum HallwayType
    {
        straight,
        straightCloset,
        straightPopout,
        turnLeft,
        turnRight
    }

    [SerializeField] float _length = 2;
    [SerializeField] bool _isEnd = true;
    [SerializeField] PrefabContainer[] _typePrefabs;
}
