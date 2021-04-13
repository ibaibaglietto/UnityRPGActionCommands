using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBattleScript : MonoBehaviour
{
    private void StartBattle()
    {
        SceneManager.LoadScene(1);
    }

    private void EndBattle()
    {
        SceneManager.LoadScene(0);
    }
}
