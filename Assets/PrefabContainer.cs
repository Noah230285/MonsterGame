using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/PrefabContainer")]
public class PrefabContainer : ScriptableObject
{
    public GameObject[] Prefabs;

    public GameObject FindRandomPrefab()
    {
        if (Prefabs.Length == 0)
        {
            return null;
        }
        return Prefabs[Random.Range(0, Prefabs.Length)];
    }
}
