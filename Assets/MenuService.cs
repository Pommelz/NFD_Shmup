using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuService : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Transform parentTransform = GameObject.FindObjectOfType<Bootstrapper>().transform;
        this.transform.parent = parentTransform? parentTransform : null ;
    }

    public void StartGame()
    {
        GameStateHandler.SetState(GameStates.LoadLevel);
        
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
