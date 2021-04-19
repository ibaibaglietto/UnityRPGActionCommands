using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    //The on land event
    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void Awake()
    {
        
        //We initialize the onLandEvent
        if (OnLandEvent == null) OnLandEvent = new UnityEvent();
    }

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        canvas.GetComponent<WorldCanvasScript>().HideUI();
        //We initialize the variables
        speedX = 0.0f;
        speedZ = 0.0f;
        fled = false;
        //We find the animator
        animator = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        //Detect the direction we want the player to move and save it
        if(PlayerPrefs.GetInt("Battle") == 0)
        {
            if (Input.GetKey(KeyCode.UpArrow)) speedZ = 1.0f;
            else if (Input.GetKey(KeyCode.DownArrow)) speedZ = -1.0f;
            else speedZ = 0.0f;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speedX = 1.0f;
                animator.SetBool("RightLast", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
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
            if (Input.GetKeyDown(KeyCode.X) && !attacking)
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

    }

    private void FixedUpdate()
    {
        //move the player on the direction we saved previously
        if(!attacking && PlayerPrefs.GetInt("Battle") == 0) gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speedX * 4, gameObject.GetComponent<Rigidbody>().velocity.y, speedZ * 4);
        else gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, gameObject.GetComponent<Rigidbody>().velocity.y, 0.0f);
        if(PlayerPrefs.GetInt("Fled")==1 && PlayerPrefs.GetInt("Battle") == 0)
        {
            PlayerPrefs.SetInt("Fled", 0);
            fled = true;
            fledTime = Time.fixedTime;
        }
        if ((Time.fixedTime - fledTime) < 0)
        {
            
        }
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
}
