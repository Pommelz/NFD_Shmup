using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVariables : Singleton<LevelVariables>
{
    string levelName;
    public string LevelName { get => levelName; set => levelName = value; }
    int levelNumber;
    public int LevelNumber { get => levelNumber; set => levelNumber = value; }



    int levelScore;
    int shotsFired;
    int shotsHit;


    public void AddScore(int _score)
    {
        levelScore += _score;
    }

    public enum LevelNames
    {
        NeoVentura,
    }
}
