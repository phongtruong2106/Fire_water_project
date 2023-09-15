using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSystemData", menuName = "Data/Repoint Data/Base Data")]
public class BaseeDataSystem : ScriptableObject
{
    public float respawnDelay = 7f;
    public bool isRespawning = false;
}
