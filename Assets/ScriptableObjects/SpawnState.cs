using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage", menuName = "ScriptableObjects/SpawnStage", order = 1)]
public class SpawnState : ScriptableObject
{
    public List<GameObject> spawnObjects;
    public List<float> spawnProbability;

    public int stageDuration;
}

