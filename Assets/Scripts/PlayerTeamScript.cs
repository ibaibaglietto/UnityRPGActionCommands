using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeamScript : MonoBehaviour
{
    [SerializeField] private Transform shurikenPrefab;

    private Transform shuriken;

    public Vector3 shurikenObjective;

    private GameObject battleController;



    private bool lastAttack;
    // Start is called before the first frame update
    void Awake()
    {
        battleController = GameObject.Find("BattleController");
        lastAttack = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void startAttackAction()
    {
        battleController.GetComponent<BattleController>().attackAction = true;
    }

    public void endMeleeAttack()
    {
        if(battleController.GetComponent<BattleController>().goodAttack == true && lastAttack == false)
        {
            lastAttack = true;
            battleController.GetComponent<BattleController>().attackAction = false;
        }
        else
        {
            lastAttack = false;
            battleController.GetComponent<BattleController>().badAttack = false;
            battleController.GetComponent<BattleController>().goodAttack = false;
            battleController.GetComponent<BattleController>().attackAction = false;
            gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
            battleController.GetComponent<BattleController>().finalAttack = false;
            battleController.GetComponent<BattleController>().returnStartPos = true;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }        
    }

    
    public void throwShuriken()
    {
        shuriken = Instantiate(shurikenPrefab, gameObject.transform.position, Quaternion.identity);
        shuriken.GetComponent<ShurikenScript>().SetObjective(shurikenObjective);
    }

    public void shurikenActionActivate()
    {
        gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Animator>().SetBool("Active", true);
    }

}
