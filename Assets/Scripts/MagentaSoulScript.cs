using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagentaSoulScript : MonoBehaviour
{
    //The battle controller
    private GameObject battleController;
    void Start()
    {
        battleController = GameObject.Find("BattleController");
    }
    //Function to absorb one magenta shard, creating another and incrementing the fog size
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("magentaShard"))
        {
            transform.GetChild(0).GetComponent<AudioSource>().Play();
            battleController.GetComponent<BattleController>().CreateMagentaShard();
            battleController.GetComponent<BattleController>().IncrementFogSize();
            Destroy(collision.gameObject);
        }
    }
}
