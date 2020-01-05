using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WaveDataScriptableObject", order = 1)]
public class WaveData : ScriptableObject
{
    public bool bossFight;
    public int waveNr, timeToNextWave;
    public string enemiesPlacement;
} 
