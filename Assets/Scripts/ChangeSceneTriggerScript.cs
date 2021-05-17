using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTriggerScript : MonoBehaviour
{
    //The name of the scene we are going to change to
    [SerializeField] string sceneName;
    //The direction the player will move
    [SerializeField] int dir;
    //The new position of the player
    [SerializeField] Vector3 pos;
    //The change scene screen animator
    private GameObject changeSceneScreen;
    //The current data
    private GameObject currentData;

    private void Start()
    {
        currentData = GameObject.Find("CurrentData");
        changeSceneScreen = GameObject.Find("EndBattleImage");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!other.GetComponent<WorldPlayerMovementScript>().GetChangingScene())
            {
                changeSceneScreen.GetComponent<Animator>().SetTrigger("toOther");
                changeSceneScreen.GetComponent<EnterBattleScript>().SetSceneName(sceneName);
                other.GetComponent<WorldPlayerMovementScript>().SetChangingScene(dir);
                currentData.GetComponent<CurrentDataScript>().spawnX = pos.x;
                currentData.GetComponent<CurrentDataScript>().spawnY = pos.y;
                currentData.GetComponent<CurrentDataScript>().spawnZ = pos.z;
            }
            else if(dir == 0) other.GetComponent<WorldPlayerMovementScript>().SetChangingScene(1);
            else if(dir == 1) other.GetComponent<WorldPlayerMovementScript>().SetChangingScene(0);
            else if (dir == 2) other.GetComponent<WorldPlayerMovementScript>().SetChangingScene(3);
            else other.GetComponent<WorldPlayerMovementScript>().SetChangingScene(2);
        }
    }
}
