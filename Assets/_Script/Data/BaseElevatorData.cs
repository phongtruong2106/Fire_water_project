using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSystemData", menuName = "Data/ElevatorData Data/Base Data")]
public class BaseElevatorData : ScriptableObject
{
    public Transform player;
    public Transform evavatorSwitch;
    public Transform downpos;
    public Transform upperpos;

    public float speed;

    public bool isevelevatordown;
}
