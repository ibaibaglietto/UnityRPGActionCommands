using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    private GameObject battleController;
    // Start is called before the first frame update
    void Start()
    {
        battleController = GameObject.Find("BattleController");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy" && collision.GetComponent<EnemyTeamScript>().IsAlive()) battleController.GetComponent<BattleController>().DealDamage(collision.transform, 1, true); 
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
