using System.Collections;
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

    private void Start()
    {
        currentData = GameObject.Find("CurrentData");
        cam = GameObject.Find("Main Camera");
    }

    private void StartBattle()
    {
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
        SceneManager.LoadScene(sceneName);
    }

    public void SetSceneName(string name)
    {
        sceneName = name;
    }
}
