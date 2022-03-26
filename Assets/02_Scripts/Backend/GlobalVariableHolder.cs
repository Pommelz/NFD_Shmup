using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariableHolder : PersistentSingleton<GlobalVariableHolder>
{


    private void OnEnable()
    {
        GameStateHandler.StateChanged_Event += OnStateChanged;
    }
    private void OnDisable()
    {
        GameStateHandler.StateChanged_Event -= OnStateChanged;
    }



    private void OnStateChanged(GameStates obj)
    {
        throw new NotImplementedException();
    }
}
