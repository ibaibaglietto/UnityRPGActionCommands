using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEnemy : MonoBehaviour
{
    //The movement speed of the enemy
    private float speedX;
    private float speedZ;
    //The animator
    Animator animator;
    //The player and the companion
    private GameObject player;
    private GameObject companion;
    //The attack area prefab and the area itself
    [SerializeField] private Transform areaPrefab;
    private Transform area;
    //The position of the attack objective
    private Vector3 objectivePos;

    //The enemies of the battle. 1-> bandit, 2-> evil wizard, 3-> king
    [SerializeField] private int enemy1;
    [SerializeField] private int enemy2;
    [SerializeField] private int enemy3;
    [SerializeField] private int enemy4;
    //The start battle screen
    private GameObject startBattleScreen;

    void Start()
    {
        startBattleScreen = GameObject.Find("EnterBattleImage");
        //We initialize the variables
        speedX = 0.0f;
        speedZ = 0.0f;
        //We find the animator
        animator = GetComponent<Animator>();
        //We find the player
        player = GameObject.Find("PlayerWorld");
        //We find the companion
        companion = GameObject.Find("AdventurerWorld");
    }

    private void Update()
    {
        if((Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z)) <= (Mathf.Abs(companion.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(companion.transform.position.z - gameObject.transform.position.z)))
        {
            if (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z) > 1.5f)
            {
                //Detect where the player is and move the enemy towards them
                speedX = (player.transform.position.x - gameObject.transform.position.x) / (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z));
                speedZ = (player.transform.position.z - gameObject.transform.position.z) / (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z));
            }
            else if (!animator.GetBool("Attack"))
            {
                objectivePos = player.transform.position;
                animator.SetBool("Attack", true);
                speedX = 0.0f;
                speedZ = 0.0f;
            }
        }
        else
        {
            if (Mathf.Abs(companion.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(companion.transform.position.z - gameObject.transform.position.z) > 1.5f)
            {
                //Detect where the companion is and move the enemy towards them
                speedX = (companion.transform.position.x - gameObject.transform.position.x) / (Mathf.Abs(companion.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(companion.transform.position.z - gameObject.transform.position.z));
                speedZ = (companion.transform.position.z - gameObject.transform.position.z) / (Mathf.Abs(companion.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(companion.transform.position.z - gameObject.transform.position.z));
            }
            else if(!animator.GetBool("Attack"))
            {
                objectivePos = companion.transform.position;
                animator.SetBool("Attack", true);
                speedX = 0.0f;
                speedZ = 0.0f;
            }
        }
        
        //We put the correct values on the animator variables
        animator.SetFloat("SpeedX", speedX);
        if (speedX != 0 || speedZ != 0) animator.SetBool("Moving", true);
        else animator.SetBool("Moving", false);
        if ((player.transform.position.x - gameObject.transform.position.x) >= 0.0f) animator.SetBool("FacingRight", true);
        else animator.SetBool("FacingRight", false);
    }


    void FixedUpdate()
    {
        //move the enemy on the direction we saved previously
        if(animator.GetBool("Attack")) gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, gameObject.GetComponent<Rigidbody>().velocity.y, 0.0f);
        else gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speedX * 7, gameObject.GetComponent<Rigidbody>().velocity.y, speedZ * 7);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player" || collision.transform.tag == "Companion") StartBattle(0,0);
    }
    //Function to spawn the attack area
    private void SpawnAttack()
    {
        area = Instantiate(areaPrefab, objectivePos, Quaternion.identity);
        area.GetComponent<WorldBattleTrigger>().SetUser(gameObject.transform);
    }

    //Function to end the attack animation
    private void EndAttack()
    {
        Destroy(area.gameObject);
        animator.SetBool("Attack", false);
    }

    //A function to start the battle. User: 0-> no first attack, 1-> player first attack, 2-> companion first attack, 3 -> enemy first attack. objective in case of enemy attack: 1-> player, 2-> companion
    public void StartBattle(int user, int objective)
    {
        PlayerPrefs.SetInt("Enemy1", enemy1);
        PlayerPrefs.SetInt("Enemy2", enemy2);
        PlayerPrefs.SetInt("Enemy3", enemy3);
        PlayerPrefs.SetInt("Enemy4", enemy4);
        if(user == 0)
        {
            PlayerPrefs.SetInt("EnemyStart", 0);
            PlayerPrefs.SetInt("FirstAttackObjective", 0);
            PlayerPrefs.SetInt("PlayerFirstAttack", 0);
            PlayerPrefs.SetInt("PlayerAttack", 0);
            PlayerPrefs.SetInt("PlayerStyle", 0);
            PlayerPrefs.SetInt("CompanionFirstAttack", 0);
            PlayerPrefs.SetInt("CompanionAttack", 0);
            PlayerPrefs.SetInt("CompanionStyle", 0);
        }
        else if (user == 1)
        {
            PlayerPrefs.SetInt("EnemyStart", 0);
            PlayerPrefs.SetInt("FirstAttackObjective", 0);
            PlayerPrefs.SetInt("PlayerFirstAttack", 1);
            PlayerPrefs.SetInt("PlayerAttack", 0);
            PlayerPrefs.SetInt("PlayerStyle", 0);
            PlayerPrefs.SetInt("CompanionFirstAttack", 0);
            PlayerPrefs.SetInt("CompanionAttack", 0);
            PlayerPrefs.SetInt("CompanionStyle", 0);
        }
        else if (user == 2)
        {
            PlayerPrefs.SetInt("EnemyStart", 0);
            PlayerPrefs.SetInt("FirstAttackObjective", 0);
            PlayerPrefs.SetInt("PlayerFirstAttack", 0);
            PlayerPrefs.SetInt("PlayerAttack", 0);
            PlayerPrefs.SetInt("PlayerStyle", 0);
            PlayerPrefs.SetInt("CompanionFirstAttack", 1);
            PlayerPrefs.SetInt("CompanionAttack", 0);
            PlayerPrefs.SetInt("CompanionStyle", 0);
        }
        else if (user == 3)
        {
            PlayerPrefs.SetInt("EnemyStart", 1);
            PlayerPrefs.SetInt("FirstAttackObjective", objective);
            PlayerPrefs.SetInt("PlayerFirstAttack", 0);
            PlayerPrefs.SetInt("PlayerAttack", 0);
            PlayerPrefs.SetInt("PlayerStyle", 0);
            PlayerPrefs.SetInt("CompanionFirstAttack", 0);
            PlayerPrefs.SetInt("CompanionAttack", 0);
            PlayerPrefs.SetInt("CompanionStyle", 0);
        }
        startBattleScreen.GetComponent<Animator>().SetTrigger("Start");
        Time.timeScale = 0.1f;
    }
}
