using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuService : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        GameStateHandler.SetState(GameStates.StartLevel);
        
    }

    public void CloseApp()
    {
        Application.Quit();
    }

    public void LoadTutorial()
    {

    }

    public void Resume()
    {
        GameStateHandler.SetState(GameStates.Paused);
    }

    public void Pause()
    {
        GameStateHandler.SetState(GameStates.Resumed);
        
    }

}
