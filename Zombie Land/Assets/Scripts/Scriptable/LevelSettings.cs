using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelSettings : ScriptableObject
{
    public int TargetFrags;

    public List<GameObject> ZombiePool;
}
