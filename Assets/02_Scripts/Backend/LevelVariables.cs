using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVariables : Singleton<LevelVariables>
{

    int levelScore;
    int shotsFired;
    int shotsHit;

    public void AddScore(int _score)
    {
        levelScore += _score;
    }
}
