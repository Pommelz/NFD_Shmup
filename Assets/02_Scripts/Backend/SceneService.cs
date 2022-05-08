using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneService : MonoBehaviour
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
            case GameStates.LoadingComplete:
                SceneManager.LoadScene("MainMenu");
                break;
            case GameStates.LoadLevel:
                Debug.Log("beep");
                SceneManager.LoadScene("GameScene");
                break;
            case GameStates.BackToMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            default:
                break;
        }
    }
}
