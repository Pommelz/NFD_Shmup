using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollectable : BaseCollectable
{
    [SerializeField] int addedScore = 10000;

    private void AddScore()
    {
        //LevelVariables.Instance.AddScore(addedScore);
        Disable();
    }

    public override void Disable()
    {
        base.Disable();
    }
}
