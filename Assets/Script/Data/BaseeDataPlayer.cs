using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class BaseeDataPlayer : ScriptableObject
{
    public float SpeedMove;
    public float Jump_fouce;
    public int health_bar;
    public bool isDie = false;
}
