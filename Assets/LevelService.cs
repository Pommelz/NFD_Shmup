using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoBehaviour
{
    WaveSpawner enemySpawner;

    private void OnEnable()
    {
        enemySpawner = GameObject.FindObjectOfType<WaveSpawner>();
        GameStateHandler.StateChanged_Event += OnStateChanged;
        GameStateHandler.SetState(GameStates.StartLevel);
    }
    private void OnDisable()
    {
        GameStateHandler.StateChanged_Event -= OnStateChanged;
    }

    private void OnStateChanged(GameStates state)
    {
        switch (state)
        {

            case GameStates.StartLevel:
                enemySpawner.StartSpawning();
                break;
            case GameStates.Boss:
                break;
            case GameStates.Resumed:
                Time.timeScale = 1f;
                OnStateChanged(GameStates.Level);
                break;
            case GameStates.Win:
                enemySpawner.EndSpawning();
                break;
            case GameStates.Lose:
                enemySpawner.EndSpawning();
                break;

            default:
                break;
        }
    }
}
