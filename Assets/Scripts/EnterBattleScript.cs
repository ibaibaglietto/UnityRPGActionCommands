using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBattleScript : MonoBehaviour
{
    private GameObject cam;

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    private void StartBattle()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Additive);
        cam.GetComponent<WorldCameraScript>().ChangeBattleCamera(true);
    }

    private void EndBattle()
    {
        PlayerPrefs.SetInt("Battle", 0);
        cam.GetComponent<WorldCameraScript>().ChangeBattleCamera(false);
        SceneManager.UnloadSceneAsync(1);
    }
}
