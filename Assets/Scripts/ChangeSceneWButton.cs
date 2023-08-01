using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Random = System.Random;

public class ChangeSceneWButton : MonoBehaviour
{
    
    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void loadRandomScene()
    {
        Random random = new();
        string[] games = { "Matching Game Easy", "Matching Game Medium", "Matching Game Hard" };
        SceneManager.LoadScene(games[random.Next(0, games.Length)]);
    }

    public void Quit()
    {
        Debug.Log("User quit");
        Application.Quit();
    }
}
