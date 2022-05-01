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
        switch (obj)
        {

            case GameStates.Paused:
                Time.timeScale = 0f;
                break;
            case GameStates.Boss:
                break;
            case GameStates.Resumed:
                Time.timeScale = 1f;
                OnStateChanged(GameStates.Level);
                break;
            case GameStates.Win:
                break;
            case GameStates.Lose:
                break;

            default:
                break;
        }

    }
}
