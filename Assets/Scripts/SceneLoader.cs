﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadP1Won()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadP2Won()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadStartScene()
    {
        //FindObjectOfType<GameStatus>().destoryOnRestart();
        SceneManager.LoadScene(0);
    }
}
