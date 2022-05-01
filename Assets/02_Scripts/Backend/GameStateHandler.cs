using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStateHandler
{
    public static Action<GameStates> StateChanged_Event;

    static GameStates gameState;

    public static void BootGame()
    {
        gameState = GameStates.Booting;
    }

    public static void SetState(GameStates _gameState)
    {
        gameState = _gameState;
        StateChanged_Event?.Invoke(gameState);
    }

    public static GameStates GetState()
    {
        return gameState;
    }
    // Start is called before the first frame update

}
    public enum GameStates
    {
        Paused,
        Resumed,
        Booting,
        LoadingComplete,
        Level,
        Boss,
        Win,
        Lose,
        Menu,
        BackToMenu
    }
