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

    //Radius of the overlap circle to determine if grounded
    const float groundedRadius = 0.07f;
    //Whether or not the player is grounded.
    private bool grounded;
    //A bool to know if the player has jumped
    private bool jumped;
    //The animator
    Animator animator;


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
        jumped = false;
        //We find the animator
        animator = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        //Detect the direction we want the player to move and save it
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
        if(speedX!=0 || speedZ!=0) animator.SetBool("Moving", true);
        else animator.SetBool("Moving", false);
        animator.SetFloat("SpeedZ", speedZ);
        animator.SetFloat("SpeedX", speedX);
        //Make the player jump when space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jumped = true;
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 200.0f, 0.0f));
            animator.SetBool("isJumping", true);
        }
        //We check if the player is falling
        if (gameObject.GetComponent<Rigidbody>().velocity.y < -0.01f) animator.SetBool("isFalling", true);
        else if (animator.GetBool("isFalling")) animator.SetBool("isFalling", false);
    }

    private void FixedUpdate()
    {
        bool wasGrounded = grounded;
        grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        Collider[] colliders = Physics.OverlapSphere(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }

        //move the player on the direction we saved previously
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speedX * 3, gameObject.GetComponent<Rigidbody>().velocity.y, speedZ * 3);
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
