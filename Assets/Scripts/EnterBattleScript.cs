﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBattleScript : MonoBehaviour
{
    private GameObject cam;
    //The current data
    private GameObject currentData;
    //The scene we are going to load
    private string sceneName;
    //The open world player
    private GameObject worldPlayer;

    private void Start()
    {
        currentData = GameObject.Find("CurrentData");
        cam = GameObject.Find("Main Camera");
        worldPlayer = GameObject.Find("PlayerWorld");
    }

    private void StartBattle()
    {
        worldPlayer.GetComponent<WorldPlayerMovementScript>().DeactivateFirstStrikeUI();
        SceneManager.LoadScene(1,LoadSceneMode.Additive);
        cam.GetComponent<WorldCameraScript>().ChangeBattleCamera(true);
    }

    private void EndBattle()
    {
        currentData.GetComponent<CurrentDataScript>().battle = 0;
        cam.GetComponent<WorldCameraScript>().ChangeBattleCamera(false);
        SceneManager.UnloadSceneAsync(1);
    }

    private void LoadScene()
    {
        currentData.GetComponent<CurrentDataScript>().changingScene = 1;
        SceneManager.LoadScene(sceneName);
    }

    //Function to end the scene transition
    private void EndTransition()
    {
        currentData.GetComponent<CurrentDataScript>().changingScene = 0;
    }

    public void SetSceneName(string name)
    {
        sceneName = name;
    }
}
