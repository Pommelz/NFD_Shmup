using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObjects/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] int waveNumber;
    public int WaveNumber { get => waveNumber; }
    [SerializeField] bool hasBoss;
    public bool HasBoss { get => hasBoss; }
    [SerializeField] GameObject bossPrefab;
    public GameObject BossPrefab { get => bossPrefab; }



}
