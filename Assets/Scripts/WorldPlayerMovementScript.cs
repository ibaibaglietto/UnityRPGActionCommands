using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WorldPlayerMovementScript : MonoBehaviour
{
    //The direction the player is moving. 0-> not moving, 1-> right, 2-> left, 3 -> up, 4 -> down
    private float speedX;
    private float speedZ;
    //A mask determining what is ground to the character
    [SerializeField] private LayerMask whatIsGround;
    //A position marking where to check if the player is grounded.
    [SerializeField] private Transform groundCheck;
    //The canvas
    private GameObject canvas;
    //The companion
    private GameObject companion;
    //A boolean to know if the player is changing scene
    private bool changingScene;
    //A boolean to know if the player has changed scene
    private bool changedScene;
    //An int to know where is the player moving when changing scene. 0-> left, 1 -> right, 2 -> up, 3 -> down
    private int changingSceneMov;

    //Radius of the overlap circle to determine if grounded
    const float groundedRadius = 0.07f;
    //Whether or not the player is grounded.
    private bool grounded;
    //A boonean to know if the player is attacking or not
    private bool attacking;
    //The animator
    Animator animator;
    //The melee attack direction. 0-> right, 1-> left, 2 -> up, 3-> down
    private int dir;
    //The melee attack prefab and the attack itself
    [SerializeField] private Transform meleePrefab;
    private Transform melee;
    //A boolean to know if the player has fled a battle
    private bool fled;
    private float fledTime;
    //A boolean to know if the player can rest
    private bool canRest;
    //A boolean to know if the player is moving to the rest position
    private bool movingToRest;
    //A boolean to know if the player is resting
    private bool resting;
    //The rest position
    private Vector2 restPos;
    //The X position of the fire
    private float fireX;
    //The image to represent that an object is interactable
    private GameObject interactable;
    //The fireplace the player is using
    private GameObject firePlace;
    //The dialogue manager
    private GameObject dialogueManager;
    //A boolean to know if the player is in a dialogue
    private bool dialogue;
    //The rest UI
    private GameObject restUI;
    //The player rest UI
    private GameObject restPlayerUI;
    //The player rest main UI
    private GameObject restPlayerMainUI;
    //The player stats rest UI
    private GameObject restPlayerStatsUI;
    //The player gems rest UI
    private GameObject restPlayerGemsUI;
    //The player items rest UI
    private GameObject restPlayerItemsUI;
    //The companion rest UI
    private GameObject restCompanionUI;
    //The rest instructions
    private GameObject restInstructions;
    //The rest instructions text
    private Text restInstructionsText;
    //An int to know in what state the rest menu is. 1-> Main menu, 2-> player main menu, 3-> Player stats, 4 -> Player Gems, 5 -> Player items, 6 -> Save menu, 7 -> Companion menu
    private int restUIState;
    //An int to know what option are we selecting on the main menu. 1 -> Player, 2 -> Save, 3 -> companion
    private int restUISelecting;
    //An int to know what option are we selecting on the player main menu. 1 -> stats, 2 -> gems, 3 -> items 
    private int restPlayerMainUISelecting;
    //An int to know what option are we selecting on the player gem menu.
    private int restPlayerGemUISelecting;
    //An int to know what option are we selecting on the player item menu.
    private int restPlayerItemUISelecting;
    //An int to know what option are we selecting on the companion menu. 1 -> adventurer, 2 -> wizard
    private int restCompanionUISelecting;
    //An int to know the number of the gem UI scroll
    private int gemUIScroll;
    //An int to know the number of the item UI scroll
    private int itemUIScroll;
    //An int to know the number of available gems
    private int availableGems;
    //An array with all the gems
    private string[] allGems = {"Light Sword", "Multistrike Sword", "Light Shuriken", "Fire Shuriken", "HPUp", "LPUp", "CompHPUp"};
    public Gems gems;
    //The images of the items
    [SerializeField] private Texture2D apple;
    [SerializeField] private Texture2D lightPotion;
    [SerializeField] private Texture2D resurrectPotion;



    //The on land event
    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    //The current data
    private GameObject currentData;

    private void Awake()
    {
        currentData = GameObject.Find("CurrentData");
        //GameDataScript data = SaveScript.LoadGame();
        //currentData.GetComponent<CurrentDataScript>().LoadData(data);
        //We initialize the onLandEvent
        if (OnLandEvent == null) OnLandEvent = new UnityEvent();
        interactable = GameObject.Find("Interactable");
        interactable.SetActive(false);
    }

    void Start()
    {
        //We find the gameobjects and deactivate some of them
        canvas = GameObject.Find("Canvas");
        dialogueManager = GameObject.Find("WorldDialogueManager");
        canvas.GetComponent<WorldCanvasScript>().HideUI();
        restUI = GameObject.Find("Rest");
        restPlayerUI = GameObject.Find("RestPlayer");
        restPlayerMainUI = GameObject.Find("RestPlayerMain");
        restPlayerStatsUI = GameObject.Find("RestPlayerStats");
        restPlayerGemsUI = GameObject.Find("RestPlayerGems");
        restPlayerItemsUI = GameObject.Find("RestPlayerItems");
        restInstructions = GameObject.Find("RestInstructions");
        restInstructionsText = GameObject.Find("RestInstructionsText").GetComponent<Text>();
        restCompanionUI = GameObject.Find("Companions");
        companion = GameObject.Find("CompanionWorld");
        restPlayerGemsUI.SetActive(false);
        restPlayerItemsUI.SetActive(false);
        restPlayerStatsUI.SetActive(false);
        restPlayerUI.SetActive(false);
        restUI.SetActive(false);
        restInstructions.SetActive(false);
        //We initialize the variables
        speedX = 0.0f;
        speedZ = 0.0f;
        fled = false;
        canRest = false;
        movingToRest = false;
        resting = false;
        dialogue = false;
        changingScene = false;
        restUIState = 1;
        restUISelecting = 1;
        restPlayerMainUISelecting = 1;
        restPlayerGemUISelecting = 1;
        restPlayerItemUISelecting = 1;
        restCompanionUISelecting = 0;
        gemUIScroll = 0;
        itemUIScroll = 0;
        //We find the animator
        animator = gameObject.GetComponent<Animator>();
        currentData.GetComponent<CurrentDataScript>().swordStyles = currentData.GetComponent<CurrentDataScript>().lightSword + currentData.GetComponent<CurrentDataScript>().multistrikeSword;
        currentData.GetComponent<CurrentDataScript>().shurikenStyles = currentData.GetComponent<CurrentDataScript>().lightShuriken + currentData.GetComponent<CurrentDataScript>().fireShuriken;
        availableGems = currentData.GetComponent<CurrentDataScript>().lightSwordFound + currentData.GetComponent<CurrentDataScript>().multistrikeSwordFound + currentData.GetComponent<CurrentDataScript>().lightShurikenFound + currentData.GetComponent<CurrentDataScript>().fireShurikenFound + currentData.GetComponent<CurrentDataScript>().HPUpFound + currentData.GetComponent<CurrentDataScript>().LPUpFound + currentData.GetComponent<CurrentDataScript>().compHPUpFound;
        SpentGP();
        if (currentData.GetComponent<CurrentDataScript>().changingScene == 1)
        {
            changingScene = true;
            changedScene = true;
        }
        else
        {
            changingScene = false;
            changedScene = false;
        }
        gameObject.transform.position = new Vector3(currentData.GetComponent<CurrentDataScript>().spawnX, currentData.GetComponent<CurrentDataScript>().spawnY, currentData.GetComponent<CurrentDataScript>().spawnZ);
        companion.transform.position = new Vector3(currentData.GetComponent<CurrentDataScript>().spawnX - 1.0f, currentData.GetComponent<CurrentDataScript>().spawnY, currentData.GetComponent<CurrentDataScript>().spawnZ);
    }


    void Update()
    {
        //Detect the direction we want the player to move and save it
        if (currentData.GetComponent<CurrentDataScript>().battle == 0)
        {
            if (!movingToRest && !resting && !changingScene)
            {
                
                if (currentData.GetComponent<CurrentDataScript>().movUp) speedZ = 1.0f;
                else if (currentData.GetComponent<CurrentDataScript>().movDown) speedZ = -1.0f;
                else speedZ = 0.0f;
                if (currentData.GetComponent<CurrentDataScript>().movRight)
                {
                    speedX = 1.0f;
                    animator.SetBool("RightLast", true);
                }
                else if (currentData.GetComponent<CurrentDataScript>().movLeft)
                {
                    speedX = -1.0f;
                    animator.SetBool("RightLast", false);
                }
                else speedX = 0.0f;
                if (speedX != 0 || speedZ != 0)
                {
                    animator.SetBool("Moving", true);
                    speedX = speedX / (Mathf.Abs(speedX) + Mathf.Abs(speedZ));
                    speedZ = speedZ / (Mathf.Abs(speedX) + Mathf.Abs(speedZ));
                }
                else animator.SetBool("Moving", false);
                animator.SetFloat("SpeedZ", speedZ);
                animator.SetFloat("SpeedX", speedX);
                //make the player attack when X is pressed
                if (Input.GetKeyDown(KeyCode.X) && !attacking && !canRest)
                {
                    attacking = true;
                    animator.SetTrigger("Melee");
                }
                //Make the player jump when space is pressed
                if (Input.GetKeyDown(KeyCode.Space) && grounded && gameObject.GetComponent<Rigidbody>().velocity.y > -0.1f && !attacking)
                {
                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 600.0f, 0.0f));
                    animator.SetBool("isJumping", true);
                }
                //We check if the player is falling
                if (gameObject.GetComponent<Rigidbody>().velocity.y < -0.01f) animator.SetBool("isFalling", true);
                else if (animator.GetBool("isFalling")) animator.SetBool("isFalling", false);

                bool wasGrounded = grounded;
                grounded = false;

                // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
                Collider[] colliders = Physics.OverlapSphere(groundCheck.position, groundedRadius, whatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject && Mathf.Abs(gameObject.GetComponent<Rigidbody>().velocity.y) < 0.01f)
                    {
                        grounded = true;
                        if (!wasGrounded)
                            OnLandEvent.Invoke();
                    }
                }
            }
            else if(movingToRest)
            {
                if (transform.position.x > restPos[0])
                {
                    speedX = -0.4f;
                    speedZ = 0;
                    animator.SetBool("Moving", true);
                }
                else if (transform.position.x < restPos[0])
                {
                    canvas.GetComponent<Animator>().SetBool("Hide",true);
                    speedX = 0;
                    transform.position = new Vector3(restPos[0], transform.position.y, transform.position.z);
                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 600.0f, 0.0f));
                    animator.SetBool("isJumping", true);
                }
                else if (transform.position.x == restPos[0] && transform.position.z < restPos[1])
                {
                    speedX = 0;
                    speedZ = 1.0f;
                    animator.SetBool("Moving", true);
                }
                else if (transform.position.x == restPos[0] && transform.position.z > restPos[1])
                {
                    speedZ = 0;
                    transform.position = new Vector3(restPos[0], transform.position.y, restPos[1]);
                    animator.SetBool("Moving", false);
                }
                else if (transform.position.x == restPos[0] && transform.position.z == restPos[1] && Mathf.Abs(GetComponent<Rigidbody>().velocity.y) < 10.0f)
                {
                    movingToRest = false;
                    animator.SetBool("Resting", true);
                    resting = true;
                    dialogue = true;
                    dialogueManager.GetComponent<DialogueManager>().StartWorldDialogue(firePlace.GetComponent<FirePlaceScript>().dialogue);
                }
                animator.SetFloat("SpeedZ", speedZ);
                animator.SetFloat("SpeedX", speedX);
            }
            else if (changingScene)
            {
                if (changingSceneMov == 0)
                {
                    speedX = -1.0f;
                    speedZ = 0.0f;
                }
                else if (changingSceneMov == 1)
                {
                    speedX = 1.0f;
                    speedZ = 0.0f;
                }
                else if (changingSceneMov == 2)
                {
                    speedX = 0.0f;
                    speedZ = 1.0f;
                }
                else if (changingSceneMov == 3)
                {
                    speedX = 0.0f;
                    speedZ = -1.0f;
                }
                animator.SetFloat("SpeedX", speedX);
                animator.SetFloat("SpeedZ", speedZ);
                animator.SetBool("Moving", true);

                bool wasGrounded = grounded;
                grounded = false;

                // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
                Collider[] colliders = Physics.OverlapSphere(groundCheck.position, groundedRadius, whatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject && Mathf.Abs(gameObject.GetComponent<Rigidbody>().velocity.y) < 0.01f)
                    {
                        grounded = true;
                        if (!wasGrounded)
                            OnLandEvent.Invoke();
                    }
                }
                if (changedScene && currentData.GetComponent<CurrentDataScript>().changingScene == 0)
                {
                    changingScene = false;
                    changedScene = false;
                }
            }
            if (resting)
            {
                if (dialogue)
                {
                    if (Input.GetKeyDown(KeyCode.X)) dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
                }
                else
                {
                    if (restUIState == 1)
                    {
                        if (Input.GetKeyDown(KeyCode.LeftArrow) && restUISelecting > 1)
                        {
                            restUISelecting -= 1;
                            restUI.GetComponent<Animator>().SetInteger("Pos",restUISelecting);
                            UpdateRestInstructionText();
                        }
                        else if (Input.GetKeyDown(KeyCode.RightArrow) && restUISelecting < 3)
                        {
                            restUISelecting += 1;
                            restUI.GetComponent<Animator>().SetInteger("Pos", restUISelecting);
                            UpdateRestInstructionText();
                        }
                        else if (Input.GetKeyDown(KeyCode.X))
                        {
                            restUI.GetComponent<Animator>().SetInteger("Pos", 0);
                            if (restUISelecting == 1)
                            {
                                restPlayerUI.SetActive(true);
                                restPlayerMainUI.GetComponent<Animator>().SetInteger("Pos", restPlayerMainUISelecting);
                                restUIState = 2;
                                UpdateRestInstructionText();
                            }
                            else if (restUISelecting == 2)
                            {
                                restUIState = 6;
                                UpdateRestInstructionText();
                                currentData.GetComponent<CurrentDataScript>().spawnX = firePlace.transform.position.x;
                                currentData.GetComponent<CurrentDataScript>().spawnY = firePlace.transform.position.y - 0.8f;
                                currentData.GetComponent<CurrentDataScript>().spawnZ = firePlace.transform.position.z - 0.4f;
                                SaveScript.SaveGame(currentData.GetComponent<CurrentDataScript>()); 
                                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Se ha guardado la partida";
                                else restInstructionsText.text = "";

                            }
                            else if (restUISelecting == 3)
                            {
                                restCompanionUISelecting = 1;
                                restCompanionUI.GetComponent<Animator>().SetInteger("Pos", restCompanionUISelecting);
                                restCompanionUI.transform.GetChild(2).GetComponent<StatsPlayerLife>().UpdateStats();
                                restCompanionUI.transform.GetChild(3).GetComponent<StatsPlayerLife>().UpdateStats();
                                restUIState = 7;
                                UpdateRestInstructionText();
                            }
                        }
                        else if (Input.GetKeyDown(KeyCode.Q))
                        {
                            canvas.GetComponent<Animator>().SetBool("Hide", false);
                            resting = false;
                            restUI.GetComponent<Animator>().SetInteger("Pos", 0);
                            restInstructions.SetActive(false);
                            animator.SetBool("Resting", false);
                            transform.position = new Vector3(transform.position.x + 0.45f, transform.position.y - 0.45f, transform.position.z);
                        }
                    }
                    else if(restUIState == 2)
                    {
                        if(Input.GetKeyDown(KeyCode.UpArrow) && restPlayerMainUISelecting > 1)
                        {
                            restPlayerMainUISelecting -= 1;
                            restPlayerMainUI.GetComponent<Animator>().SetInteger("Pos", restPlayerMainUISelecting);
                            UpdateRestInstructionText();
                        }
                        else if (Input.GetKeyDown(KeyCode.DownArrow) && restPlayerMainUISelecting < 3)
                        {
                            restPlayerMainUISelecting += 1;
                            restPlayerMainUI.GetComponent<Animator>().SetInteger("Pos", restPlayerMainUISelecting);
                            UpdateRestInstructionText();
                        }
                        else if (Input.GetKeyDown(KeyCode.X))
                        {
                            restPlayerMainUI.GetComponent<Animator>().SetInteger("Pos", 0);
                            if (restPlayerMainUISelecting == 1)
                            {
                                restPlayerStatsUI.SetActive(true);
                                restPlayerStatsUI.transform.GetChild(2).GetComponent<StatsPlayerLife>().UpdateStats();
                                restPlayerStatsUI.transform.GetChild(3).GetComponent<LightPointsScript>().UpdateLight();
                                restPlayerStatsUI.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = (currentData.GetComponent<CurrentDataScript>().playerBadgeLvl * 3 + 3).ToString();
                                restPlayerStatsUI.transform.GetChild(5).GetComponent<StatsPlayerXPCoins>().UpdateStats();
                                restUIState = 3;
                            }
                            else if (restPlayerMainUISelecting == 2)
                            {
                                restPlayerGemsUI.SetActive(true);
                                restPlayerGemsUI.transform.GetChild(1).GetComponent<Text>().text = ((currentData.GetComponent<CurrentDataScript>().playerBadgeLvl * 3 + 3) - currentData.GetComponent<CurrentDataScript>().spentGP).ToString();
                                restPlayerGemsUI.transform.GetChild(3).GetComponent<Text>().text = (currentData.GetComponent<CurrentDataScript>().playerBadgeLvl * 3 + 3).ToString();
                                restUIState = 4; 
                                CreateGemUI();
                            }
                            else if (restPlayerMainUISelecting == 3)
                            {
                                restPlayerItemsUI.SetActive(true);
                                restUIState = 5;
                                restPlayerItemsUI.transform.GetChild(1).GetComponent<Text>().text = itemSize().ToString();
                                CreateItemsUI();
                            }
                            UpdateRestInstructionText();
                        } 
                        else if (Input.GetKeyDown(KeyCode.Q))
                        {
                            restPlayerMainUI.GetComponent<Animator>().SetInteger("Pos", 0);
                            restUI.GetComponent<Animator>().SetInteger("Pos", restUISelecting);
                            restPlayerUI.SetActive(false);
                            restUIState = 1;
                            UpdateRestInstructionText();
                        }
                    }
                    else if(restUIState == 3)
                    {
                        if (Input.GetKeyDown(KeyCode.Q))
                        {
                            restPlayerStatsUI.SetActive(false);
                            restPlayerMainUI.GetComponent<Animator>().SetInteger("Pos", restPlayerMainUISelecting);
                            restUIState = 2;
                            UpdateRestInstructionText();
                        }
                    }
                    else if (restUIState == 4)
                    {
                        if (Input.GetKeyDown(KeyCode.UpArrow) && (restPlayerGemUISelecting > 1 || gemUIScroll > 0))
                        {
                            if(gemUIScroll>0 && restPlayerGemUISelecting == 1)
                            {
                                gemUIScroll -= 1;
                                CreateGemUI();
                            }
                            else
                            {
                                restPlayerGemUISelecting -= 1;
                                restPlayerGemsUI.GetComponent<Animator>().SetInteger("Pos", restPlayerGemUISelecting);
                            }
                            UpdateRestInstructionText();
                        }
                        else if (Input.GetKeyDown(KeyCode.DownArrow) && (restPlayerGemUISelecting < 6 || gemUIScroll + 6 < availableGems))
                        {
                            if (restPlayerGemUISelecting == 6 && gemUIScroll + 6 < availableGems)
                            {
                                gemUIScroll += 1;
                                CreateGemUI();
                            }
                            else
                            {
                                restPlayerGemUISelecting += 1;
                                restPlayerGemsUI.GetComponent<Animator>().SetInteger("Pos", restPlayerGemUISelecting);
                            }
                            UpdateRestInstructionText();
                        }
                        if (Input.GetKeyDown(KeyCode.X))
                        {
                            if (currentData.GetComponent<CurrentDataScript>().GemUsing(allGems[FindGemInPos(restPlayerGemUISelecting + gemUIScroll) - 1],allGems) == 1)
                            {
                                currentData.GetComponent<CurrentDataScript>().SetGemUsing(allGems[FindGemInPos(restPlayerGemUISelecting + gemUIScroll) - 1], allGems, 0);
                                currentData.GetComponent<CurrentDataScript>().swordStyles = currentData.GetComponent<CurrentDataScript>().lightSword + currentData.GetComponent<CurrentDataScript>().multistrikeSword;
                                currentData.GetComponent<CurrentDataScript>().shurikenStyles = currentData.GetComponent<CurrentDataScript>().lightShuriken + currentData.GetComponent<CurrentDataScript>().fireShuriken;
                                canvas.GetComponent<WorldCanvasScript>().UpdateStats();
                                SpentGP();
                                CreateGemUI();
                                restPlayerGemsUI.transform.GetChild(1).GetComponent<Text>().text = ((currentData.GetComponent<CurrentDataScript>().playerBadgeLvl * 3 + 3) - currentData.GetComponent<CurrentDataScript>().spentGP).ToString();
                            }
                            else if (gems.gems[FindGemInPos(restPlayerGemUISelecting + gemUIScroll)- 1].points <= ((currentData.GetComponent<CurrentDataScript>().playerBadgeLvl * 3 + 3) - currentData.GetComponent<CurrentDataScript>().spentGP))
                            {

                                currentData.GetComponent<CurrentDataScript>().SetGemUsing(allGems[FindGemInPos(restPlayerGemUISelecting + gemUIScroll) - 1], allGems, 1);
                                currentData.GetComponent<CurrentDataScript>().swordStyles = currentData.GetComponent<CurrentDataScript>().lightSword + currentData.GetComponent<CurrentDataScript>().multistrikeSword;
                                currentData.GetComponent<CurrentDataScript>().shurikenStyles = currentData.GetComponent<CurrentDataScript>().lightShuriken + currentData.GetComponent<CurrentDataScript>().fireShuriken;
                                canvas.GetComponent<WorldCanvasScript>().UpdateStats();
                                SpentGP();
                                CreateGemUI();
                                restPlayerGemsUI.transform.GetChild(1).GetComponent<Text>().text = ((currentData.GetComponent<CurrentDataScript>().playerBadgeLvl * 3 + 3) - currentData.GetComponent<CurrentDataScript>().spentGP).ToString();
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.Q))
                        {
                            gemUIScroll = 0;
                            restPlayerGemUISelecting = 1;
                            restPlayerGemsUI.SetActive(false);
                            restPlayerMainUI.GetComponent<Animator>().SetInteger("Pos", restPlayerMainUISelecting);
                            restUIState = 2;
                            UpdateRestInstructionText();
                        }
                    }
                    else if (restUIState == 5)
                    {
                        if (Input.GetKeyDown(KeyCode.UpArrow) && (restPlayerItemUISelecting > 1 || itemUIScroll > 0))
                        {
                            if (itemUIScroll > 0 && restPlayerItemUISelecting == 1)
                            {
                                itemUIScroll -= 1;
                                CreateItemsUI();
                            }
                            else
                            {
                                restPlayerItemUISelecting -= 1;
                                restPlayerItemsUI.GetComponent<Animator>().SetInteger("Pos", restPlayerItemUISelecting);
                            }
                            UpdateRestInstructionText();
                        }
                        else if (Input.GetKeyDown(KeyCode.DownArrow) && (restPlayerItemUISelecting < 6 || itemUIScroll + 6 < itemSize()))
                        {
                            if (restPlayerItemUISelecting == 6 && itemUIScroll + 6 < itemSize())
                            {
                                itemUIScroll += 1;
                                CreateItemsUI();
                            }
                            else
                            {
                                restPlayerItemUISelecting += 1;
                                restPlayerItemsUI.GetComponent<Animator>().SetInteger("Pos", restPlayerItemUISelecting);
                            }
                            UpdateRestInstructionText();
                        }
                        if (Input.GetKeyDown(KeyCode.Q))
                        {
                            itemUIScroll = 0;
                            restPlayerItemUISelecting = 1;
                            restPlayerItemsUI.SetActive(false);
                            restPlayerMainUI.GetComponent<Animator>().SetInteger("Pos", restPlayerMainUISelecting);
                            restUIState = 2;
                            UpdateRestInstructionText();
                        }
                    }
                    else if (restUIState == 6)
                    {
                        if (Input.GetKeyDown(KeyCode.Q))
                        {
                            restUI.GetComponent<Animator>().SetInteger("Pos", restUISelecting);
                            restUIState = 1;
                            UpdateRestInstructionText();
                        }
                    }
                    else if(restUIState == 7)
                    {
                        if (Input.GetKeyDown(KeyCode.DownArrow) && restCompanionUISelecting<2)
                        {
                            restCompanionUISelecting += 1;
                            restCompanionUI.GetComponent<Animator>().SetInteger("Pos", restCompanionUISelecting);
                            UpdateRestInstructionText();
                        }
                        else if (Input.GetKeyDown(KeyCode.UpArrow) && restCompanionUISelecting > 1)
                        {
                            restCompanionUISelecting -= 1;
                            restCompanionUI.GetComponent<Animator>().SetInteger("Pos", restCompanionUISelecting);
                            UpdateRestInstructionText();
                        }
                        else if(Input.GetKeyDown(KeyCode.X))
                        {
                            if(currentData.GetComponent<CurrentDataScript>().currentCompanion != restCompanionUISelecting)
                            {
                                companion.GetComponent<WorldCompanionMovementScript>().ChangeCompanion(restCompanionUISelecting); 
                                restUIState = 1;
                                restCompanionUISelecting = 0;
                                restCompanionUI.GetComponent<Animator>().SetInteger("Pos", restCompanionUISelecting);
                                restUI.GetComponent<Animator>().SetInteger("Pos", restUISelecting);
                            }
                        }
                        else if (Input.GetKeyDown(KeyCode.Q))
                        {
                            restUIState = 1;
                            restCompanionUISelecting = 0;
                            restCompanionUI.GetComponent<Animator>().SetInteger("Pos", restCompanionUISelecting);
                            restUI.GetComponent<Animator>().SetInteger("Pos", restUISelecting);
                            UpdateRestInstructionText();
                        }
                    }
                }
            }
        }
        if (currentData.GetComponent<CurrentDataScript>().fled == 1 && currentData.GetComponent<CurrentDataScript>().battle == 0)
        {
            GetComponent<Animator>().SetTrigger("Fleeing");
            currentData.GetComponent<CurrentDataScript>().fled = 0;
            fled = true;
            fledTime = Time.fixedTime;
        }
        if ((Time.fixedTime - fledTime) >= 3.05f) fled = false;
        if (canRest && Input.GetKeyDown(KeyCode.X))
        {
            movingToRest = true;
            SetCanRest(false);
            companion.GetComponent<WorldCompanionMovementScript>().TpToPlayerScene(2);
        }
    }

    private void FixedUpdate()
    {
        //move the player on the direction we saved previously
        if(!attacking && currentData.GetComponent<CurrentDataScript>().battle == 0) gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speedX * 4, gameObject.GetComponent<Rigidbody>().velocity.y, speedZ * 4);
        else gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, gameObject.GetComponent<Rigidbody>().velocity.y, 0.0f);
        
    }

    public bool IsFleeing()
    {
        return fled;
    }

    private void OnlyShadows()
    {
        GetComponent<SpriteRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
    }

    private void NormalSprite()
    {
        GetComponent<SpriteRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.TwoSided;
    }

    //Function to know where the melee attack is directed. 0-> right, 1-> left, 2 -> up, 3-> down
    public void MeleeDirection(int d)
    {
        dir = d;
    }

    public void StartMelee()
    {
        if(dir == 0) melee = Instantiate(meleePrefab, new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z), Quaternion.identity);
        else if (dir == 1) melee = Instantiate(meleePrefab, new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z), Quaternion.identity);
        else if (dir == 2) melee = Instantiate(meleePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.0f), Quaternion.identity);
        else if (dir == 3) melee = Instantiate(meleePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.0f), Quaternion.identity);
    }

    public void EndMelee()
    {
        attacking = false;
        Destroy(melee.gameObject);
    }

    //When the player lands we uncheck the jumping and falling booleans
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", false);
    }

    //Function to know if the player is grounded
    public bool IsGrounded()
    {
        return grounded;
    }

    //Function to set the rest bool
    public void SetCanRest(bool rest)
    {
        canRest = rest;
        interactable.SetActive(rest);
    }

    //Function to set the rest position
    public void SetRestPosition(float restX, float restZ)
    {
        restPos = new Vector2(restX, restZ);
    }

    //Function to show the rest UI
    public void ShowRestUI()
    {
        restUI.SetActive(true);
        restInstructions.SetActive(true);
        dialogue = false;
        UpdateRestInstructionText();
        restUISelecting = 1;
        restUI.GetComponent<Animator>().SetInteger("Pos", restUISelecting);
    }

    //Function to set the X position of the fire place
    public void SetFireXPos(float xPos)
    {
        fireX = xPos;
    }

    //Function to save the spent GP
    public void SpentGP()
    {
        int spent = 0;
        for (int i = 0; i<allGems.Length; i++)
        {
            spent = spent + currentData.GetComponent<CurrentDataScript>().GemUsing(allGems[i],allGems) * gems.gems[i].points;
        }
        currentData.GetComponent<CurrentDataScript>().spentGP = spent;
    }

    //Function to change the rest instruction text
    public void UpdateRestInstructionText()
    {
        if (restUIState == 1)
        {
            if (restUISelecting == 1)
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Mira las estadísticas, cambia las gemas o comprueba tus objetos.";
                else restInstructionsText.text = "";
            }
            else if (restUISelecting == 2)
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Guarda la partida.";
                else restInstructionsText.text = "";
            }
            else
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Cambia de compañero.";
                else restInstructionsText.text = "";
            }
        }
        else if (restUIState == 2)
        {
            if (restPlayerMainUISelecting == 1)
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Mira las estadísticas del jugador.";
                else restInstructionsText.text = "";
            }
            else if (restPlayerMainUISelecting == 2)
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Cambia las gemas equipadas.";
                else restInstructionsText.text = "";
            }
            else
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Comprueba tus objetos.";
                else restInstructionsText.text = "";
            }
        }
        else if (restUIState == 3)
        {
            if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
            else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Aquí puedes ver las estadísticas del jugador, desde los puntos de alma disponibles en el momento hasta la experiencia y las monedas.";
            else restInstructionsText.text = "";
        }
        else if (restUIState == 4)
        {
            if (FindGemInPos(restPlayerGemUISelecting + gemUIScroll) == 1)
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Permite al jugador usar la espada de luz, un poderoso ataque de un único golpe que cuesta 1 PL.";
                else restInstructionsText.text = "";
            }
            else if (FindGemInPos(restPlayerGemUISelecting + gemUIScroll) == 2)
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Permite al jugador usar la espada de multiataque, un ataque que permite golpear repetidamente a un enemigo por 2 PL.";
                else restInstructionsText.text = "";
            }
            else if (FindGemInPos(restPlayerGemUISelecting + gemUIScroll) == 3)
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Permite al jugador usar el shuriken de luz, que permite lanzar un shuriken con poder de luz que cuesta 1 PL.";
                else restInstructionsText.text = "";
            }
            else if (FindGemInPos(restPlayerGemUISelecting + gemUIScroll) == 4)
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Permite al jugador usar el shuriken de fuego, que permite dañar a todos los enemigos que se encuentran en el suelo por 2PL.";
                else restInstructionsText.text = "";
            }
            else if (FindGemInPos(restPlayerGemUISelecting + gemUIScroll) == 5)
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Aumenta los puntos de vida del jugador en 5.";
                else restInstructionsText.text = "";
            }
            else if (FindGemInPos(restPlayerGemUISelecting + gemUIScroll) == 6)
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Aumenta los puntos de luz del jugador en 5.";
                else restInstructionsText.text = "";
            }
            else
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Aumenta los puntos de vida de los compañeros en 5.";
                else restInstructionsText.text = "";
            }
        }
        else if (restUIState == 5)
        {
            if (currentData.GetComponent<CurrentDataScript>().items[restPlayerItemUISelecting + itemUIScroll - 1] == 1)
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Una manzana que cura 5 puntos de vida.";
                else restInstructionsText.text = "";
            }
            else if (currentData.GetComponent<CurrentDataScript>().items[restPlayerItemUISelecting + itemUIScroll - 1] == 2)
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Una poción que regenera 5 puntos de luz.";
                else restInstructionsText.text = "";
            }
            else if (currentData.GetComponent<CurrentDataScript>().items[restPlayerItemUISelecting + itemUIScroll - 1] == 3)
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Una poción que revive al usuario que la tome curándole 10 puntos de vida.";
                else restInstructionsText.text = "";
            }
        }
        else if (restUIState == 6) 
        {
            if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
            else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Guardando la partida...";
            else restInstructionsText.text = "";
        }
        else if (restUIState == 7)
        {
            if (restCompanionUISelecting == 1)
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Un aventurero que puede atacar usando sus armas o fijarse en los enemigos para ver sus puntos débiles.";
                else restInstructionsText.text = "";
            }
            else
            {
                if (currentData.GetComponent<CurrentDataScript>().language == 1) restInstructionsText.text = "";
                else if (currentData.GetComponent<CurrentDataScript>().language == 2) restInstructionsText.text = "Un mago experto en recibir golpes que también puede atacar usando sus hechizos mágicos.";
                else restInstructionsText.text = "";
            }
        }
    }
    
    //Function to create the gem UI
    public void CreateGemUI()
    {
        //We hide or show the arrows depending on the scroll
        if (gemUIScroll > 0) restPlayerGemsUI.transform.GetChild(11).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        else restPlayerGemsUI.transform.GetChild(11).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        if ((gemUIScroll + 6) < availableGems) restPlayerGemsUI.transform.GetChild(12).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        else restPlayerGemsUI.transform.GetChild(12).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        //We search the gems for all the available spaces, if there are less than 6 we make those spaces disappear
        for (int i = 1; i < 7; i++)
        {
            if (i < availableGems + 1)
            {
                if(currentData.GetComponent<CurrentDataScript>().GemUsing(allGems[FindGemInPos(i) + gemUIScroll - 1],allGems)==1) restPlayerGemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(0.0f, 1.0f, 0.0f, 1.0f);
                else if(gems.gems[FindGemInPos(i) + gemUIScroll - 1].points > ((currentData.GetComponent<CurrentDataScript>().playerBadgeLvl * 3 + 3) - currentData.GetComponent<CurrentDataScript>().spentGP)) restPlayerGemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
                else restPlayerGemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = gems.gems[FindGemInPos(i) + gemUIScroll - 1].nameSpanish[0];
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().texture = gems.gems[FindGemInPos(i) + gemUIScroll - 1].icon;
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(2).GetComponent<Text>().text = "PG " + gems.gems[FindGemInPos(i) + gemUIScroll - 1].points.ToString();
            }
            else
            {
                restPlayerGemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
            }
        }
    }
    
    //Function to create the items UI
    public void CreateItemsUI()
    {
        //We hide or show the arrows depending on the scroll
        if (itemUIScroll > 0) restPlayerItemsUI.transform.GetChild(11).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        else restPlayerItemsUI.transform.GetChild(11).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        if ((itemUIScroll + 6) < itemSize()) restPlayerItemsUI.transform.GetChild(12).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        else restPlayerItemsUI.transform.GetChild(12).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        if (itemSize() > 5)
        {
            for (int i = 1; i < 7; i++)
            {
                if (i < itemSize() + 1)
                {
                    restPlayerItemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    if (currentData.GetComponent<CurrentDataScript>().items[i + itemUIScroll - 1] == 1)
                    {
                        restPlayerItemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        restPlayerItemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        restPlayerItemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().texture = apple;
                        if (currentData.GetComponent<CurrentDataScript>().language == 1) restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = "Apple";
                        else if (currentData.GetComponent<CurrentDataScript>().language == 2) restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = "Manzana";
                        else restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = "Sagarra";
                    }
                    else if (currentData.GetComponent<CurrentDataScript>().items[i + itemUIScroll - 1] == 2)
                    {
                        restPlayerItemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        restPlayerItemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        restPlayerItemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().texture = lightPotion;
                        if (currentData.GetComponent<CurrentDataScript>().language == 1) restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = "Light potion";
                        else if (currentData.GetComponent<CurrentDataScript>().language == 2) restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = "Poción de luz";
                        else restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = "Argi pozioa";
                    }
                    else if (currentData.GetComponent<CurrentDataScript>().items[i + itemUIScroll - 1] == 3)
                    {
                        restPlayerItemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        restPlayerItemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        restPlayerItemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().texture = resurrectPotion;
                        if (currentData.GetComponent<CurrentDataScript>().language == 1) restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = "Resurrection potion";
                        else if (currentData.GetComponent<CurrentDataScript>().language == 2) restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = "Poción de resurrección";
                        else restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = "Berpizkunde pozioa";
                    }
                }
                else
                {
                    restPlayerItemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    restPlayerItemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    restPlayerItemsUI.transform.GetChild(4 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                }
            }
        }
    }

    //Function to find the gem of the x position
    public int FindGemInPos(int x)
    {
        bool found = false;
        int pos = 0;
        int y = 0;
        while (!found && pos < 7)
        {
            if (currentData.GetComponent<CurrentDataScript>().GemFound(allGems[pos] + " Found",allGems) == 1) y += 1;
            if (y == x) found = true;
            pos += 1;
        }
        if (!found) return -1;
        else return pos;
    }

    //Function to set the player to the changing scene state and the movement direction
    public void SetChangingScene(int mov)
    {
        if (currentData.GetComponent<CurrentDataScript>().changingScene == 0)
        {
            changingScene = true;
            changingSceneMov = mov;
        }
        else
        {
            if (mov == 0) changingSceneMov = 1;
            else if (mov == 1) changingSceneMov = 0;
            else if (mov == 2) changingSceneMov = 3;
            else if (mov == 3) changingSceneMov = 2;
            companion.GetComponent<WorldCompanionMovementScript>().TpToPlayerScene(changingSceneMov);
        }
    }

    //Function to get if the player is changing scene
    public bool GetChangingScene()
    {
        return changingScene;
    }

    //Function to get the X position of the fire place
    public float GetFireXPos()
    {
        return fireX;
    }

    //Function to get if the player is moving to rest
    public bool GetMovingToRest()
    {
        return movingToRest;
    }

    //Function to get if the player is resting
    public bool GetResting()
    {
        return resting;
    }

    //Function to set the fireplace
    public void SetFirePlace(GameObject place)
    {
        firePlace = place;
    }

    //Function to get the fireplace
    public GameObject GetFirePlace()
    {
        return firePlace;
    }

    //Function to know the number of items the player has
    private int itemSize()
    {
        int i = 0;
        while (currentData.GetComponent<CurrentDataScript>().items[i] != 0 && i < 19)
        {
            i++;
        }
        return i;
    }

}
