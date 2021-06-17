using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    //A boolean to know if the player is speaking
    private bool speaking;
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
    //A boolean to know if the player can start a conversation
    private bool canSpeak;
    //The dialogue manager
    private GameObject dialogueManager;
    //A boolean to know if the player is in a dialogue
    private bool dialogue;
    //The dialogue that will be displayed
    private Dialogue nextDialogue;
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
    //The shop UI
    private GameObject shopUI;
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
    //An int to know what option we are selecting on the shop main menu
    private int shopMainSelecting;
    //An int to know what option we are selecting on the shop buy menu
    private int shopBuySelecting;
    //An int to know the scroll on the buy shop
    private int shopBuyScroll;
    //An int to know what option we are selecting on the shop sell menu
    private int shopSellSelecting;
    //An int to know the scroll on the sell shop
    private int shopSellScroll;
    //An int to know what option we are selecting on the shop deposit menu
    private int shopDepositSelecting;
    //An int to know the scroll on the deposit shop
    private int shopDepositScroll;
    //An int to know what option we are selecting on the shop pick up menu
    private int shopPickUpSelecting;
    //An int to know the scroll on the pick up shop
    private int shopPickUpScroll;
    //An int to know what option we are selecting on the shop confirm menu
    private int shopConfirmSelecting;
    //A bool to know if the shop UI is opened
    private bool shopOpened;
    //A bool to know if the shop main UI is opened
    private bool shopMainOpened;
    //A bool to know if the shop buy UI is opened
    private bool shopBuyOpened;
    //A bool to know if the shop sell UI is opened
    private bool shopSellOpened;
    //A bool to know if we are buying or selling gems
    private bool shopGems;
    //A bool to know if there are any gems to buy in this shop
    private bool shopGemsNotEmpty;
    //A bool to know if the shop deposit UI is opened
    private bool shopDepositOpened;
    //A bool to know if the shop pick up UI is opened
    private bool shopPickUpOpened;
    //A bool to know if the player is in the confirm window of the shop
    private bool shopConfirming;
    private Item[] shopItems;
    //An int to know the number of shop gems found 
    private int pastItems;
    //An array with all the gems
    private string[] allGems = {"Light Sword", "Multistrike Sword", "Light Shuriken", "Fire Shuriken", "HPUp", "LPUp", "CompHPUp"};
    public Gems gems;
    //The images of the items
    [SerializeField] private Texture2D apple;
    [SerializeField] private Texture2D lightPotion;
    [SerializeField] private Texture2D resurrectPotion;
    //The object we are picking
    private GameObject pickedObject;
    //A boolean to know that we have to throw an item
    private bool fullItems;
    //A boolean to know that the player is choosing the item to thow
    private bool throwingItem;
    //An int to know what option are we selecting on the throw item menu.
    private int throwingItemSelecting;
    //An int to know the number of the item UI scroll
    private int throwItemUIScroll;
    //A boolean to know if the player is showing the item to the right
    private bool itemRight;
    //An int to know the id of the thrown item
    private int thrownItemID;
    //The sprites of the items
    [SerializeField] private Sprite appleItem;
    [SerializeField] private Sprite lightPotionItem;
    [SerializeField] private Sprite resurrectPotionItem;
    //A boolean to know if the player is picking an object
    private bool pickingObject;
    //A boolean to know if the player is showing the item
    private bool showItem;
    //The pick item UI
    private GameObject pickItemUI;
    //The battle first strike UI
    private GameObject firstStrikeUI;


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
        pickItemUI = GameObject.Find("PickItem");
        restInstructions = GameObject.Find("RestInstructions");
        restInstructionsText = GameObject.Find("RestInstructionsText").GetComponent<Text>();
        restCompanionUI = GameObject.Find("Companions");
        firstStrikeUI = GameObject.Find("BattleFirstStrike");
        companion = GameObject.Find("CompanionWorld");
        shopUI = GameObject.Find("Shop");
        restPlayerGemsUI.SetActive(false);
        restPlayerItemsUI.SetActive(false);
        restPlayerStatsUI.SetActive(false);
        restPlayerUI.SetActive(false);
        restUI.SetActive(false);
        restInstructions.SetActive(false);
        pickItemUI.SetActive(false);
        firstStrikeUI.SetActive(false);
        shopUI.SetActive(false);
        //We initialize the variables
        speedX = 0.0f;
        speedZ = 0.0f;
        fled = false;
        canRest = false;
        movingToRest = false;
        resting = false;
        dialogue = false;
        canSpeak = false;
        speaking = false;
        changingScene = false;
        pickingObject = false;
        showItem = false;
        fullItems = false;
        throwingItem = false;
        itemRight = false;
        shopOpened = false;
        shopMainOpened = true;
        shopBuyOpened = false;
        shopSellOpened = false;
        shopDepositOpened = false;
        shopPickUpOpened = false;
        shopConfirming = false;
        shopGems = false;
        shopGemsNotEmpty = false;
        restUIState = 1;
        restUISelecting = 1;
        restPlayerMainUISelecting = 1;
        restPlayerGemUISelecting = 1;
        restPlayerItemUISelecting = 1;
        restCompanionUISelecting = 0;
        throwingItemSelecting = 0;
        throwItemUIScroll = 0;
        shopMainSelecting = 1;
        shopBuySelecting = 1;
        shopConfirmSelecting = 0;
        shopSellSelecting = 1;
        shopDepositSelecting = 1;
        shopPickUpSelecting = 1;
        shopBuyScroll = 0;
        shopSellScroll = 0;
        shopDepositScroll = 0;
        shopPickUpScroll = 0;
        gemUIScroll = 0;
        itemUIScroll = 0;
        //We find the animator
        animator = gameObject.GetComponent<Animator>();
        currentData.GetComponent<CurrentDataScript>().swordStyles = currentData.GetComponent<CurrentDataScript>().lightSword + currentData.GetComponent<CurrentDataScript>().multistrikeSword;
        currentData.GetComponent<CurrentDataScript>().shurikenStyles = currentData.GetComponent<CurrentDataScript>().lightShuriken + currentData.GetComponent<CurrentDataScript>().fireShuriken;
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
            if (!movingToRest && !resting && !changingScene && !speaking && !pickingObject && !shopOpened)
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
                if (Input.GetKeyDown(KeyCode.X) && !attacking && !canRest && !canSpeak)
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
                //If the E key is pressed we starts the special ability of the companion
                if (Input.GetKeyDown(KeyCode.E) && grounded && !attacking)
                {
                    if (currentData.GetComponent<CurrentDataScript>().currentCompanion == 1)
                    {
                        canvas.GetComponent<Animator>().SetBool("Hide", true);
                        dialogue = true;
                        speaking = true; 
                        if(canSpeak) dialogueManager.GetComponent<DialogueManager>().StartWorldDialogue(new Dialogue(companion.transform, new string[] { "adventurer_explanation_" + SceneManager.GetActiveScene().name + "_" + nextDialogue.speaker.gameObject.name }));
                        else dialogueManager.GetComponent<DialogueManager>().StartWorldDialogue(new Dialogue(companion.transform, new string[] { "adventurer_explanation_" + SceneManager.GetActiveScene().name}));
                    }
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
            if (pickingObject)
            {
                speedX = 0.0f;
                speedZ = 0.0f;
                animator.SetBool("Moving", false);
                animator.SetFloat("SpeedZ", speedZ);
                animator.SetFloat("SpeedX", speedX);
                if (throwingItem)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow) && (throwingItemSelecting > 0 || throwItemUIScroll > 0))
                    {
                        if (throwItemUIScroll > 0 && throwingItemSelecting == 1)
                        {
                            throwItemUIScroll -= 1;
                            CreateThrowItemUI();
                        }
                        else
                        {
                            throwingItemSelecting -= 1;
                            pickItemUI.transform.GetChild(4).GetComponent<Animator>().SetInteger("Pos", throwingItemSelecting);
                        }
                        if (throwingItemSelecting > 0)
                        {
                            if (currentData.GetComponent<CurrentDataScript>().items[throwingItemSelecting + throwItemUIScroll - 1] == 1) pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_apple");
                            else if (currentData.GetComponent<CurrentDataScript>().items[throwingItemSelecting + throwItemUIScroll - 1] == 2) pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_lightpotion");
                            else if (currentData.GetComponent<CurrentDataScript>().items[throwingItemSelecting + throwItemUIScroll - 1] == 3) pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_resurrectpotion");
                        }
                        else
                        {
                            if (pickedObject.GetComponent<WorldObjectScript>().GetId() == 1) pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_apple");
                            else if (pickedObject.GetComponent<WorldObjectScript>().GetId() == 2) pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_lightpotion");
                            else if (pickedObject.GetComponent<WorldObjectScript>().GetId() == 3) pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_resurrectpotion");
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow) && (throwingItemSelecting < 6 || throwItemUIScroll + 6 < currentData.GetComponent<CurrentDataScript>().itemSize()))
                    {
                        if (throwingItemSelecting == 6 && throwItemUIScroll + 6 < currentData.GetComponent<CurrentDataScript>().itemSize())
                        {
                            throwItemUIScroll += 1;
                            CreateThrowItemUI();
                        }
                        else
                        {
                            throwingItemSelecting += 1;
                            pickItemUI.transform.GetChild(4).GetComponent<Animator>().SetInteger("Pos", throwingItemSelecting);
                        }
                        if (currentData.GetComponent<CurrentDataScript>().items[throwingItemSelecting + throwItemUIScroll - 1] == 1) pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_apple");
                        else if (currentData.GetComponent<CurrentDataScript>().items[throwingItemSelecting + throwItemUIScroll - 1] == 2) pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_lightpotion");
                        else if (currentData.GetComponent<CurrentDataScript>().items[throwingItemSelecting + throwItemUIScroll - 1] == 3) pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_resurrectpotion");
                    }
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        pickedObject.transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
                        pickedObject.GetComponent<BoxCollider>().enabled = true;
                        pickedObject.GetComponent<SphereCollider>().enabled = true;
                        pickedObject.GetComponent<Rigidbody>().useGravity = true;
                        pickedObject.GetComponent<WorldObjectScript>().SetPicked(false); 
                        pickItemUI.transform.GetChild(0).gameObject.SetActive(true);
                        pickItemUI.transform.GetChild(2).gameObject.SetActive(true);
                        pickItemUI.transform.GetChild(3).gameObject.SetActive(false);
                        pickItemUI.transform.GetChild(4).gameObject.SetActive(false);
                        throwingItem = false;
                        animator.SetBool("Pick", false);
                        showItem = false;
                        pickingObject = false;
                        pickItemUI.transform.GetChild(4).GetComponent<Animator>().SetInteger("Pos", 0);
                        pickItemUI.transform.GetChild(4).GetComponent<Animator>().SetTrigger("Reset");
                        pickItemUI.SetActive(false);
                        if (itemRight)
                        {
                            pickedObject.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y + 0.52f, transform.position.z);
                            pickedObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0.0f, 3.0f), Random.Range(5.0f, 10.0f), Random.Range(-5.0f, 5.0f));
                        }
                        else
                        {
                            pickedObject.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y + 0.52f, transform.position.z);
                            pickedObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-3.0f, 0.0f), Random.Range(5.0f, 10.0f), Random.Range(-5.0f, 5.0f));
                        }                        
                        if (throwingItemSelecting > 0)
                        {
                            thrownItemID = currentData.GetComponent<CurrentDataScript>().items[throwingItemSelecting + throwItemUIScroll - 1];
                            currentData.GetComponent<CurrentDataScript>().DeleteItem(throwingItemSelecting + throwItemUIScroll - 1);
                            currentData.GetComponent<CurrentDataScript>().AddItem(pickedObject.GetComponent<WorldObjectScript>().GetId());
                            if (thrownItemID == 1)
                            {
                                pickedObject.GetComponent<SpriteRenderer>().sprite = appleItem;
                                pickedObject.GetComponent<WorldObjectScript>().SetId(1);
                                pickedObject.GetComponent<WorldObjectScript>().itemName = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_name");
                                pickedObject.GetComponent<WorldObjectScript>().itemDescription = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_apple");
                            }
                            else if (thrownItemID == 2)
                            {
                                pickedObject.GetComponent<SpriteRenderer>().sprite = lightPotionItem;
                                pickedObject.GetComponent<WorldObjectScript>().SetId(2);
                                pickedObject.GetComponent<WorldObjectScript>().itemName = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_name");
                                pickedObject.GetComponent<WorldObjectScript>().itemDescription = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_lightpotion");
                            }
                            else if (thrownItemID == 3)
                            {
                                pickedObject.GetComponent<SpriteRenderer>().sprite = resurrectPotionItem;
                                pickedObject.GetComponent<WorldObjectScript>().SetId(3);
                                pickedObject.GetComponent<WorldObjectScript>().itemName = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_name");
                                pickedObject.GetComponent<WorldObjectScript>().itemDescription = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_resurrectpotion");
                            }
                        }
                        throwItemUIScroll = 0;
                        throwingItemSelecting = 0;
                    }
                }
                else if (showItem && Input.GetKeyDown(KeyCode.X))
                {
                    if (fullItems)
                    {
                        pickItemUI.transform.GetChild(0).gameObject.SetActive(false);
                        pickItemUI.transform.GetChild(2).gameObject.SetActive(false);
                        pickItemUI.transform.GetChild(3).gameObject.SetActive(true);
                        pickItemUI.transform.GetChild(4).gameObject.SetActive(true);
                        CreateThrowItemUI();
                        if (pickedObject.GetComponent<WorldObjectScript>().GetId() == 1) pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_apple");
                        else if (pickedObject.GetComponent<WorldObjectScript>().GetId() == 2) pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_lightpotion");
                        else if (pickedObject.GetComponent<WorldObjectScript>().GetId() == 3) pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_resurrectpotion");
                        fullItems = false;
                        throwingItem = true;
                    }                    
                    else
                    {
                        animator.SetBool("Pick", false);
                        showItem = false;
                        pickingObject = false;
                        pickItemUI.SetActive(false);
                        Destroy(pickedObject);
                    }                    
                }
            }
            if (shopOpened)
            {
                speedX = 0.0f;
                speedZ = 0.0f;
                animator.SetBool("Moving", false);
                animator.SetFloat("SpeedZ", speedZ);
                animator.SetFloat("SpeedX", speedX);

                if (shopConfirming)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow) && shopConfirmSelecting == 0)
                    {
                        shopConfirmSelecting = 1;
                        shopUI.transform.GetChild(3).GetComponent<Animator>().SetInteger("Pos", shopConfirmSelecting);
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow) && shopConfirmSelecting == 1)
                    {
                        shopConfirmSelecting = 0;
                        shopUI.transform.GetChild(3).GetComponent<Animator>().SetInteger("Pos", shopConfirmSelecting);
                    }
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        if (shopBuyOpened)
                        {
                            shopConfirming = false;
                            shopUI.transform.GetChild(3).gameObject.SetActive(false);
                            if (shopConfirmSelecting == 0)
                            {
                                currentData.GetComponent<CurrentDataScript>().currentCoins -= shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].price;
                                if (!shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].isBadge) currentData.GetComponent<CurrentDataScript>().AddItem(shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].id);
                                else currentData.GetComponent<CurrentDataScript>().SetGemFound(shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].id,1);
                                canvas.GetComponent<WorldCanvasScript>().UpdateCoins();
                                if (((shopBuyScroll + 6) < (shopItems.Length - pastItems) + 1) && shopBuyScroll > 0 && shopGems) shopBuyScroll -= 1;
                                if (shopBuySelecting == (shopItems.Length - pastItems) && shopBuyScroll == 0 && shopGems)
                                {
                                    shopBuySelecting -= 1;
                                    shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopBuySelecting);
                                }
                                CreateShopUI();
                                if(shopGems && !shopGemsNotEmpty)
                                {
                                    shopGems = false;
                                    shopBuyScroll = 0;
                                    shopBuySelecting = 1;
                                    shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                                    shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopBuySelecting);
                                    shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Open", true);
                                    shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Open", false);
                                    shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Empty", true);
                                    CreateShopUI();
                                }
                            }
                            shopConfirmSelecting = 0;
                        }
                        else if (shopSellOpened)
                        {
                            shopConfirming = false;
                            shopUI.transform.GetChild(3).gameObject.SetActive(false);
                            if (shopConfirmSelecting == 0)
                            {
                                if (!shopGems)
                                {
                                    currentData.GetComponent<CurrentDataScript>().currentCoins += (int)(currentData.GetComponent<CurrentDataScript>().ItemPrice(shopSellSelecting, false) * 0.7f)+1;
                                    currentData.GetComponent<CurrentDataScript>().DeleteItem(shopSellSelecting + shopSellScroll - 1);
                                    canvas.GetComponent<WorldCanvasScript>().UpdateCoins();
                                    if ((shopSellScroll + 6) >= currentData.GetComponent<CurrentDataScript>().itemSize() && shopSellScroll > 0) shopSellScroll -= 1;
                                    if (shopSellSelecting == currentData.GetComponent<CurrentDataScript>().itemSize() + 1 && shopSellScroll == 0)
                                    {
                                        shopSellSelecting -= 1;
                                        shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopSellSelecting);
                                    }
                                    if (currentData.GetComponent<CurrentDataScript>().itemSize() == 0)
                                    {
                                        if (currentData.GetComponent<CurrentDataScript>().availableGems == 0)
                                        {
                                            shopGems = false;
                                            shopSellScroll = 0;
                                            shopSellSelecting = 1;
                                            shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                                            shopSellOpened = false;
                                            shopMainOpened = true;
                                            shopUI.transform.GetChild(4).gameObject.SetActive(true);
                                            shopUI.transform.GetChild(0).gameObject.SetActive(false);
                                            shopUI.transform.GetChild(2).gameObject.SetActive(false);
                                            shopUI.transform.GetChild(4).GetComponent<Animator>().SetTrigger("Back");
                                            shopUI.transform.GetChild(4).GetComponent<Animator>().SetInteger("Pos", shopMainSelecting);
                                            shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Open", true);
                                            shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Open", false);
                                        }
                                        else
                                        {
                                            shopGems = true;
                                            shopSellScroll = 0;
                                            shopSellSelecting = 1;
                                            shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                                            shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopSellSelecting);
                                            shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Open", false);
                                            shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Empty", true);
                                            shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Open", true);
                                        }
                                    }
                                    CreateShopUI();
                                }
                                else
                                {
                                    currentData.GetComponent<CurrentDataScript>().currentCoins += (int)(currentData.GetComponent<CurrentDataScript>().ItemPrice(shopSellSelecting, true) * 0.7f)+1;
                                    currentData.GetComponent<CurrentDataScript>().SetGemFound(FindGemInPos(shopSellSelecting) + shopSellScroll, 0);
                                    canvas.GetComponent<WorldCanvasScript>().UpdateCoins();
                                    if ((shopSellScroll + 6) >= currentData.GetComponent<CurrentDataScript>().availableGems && shopSellScroll > 0) shopSellScroll -= 1;
                                    if (shopSellSelecting == currentData.GetComponent<CurrentDataScript>().availableGems + 1 && shopSellScroll == 0)
                                    {
                                        shopSellSelecting -= 1;
                                        shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopSellSelecting);
                                    }
                                    if (currentData.GetComponent<CurrentDataScript>().availableGems == 0)
                                    {
                                        if (currentData.GetComponent<CurrentDataScript>().itemSize() == 0)
                                        {
                                            shopGems = false;
                                            shopSellSelecting = 1;
                                            shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                                            shopSellOpened = false;
                                            shopMainOpened = true;
                                            shopUI.transform.GetChild(4).gameObject.SetActive(true);
                                            shopUI.transform.GetChild(0).gameObject.SetActive(false);
                                            shopUI.transform.GetChild(2).gameObject.SetActive(false);
                                            shopUI.transform.GetChild(4).GetComponent<Animator>().SetTrigger("Back");
                                            shopUI.transform.GetChild(4).GetComponent<Animator>().SetInteger("Pos", shopMainSelecting);
                                            shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Open", true);
                                            shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Open", false);
                                        }
                                        else
                                        {
                                            shopGems = false;
                                            shopSellScroll = 0;
                                            shopSellSelecting = 1;
                                            shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                                            shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopSellSelecting);
                                            shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Open", true);
                                            shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Open", false);
                                            shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Empty", true);
                                        }
                                    }
                                    CreateShopUI();
                                }
                            }
                            shopConfirmSelecting = 0;
                            UpdateShopInstructionText();
                        }
                        else if (shopDepositOpened)
                        {
                            shopConfirming = false;
                            shopUI.transform.GetChild(3).gameObject.SetActive(false);
                            if (shopConfirmSelecting == 0)
                            {
                                currentData.GetComponent<CurrentDataScript>().AddStoredItem(currentData.GetComponent<CurrentDataScript>().items[shopDepositSelecting + shopDepositScroll - 1]);
                                currentData.GetComponent<CurrentDataScript>().DeleteItem(shopDepositSelecting + shopDepositScroll - 1);
                                if ((shopDepositScroll + 6) >= currentData.GetComponent<CurrentDataScript>().itemSize() && shopDepositScroll > 0) shopDepositScroll -= 1;
                                if (shopDepositSelecting == currentData.GetComponent<CurrentDataScript>().itemSize() + 1 && shopDepositScroll == 0)
                                {
                                    shopDepositSelecting -= 1;
                                    shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopDepositSelecting);
                                }
                                CreateShopUI();
                            }
                            shopConfirmSelecting = 0;
                            if (currentData.GetComponent<CurrentDataScript>().itemSize() == 0 || currentData.GetComponent<CurrentDataScript>().StoredItemSize() == 99)
                            {
                                shopDepositSelecting = 1;
                                shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                                shopDepositOpened = false;
                                shopMainOpened = true;
                                shopUI.transform.GetChild(4).gameObject.SetActive(true);
                                shopUI.transform.GetChild(0).gameObject.SetActive(false);
                                shopUI.transform.GetChild(2).gameObject.SetActive(false);
                                shopUI.transform.GetChild(4).GetComponent<Animator>().SetTrigger("Back");
                                shopUI.transform.GetChild(4).GetComponent<Animator>().SetInteger("Pos", shopMainSelecting);
                            }
                            UpdateShopInstructionText();
                        }
                        else if (shopPickUpOpened)
                        {
                            shopConfirming = false;
                            shopUI.transform.GetChild(3).gameObject.SetActive(false);
                            if (shopConfirmSelecting == 0)
                            {
                                currentData.GetComponent<CurrentDataScript>().AddItem(currentData.GetComponent<CurrentDataScript>().storedItems[shopPickUpSelecting + shopPickUpScroll - 1]);
                                currentData.GetComponent<CurrentDataScript>().DeleteStoredItem(shopPickUpSelecting + shopPickUpScroll - 1);
                                if ((shopPickUpScroll + 6) >= currentData.GetComponent<CurrentDataScript>().StoredItemSize() && shopPickUpScroll > 0) shopPickUpScroll -= 1;
                                if (shopPickUpSelecting == currentData.GetComponent<CurrentDataScript>().StoredItemSize() + 1 && shopPickUpScroll == 0)
                                {
                                    shopPickUpSelecting -= 1;
                                    shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopPickUpSelecting);
                                }
                                CreateShopUI();
                            }
                            shopConfirmSelecting = 0;
                            if (currentData.GetComponent<CurrentDataScript>().StoredItemSize() == 0 || currentData.GetComponent<CurrentDataScript>().itemSize() == 20)
                            {
                                shopPickUpSelecting = 1;
                                shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                                shopPickUpOpened = false;
                                shopMainOpened = true;
                                shopUI.transform.GetChild(4).gameObject.SetActive(true);
                                shopUI.transform.GetChild(0).gameObject.SetActive(false);
                                shopUI.transform.GetChild(2).gameObject.SetActive(false);
                                shopUI.transform.GetChild(4).GetComponent<Animator>().SetTrigger("Back");
                                shopUI.transform.GetChild(4).GetComponent<Animator>().SetInteger("Pos", shopMainSelecting);
                            }
                            UpdateShopInstructionText();
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        shopConfirmSelecting = 0;
                        shopConfirming = false;
                        shopUI.transform.GetChild(3).gameObject.SetActive(false);
                    }
                }
                else if (shopMainOpened)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow) && shopMainSelecting > 1)
                    {
                        shopMainSelecting -= 1;
                        UpdateShopInstructionText();
                        shopUI.transform.GetChild(4).GetComponent<Animator>().SetInteger("Pos", shopMainSelecting);
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow) && shopMainSelecting < 4)
                    {
                        shopMainSelecting += 1;
                        UpdateShopInstructionText();
                        shopUI.transform.GetChild(4).GetComponent<Animator>().SetInteger("Pos", shopMainSelecting);
                    }
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        shopMainSelecting = 1;
                        shopUI.transform.GetChild(4).GetComponent<Animator>().SetTrigger("Reset");
                        shopUI.transform.GetChild(4).GetComponent<Animator>().SetInteger("Pos", shopMainSelecting);
                        shopOpened = false;
                        shopUI.SetActive(false);
                    }
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        if (shopMainSelecting == 1)
                        {
                            shopMainOpened = false;
                            shopBuyOpened = true;
                            shopUI.transform.GetChild(4).gameObject.SetActive(false);
                            shopUI.transform.GetChild(0).gameObject.SetActive(true);
                            shopUI.transform.GetChild(2).gameObject.SetActive(true);
                            shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Active", true);
                            shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Open", true);
                            shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Active", true);
                            shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Open", false);
                            shopUI.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_buy_select");
                            CreateShopUI();
                            shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Empty", !shopGemsNotEmpty);
                            UpdateShopInstructionText();
                        }
                        else if (shopMainSelecting == 2)
                        {
                            if (currentData.GetComponent<CurrentDataScript>().itemSize() > 0 || currentData.GetComponent<CurrentDataScript>().availableGems > 0)
                            {
                                shopMainOpened = false;
                                shopSellOpened = true;
                                shopUI.transform.GetChild(4).gameObject.SetActive(false);
                                shopUI.transform.GetChild(0).gameObject.SetActive(true);
                                shopUI.transform.GetChild(2).gameObject.SetActive(true);
                                if(currentData.GetComponent<CurrentDataScript>().itemSize() > 0)
                                {
                                    shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Active", true);
                                    shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Open", true);
                                    shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Active", true);
                                    shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Open", false);
                                }
                                else
                                {
                                    shopGems = true;
                                    shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Active", true);
                                    shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Open", false);
                                    shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Empty", true);
                                    shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Active", true);
                                    shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Open", true);
                                }
                                shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Empty", currentData.GetComponent<CurrentDataScript>().availableGems == 0);
                                shopUI.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_sell_select");
                                CreateShopUI();
                                UpdateShopInstructionText();
                            }
                            else shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_sell_noitems"); 
                        }
                        else if (shopMainSelecting == 3)
                        {
                            if (currentData.GetComponent<CurrentDataScript>().itemSize() > 0 && currentData.GetComponent<CurrentDataScript>().StoredItemSize() < 99)
                            {
                                shopMainOpened = false;
                                shopDepositOpened = true;
                                shopUI.transform.GetChild(4).gameObject.SetActive(false);
                                shopUI.transform.GetChild(0).gameObject.SetActive(true);
                                shopUI.transform.GetChild(2).gameObject.SetActive(true);
                                shopUI.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_store_select");
                                CreateShopUI();
                                UpdateShopInstructionText();
                            }
                            else shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_store_noitems"); 
                        }
                        else if (shopMainSelecting == 4)
                        {
                            if (currentData.GetComponent<CurrentDataScript>().StoredItemSize() > 0 && currentData.GetComponent<CurrentDataScript>().itemSize() < 20)
                            {
                                shopMainOpened = false;
                                shopPickUpOpened = true;
                                shopUI.transform.GetChild(4).gameObject.SetActive(false);
                                shopUI.transform.GetChild(0).gameObject.SetActive(true);
                                shopUI.transform.GetChild(2).gameObject.SetActive(true);
                                shopUI.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_takeout_select");
                                CreateShopUI();
                                UpdateShopInstructionText();
                            }
                            else shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_takeout_noitems"); 
                        }
                    }
                }
                else if (shopBuyOpened)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow) && (shopBuySelecting > 1 || shopBuyScroll > 0))
                    {
                        if (shopBuyScroll > 0 && shopBuySelecting == 1)
                        {
                            shopBuyScroll -= 1;
                            CreateShopUI();
                        }
                        else
                        {
                            shopBuySelecting -= 1;
                            shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopBuySelecting);
                        }
                        UpdateShopInstructionText();
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow) && (shopBuySelecting < 6 || shopBuyScroll + 6 < shopItems.Length - pastItems))
                    {
                        if (shopBuySelecting == 6 && shopBuyScroll + 6 < shopItems.Length - pastItems)
                        {
                            shopBuyScroll += 1;
                            CreateShopUI();
                            UpdateShopInstructionText();
                        }
                        else if (shopBuySelecting < shopItems.Length - pastItems)
                        {
                            shopBuySelecting += 1;
                            shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopBuySelecting);
                            UpdateShopInstructionText();
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow) && !shopGems && shopGemsNotEmpty)
                    {
                        shopBuyScroll = 0;
                        shopBuySelecting = 1;
                        shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                        shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopBuySelecting);
                        shopGems = true;
                        shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Open", false);
                        shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Open", true);
                        CreateShopUI();
                        UpdateShopInstructionText();
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow) && shopGems)
                    {
                        shopBuyScroll = 0;
                        shopBuySelecting = 1;
                        shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                        shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopBuySelecting);
                        shopGems = false;
                        shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Open", true);
                        shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Open", false);
                        CreateShopUI();
                        UpdateShopInstructionText();
                    }
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        if (shopItems[shopBuySelecting + shopBuyScroll - 1].price <= currentData.GetComponent<CurrentDataScript>().currentCoins && (shopItems[shopBuySelecting + shopBuyScroll - 1].isBadge || (!shopItems[shopBuySelecting + shopBuyScroll - 1].isBadge && currentData.GetComponent<CurrentDataScript>().itemSize() < 20)))
                        {
                            shopConfirming = true;
                            shopUI.transform.GetChild(3).gameObject.SetActive(true);
                            shopUI.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_buy_sure"); 
                        }
                        else
                        {
                            if (shopItems[shopBuySelecting + shopBuyScroll - 1].price > currentData.GetComponent<CurrentDataScript>().currentCoins)
                            {
                                if (!shopItems[shopBuySelecting + shopBuyScroll - 1].isBadge && currentData.GetComponent<CurrentDataScript>().itemSize() == 20) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_buy_nospacenomoney"); 
                                else shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_buy_nocoins"); 
                            }
                            else if (!shopItems[shopBuySelecting + shopBuyScroll - 1].isBadge && currentData.GetComponent<CurrentDataScript>().itemSize() == 20) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_buy_nospace"); 
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        shopGems = false;
                        shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Active", false);
                        shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Open", true);
                        shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Active", false);
                        shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Open", false);
                        shopBuyScroll = 0;
                        shopBuySelecting = 1;
                        shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                        shopBuyOpened = false;
                        shopMainOpened = true;
                        shopUI.transform.GetChild(4).gameObject.SetActive(true);
                        shopUI.transform.GetChild(0).gameObject.SetActive(false);
                        shopUI.transform.GetChild(2).gameObject.SetActive(false);
                        shopUI.transform.GetChild(4).GetComponent<Animator>().SetTrigger("Back");
                        shopUI.transform.GetChild(4).GetComponent<Animator>().SetInteger("Pos", shopMainSelecting);
                    }
                }
                else if (shopSellOpened)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow) && (shopSellSelecting > 1 || shopSellScroll > 0))
                    {
                        if (shopSellScroll > 0 && shopSellSelecting == 1)
                        {
                            shopSellScroll -= 1;
                            CreateShopUI();
                        }
                        else
                        {
                            shopSellSelecting -= 1;
                            shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopSellSelecting);
                        }
                        UpdateShopInstructionText();
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow) && (shopSellSelecting < 6 || (shopSellScroll + 6 < currentData.GetComponent<CurrentDataScript>().itemSize() && ! shopGems) || (shopSellScroll + 6 < currentData.GetComponent<CurrentDataScript>().availableGems && shopGems)))
                    {
                        if (shopSellSelecting == 6 && ((shopSellScroll + 6 < currentData.GetComponent<CurrentDataScript>().itemSize() && !shopGems) || (shopSellScroll + 6 < currentData.GetComponent<CurrentDataScript>().availableGems && shopGems)))
                        {
                            shopSellScroll += 1;
                            CreateShopUI();
                            UpdateShopInstructionText();
                        }
                        else if ((shopSellSelecting < currentData.GetComponent<CurrentDataScript>().itemSize() && !shopGems) || (shopSellSelecting < currentData.GetComponent<CurrentDataScript>().availableGems && shopGems))
                        {
                            shopSellSelecting += 1;
                            shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopSellSelecting);
                            UpdateShopInstructionText();
                        }
                    }
                    if(Input.GetKeyDown(KeyCode.RightArrow) && !shopGems && currentData.GetComponent<CurrentDataScript>().availableGems != 0)
                    {
                        shopSellScroll = 0;
                        shopSellSelecting = 1;
                        shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                        shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopSellSelecting);
                        shopGems = true;
                        shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Open", false);
                        shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Open", true);
                        CreateShopUI();
                        UpdateShopInstructionText();
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow) && shopGems && currentData.GetComponent<CurrentDataScript>().itemSize() != 0)
                    {
                        shopSellScroll = 0;
                        shopSellSelecting = 1;
                        shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                        shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopSellSelecting);
                        shopGems = false;
                        shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Open", true);
                        shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Open", false);
                        CreateShopUI();
                        UpdateShopInstructionText();
                    }
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        shopConfirming = true;
                        shopUI.transform.GetChild(3).gameObject.SetActive(true);
                        shopUI.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_sell_sure"); 
                    }
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        shopGems = false;
                        shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Active", false);
                        shopUI.transform.GetChild(0).GetChild(10).GetComponent<Animator>().SetBool("Open", true);
                        shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Active", false);
                        shopUI.transform.GetChild(0).GetChild(11).GetComponent<Animator>().SetBool("Open", false);
                        shopSellScroll = 0;
                        shopSellSelecting = 1;
                        shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                        shopSellOpened = false;
                        shopMainOpened = true;
                        shopUI.transform.GetChild(4).gameObject.SetActive(true);
                        shopUI.transform.GetChild(0).gameObject.SetActive(false);
                        shopUI.transform.GetChild(2).gameObject.SetActive(false);
                        shopUI.transform.GetChild(4).GetComponent<Animator>().SetTrigger("Back");
                        shopUI.transform.GetChild(4).GetComponent<Animator>().SetInteger("Pos", shopMainSelecting);
                    }
                }
                else if (shopDepositOpened)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow) && (shopDepositSelecting > 1 || shopDepositScroll > 0))
                    {
                        if (shopDepositScroll > 0 && shopDepositSelecting == 1)
                        {
                            shopDepositScroll -= 1;
                            CreateShopUI();
                        }
                        else
                        {
                            shopDepositSelecting -= 1;
                            shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopDepositSelecting);
                        }
                        UpdateShopInstructionText();
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow) && (shopDepositSelecting < 6 || shopDepositScroll + 6 < currentData.GetComponent<CurrentDataScript>().itemSize()))
                    {
                        if (shopDepositSelecting == 6 && shopDepositScroll + 6 < currentData.GetComponent<CurrentDataScript>().itemSize())
                        {
                            shopDepositScroll += 1;
                            CreateShopUI();
                            UpdateShopInstructionText();
                        }
                        else if (shopDepositSelecting < currentData.GetComponent<CurrentDataScript>().itemSize())
                        {
                            shopDepositSelecting += 1;
                            shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopDepositSelecting);
                            UpdateShopInstructionText();
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        shopConfirming = true;
                        shopUI.transform.GetChild(3).gameObject.SetActive(true);
                        shopUI.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_store_sure"); 
                    }
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        shopDepositScroll = 0;
                        shopDepositSelecting = 1;
                        shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                        shopDepositOpened = false;
                        shopMainOpened = true;
                        shopUI.transform.GetChild(4).gameObject.SetActive(true);
                        shopUI.transform.GetChild(0).gameObject.SetActive(false);
                        shopUI.transform.GetChild(2).gameObject.SetActive(false);
                        shopUI.transform.GetChild(4).GetComponent<Animator>().SetTrigger("Back");
                        shopUI.transform.GetChild(4).GetComponent<Animator>().SetInteger("Pos", shopMainSelecting);
                    }
                }
                else if (shopPickUpOpened)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow) && (shopPickUpSelecting > 1 || shopPickUpScroll > 0))
                    {
                        if (shopPickUpScroll > 0 && shopPickUpSelecting == 1)
                        {
                            shopPickUpScroll -= 1;
                            CreateShopUI();
                        }
                        else
                        {
                            shopPickUpSelecting -= 1;
                            shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopPickUpSelecting);
                        }
                        UpdateShopInstructionText();
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow) && (shopPickUpSelecting < 6 || shopPickUpScroll + 6 < currentData.GetComponent<CurrentDataScript>().StoredItemSize()))
                    {
                        if (shopPickUpSelecting == 6 && shopPickUpScroll + 6 < currentData.GetComponent<CurrentDataScript>().StoredItemSize())
                        {
                            shopPickUpScroll += 1;
                            CreateShopUI();
                            UpdateShopInstructionText();
                        }
                        else if (shopPickUpSelecting < currentData.GetComponent<CurrentDataScript>().StoredItemSize())
                        {
                            shopPickUpSelecting += 1;
                            shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopPickUpSelecting);
                            UpdateShopInstructionText();
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        shopConfirming = true;
                        shopUI.transform.GetChild(3).gameObject.SetActive(true);
                        shopUI.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_takeout_sure"); 
                    }
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        shopPickUpScroll = 0;
                        shopPickUpSelecting = 1;
                        shopUI.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Reset");
                        shopPickUpOpened = false;
                        shopMainOpened = true;
                        shopUI.transform.GetChild(4).gameObject.SetActive(true);
                        shopUI.transform.GetChild(0).gameObject.SetActive(false);
                        shopUI.transform.GetChild(2).gameObject.SetActive(false);
                        shopUI.transform.GetChild(4).GetComponent<Animator>().SetTrigger("Back");
                        shopUI.transform.GetChild(4).GetComponent<Animator>().SetInteger("Pos", shopMainSelecting);
                    }
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
                                restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_save_completed"); 
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
                                restPlayerItemsUI.transform.GetChild(1).GetComponent<Text>().text = currentData.GetComponent<CurrentDataScript>().itemSize().ToString();
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
                        else if (Input.GetKeyDown(KeyCode.DownArrow) && ((restPlayerGemUISelecting < 6 && currentData.GetComponent<CurrentDataScript>().availableGems > 6) || gemUIScroll + 6 < currentData.GetComponent<CurrentDataScript>().availableGems || (restPlayerGemUISelecting < currentData.GetComponent<CurrentDataScript>().availableGems && currentData.GetComponent<CurrentDataScript>().availableGems <= 6)))
                        {
                            if (restPlayerGemUISelecting == 6 && gemUIScroll + 6 < currentData.GetComponent<CurrentDataScript>().availableGems)
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
                        else if (Input.GetKeyDown(KeyCode.DownArrow) && (restPlayerItemUISelecting < 6 || itemUIScroll + 6 < currentData.GetComponent<CurrentDataScript>().itemSize()))
                        {
                            if (restPlayerItemUISelecting == 6 && itemUIScroll + 6 < currentData.GetComponent<CurrentDataScript>().itemSize())
                            {
                                itemUIScroll += 1;
                                CreateItemsUI();
                            }
                            else if(restPlayerItemUISelecting < currentData.GetComponent<CurrentDataScript>().itemSize())
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
            if (speaking)
            {
                speedX = 0.0f;
                speedZ = 0.0f;
                animator.SetBool("Moving", false);
                animator.SetFloat("SpeedZ", speedZ);
                animator.SetFloat("SpeedX", speedX);
                if (dialogue)
                {
                    if (Input.GetKeyDown(KeyCode.X)) dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
                }
                else
                {
                    speaking = false;
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
        if(canSpeak && Input.GetKeyDown(KeyCode.X) && !speaking)
        {
            dialogue = true;
            speaking = true;
            dialogueManager.GetComponent<DialogueManager>().StartWorldDialogue(nextDialogue);
            SetCanSpeak(false);
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

    //Function to set the rest bool
    public void SetCanSpeak(bool s)
    {
        canSpeak = s;
        interactable.SetActive(s);
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

    //Function to show the shop UI
    public void ShowShopUI()
    {
        shopUI.SetActive(true);
        dialogue = false;
        CreateShopUI();
        UpdateShopInstructionText();
        shopBuySelecting = 1;
        shopOpened = true;
        //shopUI.transform.GetChild(0).GetComponent<Animator>().SetInteger("Pos", shopBuySelecting);
    }

    //Function to end the dialogue
    public void EndDialogue()
    {
        dialogue = false; 
        canvas.GetComponent<Animator>().SetBool("Hide", false);
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
            if (restUISelecting == 1) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_main_player"); 
            else if (restUISelecting == 2) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_main_save"); 
            else restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_main_change"); 
        }
        else if (restUIState == 2)
        {
            if (restPlayerMainUISelecting == 1) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_player_stats"); 
            else if (restPlayerMainUISelecting == 2) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_player_gems");
            else restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_player_items"); 
        }
        else if (restUIState == 3) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_stats"); 
        else if (restUIState == 4)
        {
            if (FindGemInPos(restPlayerGemUISelecting + gemUIScroll) == 1) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_lightsword"); 
            else if (FindGemInPos(restPlayerGemUISelecting + gemUIScroll) == 2) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_multistrikesword"); 
            else if (FindGemInPos(restPlayerGemUISelecting + gemUIScroll) == 3) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_lightshuriken"); 
            else if (FindGemInPos(restPlayerGemUISelecting + gemUIScroll) == 4) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_fireshuriken"); 
            else if (FindGemInPos(restPlayerGemUISelecting + gemUIScroll) == 5) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_hpup"); 
            else if (FindGemInPos(restPlayerGemUISelecting + gemUIScroll) == 6) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_lpup"); 
            else restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_comphpup"); 
        }
        else if (restUIState == 5)
        {
            if (currentData.GetComponent<CurrentDataScript>().items[restPlayerItemUISelecting + itemUIScroll - 1] == 1) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_apple"); 
            else if (currentData.GetComponent<CurrentDataScript>().items[restPlayerItemUISelecting + itemUIScroll - 1] == 2) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_lightpotion"); 
            else if (currentData.GetComponent<CurrentDataScript>().items[restPlayerItemUISelecting + itemUIScroll - 1] == 3) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_resurrectpotion"); 
        }
        else if (restUIState == 6) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_save_saving"); 
        else if (restUIState == 7)
        {
            if (restCompanionUISelecting == 1) restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_companions_adventurer"); 
            else restInstructionsText.text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_companions_wizard"); 
        }
    }
    
    //Function to create the gem UI
    public void CreateGemUI()
    {
        //We hide or show the arrows depending on the scroll
        if (gemUIScroll > 0) restPlayerGemsUI.transform.GetChild(11).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        else restPlayerGemsUI.transform.GetChild(11).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        if ((gemUIScroll + 6) < currentData.GetComponent<CurrentDataScript>().availableGems) restPlayerGemsUI.transform.GetChild(12).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        else restPlayerGemsUI.transform.GetChild(12).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        //We search the gems for all the available spaces, if there are less than 6 we make those spaces disappear
        for (int i = 1; i < 7; i++)
        {
            if (i < currentData.GetComponent<CurrentDataScript>().availableGems + 1)
            {
                if(currentData.GetComponent<CurrentDataScript>().GemUsing(allGems[FindGemInPos(i) + gemUIScroll - 1],allGems)==1) restPlayerGemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(0.0f, 1.0f, 0.0f, 1.0f);
                else if(gems.gems[FindGemInPos(i) + gemUIScroll - 1].points > ((currentData.GetComponent<CurrentDataScript>().playerBadgeLvl * 3 + 3) - currentData.GetComponent<CurrentDataScript>().spentGP)) restPlayerGemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
                else restPlayerGemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = gems.gems[FindGemInPos(i) + gemUIScroll - 1].nameSpanish[0];
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().texture = gems.gems[FindGemInPos(i) + gemUIScroll - 1].icon;
                restPlayerGemsUI.transform.GetChild(4 + i).GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_GP") + " " + gems.gems[FindGemInPos(i) + gemUIScroll - 1].points.ToString();
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
        if ((itemUIScroll + 6) < currentData.GetComponent<CurrentDataScript>().itemSize()) restPlayerItemsUI.transform.GetChild(12).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        else restPlayerItemsUI.transform.GetChild(12).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        for (int i = 1; i < 7; i++)
        {
            if (i < currentData.GetComponent<CurrentDataScript>().itemSize() + 1)
            {
                restPlayerItemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                restPlayerItemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                restPlayerItemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                if (currentData.GetComponent<CurrentDataScript>().items[i + itemUIScroll - 1] == 1)
                {
                    restPlayerItemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().texture = apple;
                    restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_name"); 
                }
                else if (currentData.GetComponent<CurrentDataScript>().items[i + itemUIScroll - 1] == 2)
                {
                    restPlayerItemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().texture = lightPotion;
                    restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_name"); 
                }
                else if (currentData.GetComponent<CurrentDataScript>().items[i + itemUIScroll - 1] == 3)
                {
                    restPlayerItemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().texture = resurrectPotion;
                    restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_name"); 
                }
            }
            else
            {
                restPlayerItemsUI.transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                restPlayerItemsUI.transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                restPlayerItemsUI.transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
            }
       
        }
    }

    //Function to create the throw item UI
    public void CreateThrowItemUI()
    {
        //We hide or show the arrows depending on the scroll
        if (throwItemUIScroll > 0) pickItemUI.transform.GetChild(4).GetChild(8).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        else pickItemUI.transform.GetChild(4).GetChild(8).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        if ((throwItemUIScroll + 6) < currentData.GetComponent<CurrentDataScript>().itemSize()) pickItemUI.transform.GetChild(4).GetChild(9).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        else pickItemUI.transform.GetChild(4).GetChild(9).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);

        pickItemUI.transform.GetChild(4).GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        pickItemUI.transform.GetChild(4).GetChild(1).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        pickItemUI.transform.GetChild(4).GetChild(1).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        pickItemUI.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        if (pickedObject.GetComponent<WorldObjectScript>().GetId() == 1)
        {
            pickItemUI.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<RawImage>().texture = apple;
            pickItemUI.transform.GetChild(4).GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_name"); 
        }
        else if (pickedObject.GetComponent<WorldObjectScript>().GetId() == 2)
        {
            pickItemUI.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<RawImage>().texture = lightPotion;
            pickItemUI.transform.GetChild(4).GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_name"); 
        }
        else if (pickedObject.GetComponent<WorldObjectScript>().GetId() == 3)
        {
            pickItemUI.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<RawImage>().texture = resurrectPotion;
            pickItemUI.transform.GetChild(4).GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_name"); 
        }

        if (currentData.GetComponent<CurrentDataScript>().itemSize() > 5)
        {
            for (int i = 1; i < 7; i++)
            {
                if (i < currentData.GetComponent<CurrentDataScript>().itemSize() + 1)
                {
                    pickItemUI.transform.GetChild(4).GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    pickItemUI.transform.GetChild(4).GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    pickItemUI.transform.GetChild(4).GetChild(1 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    pickItemUI.transform.GetChild(4).GetChild(1 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    if (currentData.GetComponent<CurrentDataScript>().items[i + throwItemUIScroll - 1] == 1)
                    {
                        pickItemUI.transform.GetChild(4).GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = apple;
                        pickItemUI.transform.GetChild(4).GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_name"); 
                    }
                    else if (currentData.GetComponent<CurrentDataScript>().items[i + throwItemUIScroll - 1] == 2)
                    {
                        pickItemUI.transform.GetChild(4).GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = lightPotion;
                        pickItemUI.transform.GetChild(4).GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_name"); 
                    }
                    else if (currentData.GetComponent<CurrentDataScript>().items[i + throwItemUIScroll - 1] == 3)
                    {
                        pickItemUI.transform.GetChild(4).GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = resurrectPotion;
                        pickItemUI.transform.GetChild(4).GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_name"); 
                    }
                }
                else
                {
                    pickItemUI.transform.GetChild(4).GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    pickItemUI.transform.GetChild(4).GetChild(1 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    pickItemUI.transform.GetChild(4).GetChild(1 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                }
            }
        }
    }
    

    //Function to create the shop UI
    public void CreateShopUI()
    {
        bool found = false;
        pastItems = 0;
        int prevItems = 0;
        if (shopBuyOpened)
        {
            //We update the gems bool
            shopGemsNotEmpty = false;
            //We activate the header
            shopUI.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            int i = 1;
            while(i <= shopBuyScroll || !found)
            {
                if (!shopItems[i - 1].isBadge && shopGems) prevItems++;
                else if (shopItems[i - 1].isBadge && !shopGems) prevItems++;
                else found = true;
                i++;
            }
            pastItems = prevItems;
            i = 1;
            while ( i < 7)
            {
                if (i < shopItems.Length + 1 - pastItems)
                {
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    if (!shopItems[i + shopBuyScroll - 1 + pastItems].isBadge && !shopGems)
                    {
                        if (shopItems[i + shopBuyScroll - 1 + pastItems].id == 1)
                        {
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = apple;
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_name"); 
                        }
                        else if (shopItems[i + shopBuyScroll - 1 + pastItems].id == 2)
                        {
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = lightPotion;
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_name"); 
                        }
                        else if (shopItems[i + shopBuyScroll - 1 + pastItems].id == 3)
                        {
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = resurrectPotion;
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_name"); 
                        }
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().text = shopItems[i + shopBuyScroll - 1 + pastItems].price.ToString();
                        if (shopItems[i + shopBuyScroll - 1 + pastItems].price > currentData.GetComponent<CurrentDataScript>().currentCoins || (!shopItems[i + shopBuyScroll - 1 + pastItems].isBadge && currentData.GetComponent<CurrentDataScript>().itemSize() == 20))
                        {
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
                        }
                        i++;
                    }
                    else if (shopItems[i + shopBuyScroll - 1 + pastItems].isBadge)
                    {
                        if (!currentData.GetComponent<CurrentDataScript>().IsGemFound(shopItems[i + shopBuyScroll - 1 + pastItems].id))
                        {
                            //If we find one gem the gem store is not empty
                            shopGemsNotEmpty = true;
                            if (shopGems)
                            {
                                shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = gems.gems[shopItems[i + shopBuyScroll - 1 + pastItems].id - 1].icon;
                                if (currentData.GetComponent<CurrentDataScript>().language == 1) shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = gems.gems[shopItems[i + shopBuyScroll - 1 + pastItems].id - 1].nameEnglish[0];
                                else if (currentData.GetComponent<CurrentDataScript>().language == 2) shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = gems.gems[shopItems[i + shopBuyScroll - 1 + pastItems].id - 1].nameSpanish[0];
                                else shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = gems.gems[shopItems[i + shopBuyScroll - 1 + pastItems].id - 1].nameBasque[0];
                                shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().text = shopItems[i + shopBuyScroll - 1 + pastItems].price.ToString();
                                if (shopItems[i + shopBuyScroll - 1 + pastItems].price > currentData.GetComponent<CurrentDataScript>().currentCoins)
                                {
                                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
                                }
                                i++;
                            }
                            else pastItems += 1; 
                        }
                        else pastItems += 1; 
                    }
                    else pastItems += 1;
                }
                else
                {
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    i++;
                }
            }
            while(i+pastItems + shopBuyScroll < shopItems.Length + 1)
            {
                if (shopItems[i + shopBuyScroll - 1 + pastItems].isBadge && currentData.GetComponent<CurrentDataScript>().IsGemFound(shopItems[i + shopBuyScroll - 1 + pastItems].id)) pastItems++;
                else i++;
            }
            //We hide or show the arrows depending on the scroll
            if (shopBuyScroll > 0) shopUI.transform.GetChild(0).transform.GetChild(8).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            else shopUI.transform.GetChild(0).transform.GetChild(8).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
            if ((shopBuyScroll + 6) < (shopItems.Length - pastItems)) shopUI.transform.GetChild(0).transform.GetChild(9).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            else shopUI.transform.GetChild(0).transform.GetChild(9).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        }
        else if (shopSellOpened)
        {
            //We activate the header
            shopUI.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            if (!shopGems)
            {
                //We hide or show the arrows depending on the scroll
                if (shopSellScroll > 0) shopUI.transform.GetChild(0).transform.GetChild(8).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                else shopUI.transform.GetChild(0).transform.GetChild(8).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                if ((shopSellScroll + 6) < currentData.GetComponent<CurrentDataScript>().itemSize()) shopUI.transform.GetChild(0).transform.GetChild(9).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                else shopUI.transform.GetChild(0).transform.GetChild(9).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                for (int i = 1; i < 7; i++)
                {
                    if (i < currentData.GetComponent<CurrentDataScript>().itemSize() + 1)
                    {
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        if (currentData.GetComponent<CurrentDataScript>().items[i + shopSellScroll - 1] == 1)
                        {
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = apple;
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_name"); 
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().text = ((int)(currentData.GetComponent<CurrentDataScript>().ItemPrice(1,false)*0.7f)).ToString();
                        }
                        else if (currentData.GetComponent<CurrentDataScript>().items[i + shopSellScroll - 1] == 2)
                        {
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = lightPotion;
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_name"); 
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().text = ((int)(currentData.GetComponent<CurrentDataScript>().ItemPrice(2, false)*0.7f)).ToString();
                        }
                        else if (currentData.GetComponent<CurrentDataScript>().items[i + shopSellScroll - 1] == 3)
                        {
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = resurrectPotion;
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_name");  
                            shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().text = ((int)(currentData.GetComponent<CurrentDataScript>().ItemPrice(3, false) * 0.7f)+1).ToString();
                        }
                    }
                    else
                    {
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    }
                }
            }
            else
            {
                //We hide or show the arrows depending on the scroll
                if (shopSellScroll > 0) shopUI.transform.GetChild(0).transform.GetChild(8).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                else shopUI.transform.GetChild(0).transform.GetChild(8).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                if ((shopSellScroll + 6) < currentData.GetComponent<CurrentDataScript>().availableGems) shopUI.transform.GetChild(0).transform.GetChild(9).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                else shopUI.transform.GetChild(0).transform.GetChild(9).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                //We search the gems for all the available spaces, if there are less than 6 we make those spaces disappear
                for (int i = 1; i < 7; i++)
                {
                    if (i < currentData.GetComponent<CurrentDataScript>().availableGems + 1)
                    {
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = gems.gems[FindGemInPos(i) + shopSellScroll - 1].nameSpanish[0];
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = gems.gems[FindGemInPos(i) + shopSellScroll - 1].icon;
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().text = ((int)(currentData.GetComponent<CurrentDataScript>().ItemPrice(gems.gems[FindGemInPos(i) + shopSellScroll - 1].id, true) * 0.7f)+1).ToString();
                    }
                    else
                    {
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    }
                }
            }
        }
        else if (shopDepositOpened)
        {
            //We deactivate the header
            shopUI.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            //We hide or show the arrows depending on the scroll
            if (shopDepositScroll > 0) shopUI.transform.GetChild(0).transform.GetChild(8).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            else shopUI.transform.GetChild(0).transform.GetChild(8).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
            if ((shopDepositScroll + 6) < currentData.GetComponent<CurrentDataScript>().itemSize()) shopUI.transform.GetChild(0).transform.GetChild(9).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            else shopUI.transform.GetChild(0).transform.GetChild(9).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
            for (int i = 1; i < 7; i++)
            {
                if (i < currentData.GetComponent<CurrentDataScript>().itemSize() + 1)
                {
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    if (currentData.GetComponent<CurrentDataScript>().items[i + shopDepositScroll - 1] == 1)
                    {
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = apple;
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_name"); 
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().text = "";
                    }
                    else if (currentData.GetComponent<CurrentDataScript>().items[i + shopDepositScroll - 1] == 2)
                    {
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = lightPotion;
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_name"); 
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().text = "";
                    }
                    else if (currentData.GetComponent<CurrentDataScript>().items[i + shopDepositScroll - 1] == 3)
                    {
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = resurrectPotion;
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_name"); 
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().text = "";
                    }
                }
                else
                {
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                }
            }
        }
        else if (shopPickUpOpened)
        {
            //We deactivate the header
            shopUI.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            //We hide or show the arrows depending on the scroll
            if (shopPickUpScroll > 0) shopUI.transform.GetChild(0).transform.GetChild(8).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            else shopUI.transform.GetChild(0).transform.GetChild(8).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
            if ((shopPickUpScroll + 6) < currentData.GetComponent<CurrentDataScript>().StoredItemSize()) shopUI.transform.GetChild(0).transform.GetChild(9).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            else shopUI.transform.GetChild(0).transform.GetChild(9).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
            for (int i = 1; i < 7; i++)
            {
                if (i < currentData.GetComponent<CurrentDataScript>().StoredItemSize() + 1)
                {
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                    if (currentData.GetComponent<CurrentDataScript>().storedItems[i + shopPickUpScroll - 1] == 1)
                    {
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = apple;
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_name"); 
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().text = "";
                    }
                    else if (currentData.GetComponent<CurrentDataScript>().storedItems[i + shopPickUpScroll - 1] == 2)
                    {
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = lightPotion;
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_name"); 
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().text = "";
                    }
                    else if (currentData.GetComponent<CurrentDataScript>().storedItems[i + shopPickUpScroll - 1] == 3)
                    {
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().texture = resurrectPotion;
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_name"); 
                        shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().text = "";
                    }
                }
                else
                {
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                    shopUI.transform.GetChild(0).transform.GetChild(1 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                }
            }
        }
    }

    //Function to change the rest instruction text
    public void UpdateShopInstructionText()
    {
        if(shopMainOpened)
        { 
            if (shopMainSelecting == 1) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_buy_instructions"); 
            else if (shopMainSelecting == 2) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_sell_instructions"); 
            else if (shopMainSelecting == 3) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_store_instructions"); 
            else if (shopMainSelecting == 4) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_shop_takeout_instructions"); 
        }
        else if (shopBuyOpened)
        {
            if (!shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].isBadge)
            {
                if (shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].id == 1) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_apple"); 
                else if (shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].id == 2) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_lightpotion"); 
                else if (shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].id == 3) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_resurrectpotion"); 
            }
            else
            {
                if (shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].id == 1) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_lightsword"); 
                else if (shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].id == 2) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_multistrikesword"); 
                else if (shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].id == 3) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_lightshuriken"); 
                else if (shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].id == 4) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_fireshuriken"); 
                else if (shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].id == 5) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_hpup"); 
                else if (shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].id == 6) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_lpup"); 
                else if (shopItems[ActualShopItemPos(shopBuySelecting + shopBuyScroll - 1)].id == 7) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_comphpup"); 
            }
        }
        else if (shopSellOpened)
        {
            if (!shopGems)
            {
                if (currentData.GetComponent<CurrentDataScript>().items[shopSellSelecting + shopSellScroll - 1] == 1) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_apple"); 
                else if (currentData.GetComponent<CurrentDataScript>().items[shopSellSelecting + shopSellScroll - 1] == 2) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_lightpotion"); 
                else if (currentData.GetComponent<CurrentDataScript>().items[shopSellSelecting + shopSellScroll - 1] == 3) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_resurrectpotion"); 
            }
            else
            {
                if (gems.gems[FindGemInPos(shopSellSelecting) + shopSellScroll - 1].id == 1) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_lightsword");
                else if (gems.gems[FindGemInPos(shopSellSelecting) + shopSellScroll - 1].id == 2) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_multistrikesword"); 
                else if (gems.gems[FindGemInPos(shopSellSelecting) + shopSellScroll - 1].id == 3) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_lightshuriken");
                else if (gems.gems[FindGemInPos(shopSellSelecting) + shopSellScroll - 1].id == 4) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_fireshuriken");
                else if (gems.gems[FindGemInPos(shopSellSelecting) + shopSellScroll - 1].id == 5) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_hpup");
                else if (gems.gems[FindGemInPos(shopSellSelecting) + shopSellScroll - 1].id == 6) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_lpup");
                else if (gems.gems[FindGemInPos(shopSellSelecting) + shopSellScroll - 1].id == 7) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_comphpup");
            }
        }
        else if (shopDepositOpened)
        {
            if (currentData.GetComponent<CurrentDataScript>().items[shopDepositSelecting + shopDepositScroll - 1] == 1) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_apple"); 
            else if (currentData.GetComponent<CurrentDataScript>().items[shopDepositSelecting + shopDepositScroll - 1] == 2) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_lightpotion");
            else if (currentData.GetComponent<CurrentDataScript>().items[shopDepositSelecting + shopDepositScroll - 1] == 3) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_resurrectpotion");
        }
        else if (shopPickUpOpened)
        {
            if (currentData.GetComponent<CurrentDataScript>().storedItems[shopPickUpSelecting + shopPickUpScroll - 1] == 1) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_apple");
            else if (currentData.GetComponent<CurrentDataScript>().storedItems[shopPickUpSelecting + shopPickUpScroll - 1] == 2) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_lightpotion");
            else if (currentData.GetComponent<CurrentDataScript>().storedItems[shopPickUpSelecting + shopPickUpScroll - 1] == 3) shopUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_items_resurrectpotion");
        }
    }

    //Function to know the real position of the item on the shop item list
    public int ActualShopItemPos(int pos)
    {
        bool notFound = true;
        int pastGems = 0;
        int i = -1;
        while ( i < shopItems.Length && notFound)
        {
            i++;
            if ((shopItems[i].isBadge && currentData.GetComponent<CurrentDataScript>().IsGemFound(shopItems[i].id)) || (!shopItems[i].isBadge && shopGems) || (shopItems[i].isBadge && !shopGems)) pastGems += 1;
            if (i - pastGems == pos) notFound = false;
        }
        return i;
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

    //Function to set the next dialogue
    public void SetNextDialogue(Dialogue d)
    {
        nextDialogue = d;
    }

    

    //Function to set the picked object
    public void SetPickedObject(GameObject o)
    {
        pickedObject = o;
        pickedObject.SetActive(false);
        pickingObject = true;
    }

    //Function to activate the throw item action
    public void FullItems()
    {
        fullItems = true;
    }

    //Function to show the picked object
    public void ShowPickedObject(int isRight)
    {
        showItem = true;
        pickItemUI.SetActive(true);
        if (isRight == 1)
        {
            pickedObject.SetActive(true);
            if(pickedObject.tag == "Gem")
            {
                pickedObject.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.52f, transform.position.z);
                pickedObject.transform.localScale = new Vector3(0.15f, 0.15f, 1.0f);
                pickItemUI.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_pickup_1") + pickedObject.GetComponent<WorldObjectScript>().itemName + currentData.GetComponent<LangResolverScript>().ResolveText("world_pickup_2");
                pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = pickedObject.GetComponent<WorldObjectScript>().itemDescription;
            }
            else if (pickedObject.tag == "Item")
            {
                pickedObject.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.52f, transform.position.z);
                pickedObject.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
                pickItemUI.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_pickup_1") + pickedObject.GetComponent<WorldObjectScript>().itemName + currentData.GetComponent<LangResolverScript>().ResolveText("world_pickup_2");
                pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = pickedObject.GetComponent<WorldObjectScript>().itemDescription;
                itemRight = true;
            }
        }
        else
        {
            pickedObject.SetActive(true);
            if (pickedObject.tag == "Gem")
            {
                pickedObject.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.52f, transform.position.z);
                pickedObject.transform.localScale = new Vector3(0.15f, 0.15f, 1.0f);
                pickItemUI.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_pickup_1") + pickedObject.GetComponent<WorldObjectScript>().itemName + currentData.GetComponent<LangResolverScript>().ResolveText("world_pickup_2");
                pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = pickedObject.GetComponent<WorldObjectScript>().itemDescription;
            }
            else if (pickedObject.tag == "Item")
            {
                pickedObject.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.52f, transform.position.z);
                pickedObject.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
                pickItemUI.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_pickup_1") + pickedObject.GetComponent<WorldObjectScript>().itemName + currentData.GetComponent<LangResolverScript>().ResolveText("world_pickup_2");
                pickItemUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = pickedObject.GetComponent<WorldObjectScript>().itemDescription;
                itemRight = false;
            }
        }
        if (fullItems) pickItemUI.transform.GetChild(2).gameObject.SetActive(true);
    }

    //A function to set the shop items
    public void SetShopItems(Item[] i)
    {
        shopItems = i;
    }

    //Function to set the text on the first strike UI. 1-> player, 2-> companion, 3-> enemy
    public void SetFirstStrikeUI(int user)
    {
        firstStrikeUI.SetActive(true);
        if (user == 1 || user == 2)
        {
            firstStrikeUI.GetComponent<Image>().color = new Color(0.427451f, 0.8784314f, 0.4557848f, 1.0f);
            firstStrikeUI.transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_firststrike_player");
        }
        else
        {
            firstStrikeUI.GetComponent<Image>().color = new Color(0.8784314f, 0.4419824f, 0.427451f, 1.0f);
            firstStrikeUI.transform.GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_firststrike_enemy");
        }
    }

    //Function to deactivate the first strike ui
    public void DeactivateFirstStrikeUI()
    {
        firstStrikeUI.SetActive(false);
    }
}
