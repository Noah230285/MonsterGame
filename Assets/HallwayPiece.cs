using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayPiece : MonoBehaviour
{
    public enum HallwayType
    {
        straight,
        closet,
        popout,
        turnLeft,
        turnRight,
        turnFork
    }

    [SerializeField] Transform _startConnectPoint;
    public Transform startConnectPoint => _startConnectPoint;

    [SerializeField] Transform _endConnectPoint;
    public Transform endConnectPoint => _endConnectPoint;

    [SerializeField] HallwayType _type;
    [SerializeField] float _length = 2;
    [SerializeField] bool _isEnd = true;

    [SerializeField, HideInInspector] HallwayBrain _brain;
    public HallwayBrain brain
    {
        get => _brain;
        set => _brain = value;
    }


#if UNITY_EDITOR
    [SerializeField, HideInInspector] HallwayType _createType;
#endif

}
