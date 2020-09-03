using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeamScript : MonoBehaviour
{
    private GameObject battleController;
    // Start is called before the first frame update
    void Awake()
    {
        battleController = GameObject.Find("BattleController");
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void endMeleeAttack()
    {
        gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
        battleController.GetComponent<BattleController>().finalAttack = false;
        battleController.GetComponent<BattleController>().returnStartPos = true;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
