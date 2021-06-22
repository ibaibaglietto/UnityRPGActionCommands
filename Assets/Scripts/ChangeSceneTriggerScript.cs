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
        if (currentData.GetComponent<CurrentDataScript>().changingScene == 1) changeSceneScreen.GetComponent<Animator>().SetTrigger("FromOther");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "PlayerSphere")
        {
            if(currentData.GetComponent<CurrentDataScript>().changingScene == 0)
            {
                changeSceneScreen.GetComponent<Animator>().SetTrigger("toOther");
                changeSceneScreen.GetComponent<EnterBattleScript>().SetSceneName(sceneName);
                currentData.GetComponent<CurrentDataScript>().spawnX = pos.x;
                currentData.GetComponent<CurrentDataScript>().spawnY = pos.y;
                currentData.GetComponent<CurrentDataScript>().spawnZ = pos.z;
            }
            if(other.tag == "PlayerSphere") other.transform.parent.GetComponent<WorldPlayerMovementScript>().SetChangingScene(dir);
            else other.GetComponent<WorldPlayerMovementScript>().SetChangingScene(dir);
        }
    }
}
