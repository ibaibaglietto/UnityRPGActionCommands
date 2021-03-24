using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldCompanionMovementScript : MonoBehaviour
{
    //The direction the companion is moving. 0-> not moving, 1-> right, 2-> left, 3 -> up, 4 -> down
    private float speedX;
    private float speedZ;
    //A mask determining what is ground to the character
    [SerializeField] private LayerMask whatIsGround;
    //A position marking where to check if the player is grounded.
    [SerializeField] private Transform groundCheck;

    //Radius of the overlap circle to determine if grounded
    const float groundedRadius = 0.07f;
    //Whether or not the player is grounded.
    private bool grounded;
    //The animator
    Animator animator;

    private GameObject player;

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
        //We initialize the variables
        speedX = 0.0f;
        speedZ = 0.0f;
        //We find the animator
        animator = gameObject.GetComponent<Animator>();
        //We find the player
        player = GameObject.Find("PlayerWorld");
    }


    void Update()
    {
        if((Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z) > 1.5f && !animator.GetBool("Moving")) || (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z) > 1.25f && animator.GetBool("Moving")) || (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z) > 0.75f && animator.GetBool("isJumping")))
        {
            //Detect where the player is and move the companion towards them
            speedX = (player.transform.position.x - gameObject.transform.position.x) / (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z)) * (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) / 1.5f);
            speedZ = (player.transform.position.z - gameObject.transform.position.z) / (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z)) * (Mathf.Abs(player.transform.position.z - gameObject.transform.position.z) / 1.5f);
        }
        else
        {
            speedX = 0.0f;
            speedZ = 0.0f;
        }

        animator.SetFloat("SpeedX", speedX);

        if (speedX != 0 || speedZ != 0) animator.SetBool("Moving", true);
        else animator.SetBool("Moving", false);
        if((player.transform.position.x - gameObject.transform.position.x) >= 0.0f) animator.SetBool("PlayerRight", true);
        else animator.SetBool("PlayerRight", false);

        if(player.transform.position.y > gameObject.transform.position.y + 0.4f && !animator.GetBool("isJumping"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 600.0f, 0.0f));
            animator.SetBool("isJumping", true);
        }

        if (gameObject.GetComponent<Rigidbody>().velocity.y < -0.01f) animator.SetBool("isFalling", true);
        else if (animator.GetBool("isFalling")) animator.SetBool("isFalling", false);

        /*
        //Make the player jump when space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && grounded && gameObject.GetComponent<Rigidbody>().velocity.y > -0.1f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 600.0f, 0.0f));
            animator.SetBool("isJumping", true);
        }
        //We check if the player is falling
        if (gameObject.GetComponent<Rigidbody>().velocity.y < -0.01f) animator.SetBool("isFalling", true);
        else if (animator.GetBool("isFalling")) animator.SetBool("isFalling", false);
        */

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

    private void FixedUpdate()
    {
        //move the player on the direction we saved previously
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speedX * 4, gameObject.GetComponent<Rigidbody>().velocity.y, speedZ * 4);
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
