using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        GameStateHandler.BootGame();
        GameStateHandler.SetState(GameStates.LoadingComplete);
    }

}
