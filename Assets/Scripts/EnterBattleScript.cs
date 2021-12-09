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
    //The open world player
    private GameObject worldPlayer;
    //The open world companion
    private GameObject worldCompanion;

    private void Start()
    {
        currentData = GameObject.Find("CurrentData");
        cam = GameObject.Find("Main Camera");
        worldPlayer = GameObject.Find("PlayerWorld");
        worldCompanion = GameObject.Find("CompanionWorld");
    }

    private void StartBattle()
    {
        worldPlayer.GetComponent<WorldPlayerMovementScript>().DeactivateFirstStrikeUI();
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Additive);
        cam.GetComponent<WorldCameraScript>().ChangeBattleCamera(true);
    }

    private void EndBattle()
    {
        currentData.GetComponent<CurrentDataScript>().battle = 0;
        cam.GetComponent<WorldCameraScript>().ChangeBattleCamera(false);
        SceneManager.UnloadSceneAsync("BattleScene");
        if (currentData.GetComponent<CurrentDataScript>().tutorialState == 9)
        {
            currentData.GetComponent<CurrentDataScript>().tutorialState += 1;
            worldCompanion.GetComponent<WorldCompanionMovementScript>().AppearCompanion();
            currentData.GetComponent<CheckFlagsScript>().ClearJail();
            worldPlayer.GetComponent<WorldPlayerMovementScript>().StartDialogue(new Dialogue(new Transform[] { worldPlayer.transform }, new string[] { "npc_prisonerAdventurer_1" }, true, 3, new Vector2(-4.12f, -9.81f)));
        }
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
