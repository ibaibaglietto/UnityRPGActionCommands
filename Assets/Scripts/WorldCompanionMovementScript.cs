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
    //The tp check
    private Transform tpCheck;

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
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
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
        //We put the correct values on the animator variables
        animator.SetFloat("SpeedX", speedX);
        if (speedX != 0 || speedZ != 0) animator.SetBool("Moving", true);
        else animator.SetBool("Moving", false);
        if((player.transform.position.x - gameObject.transform.position.x) >= 0.0f) animator.SetBool("PlayerRight", true);
        else animator.SetBool("PlayerRight", false);
        //If the player has jumped or is higher than the companion they jump 
        if(player.transform.position.y > gameObject.transform.position.y + 0.6f && !animator.GetBool("isJumping") && Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z) > 1.0f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 600.0f, 0.0f));
            animator.SetBool("isJumping", true);
        }
        //If the y velocity is negative the companion is falling
        if (gameObject.GetComponent<Rigidbody>().velocity.y < -0.01f) animator.SetBool("isFalling", true);
        else if (animator.GetBool("isFalling")) animator.SetBool("isFalling", false);

        bool wasGrounded = grounded;
        grounded = false;

        // The companion is grounded if a circlecast to the groundcheck position hits anything designated as ground
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
        if ((Mathf.Abs(speedX) > 0 || Mathf.Abs(speedZ) > 0) && (Mathf.Abs(gameObject.GetComponent<Rigidbody>().velocity.x) < 1.0f && Mathf.Abs(gameObject.GetComponent<Rigidbody>().velocity.z) < 1.0f) && (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) + Mathf.Abs(player.transform.position.y - gameObject.transform.position.y) + Mathf.Abs(player.transform.position.z - gameObject.transform.position.z) > 10.0f))
        {
            TpToPlayer();
        }
        //move the player on the direction we saved previously
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speedX * 4, gameObject.GetComponent<Rigidbody>().velocity.y, speedZ * 4);
    }

    //When the companion lands we uncheck the jumping and falling booleans
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

    //Function to tp the companion to the player
    private void TpToPlayer()
    {
        //We check if the player is moving in the x coord or in the z
        //X coord
        if (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) >= Mathf.Abs(player.transform.position.z - gameObject.transform.position.z))
        {
            //We check the direction of the movement
            //Moving right
            if (player.transform.position.x - gameObject.transform.position.x >= 0.0f)
            {
                tpCheck = player.transform.Find("TpCheckLeft");
                if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                //If the natural position is blocked we check the positions of the other coord, trying not to block the path of the player
                //Moving up
                else if (player.transform.position.z - gameObject.transform.position.z >= 0.0f)
                {
                    tpCheck = player.transform.Find("TpCheckDown");
                    if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                    else
                    {
                        tpCheck = player.transform.Find("TpCheckUp");
                        if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        else
                        {
                            //If all the other positions are blocked we tp the companion in front of the player
                            tpCheck = player.transform.Find("TpCheckRight");
                            if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        }
                    }
                }
                //Moving down
                else
                {
                    tpCheck = player.transform.Find("TpCheckUp");
                    if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                    else
                    {
                        tpCheck = player.transform.Find("TpCheckDown");
                        if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        else
                        {
                            tpCheck = player.transform.Find("TpCheckRight");
                            if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        }
                    }
                }
            }
            //Moving left
            else
            {
                tpCheck = player.transform.Find("TpCheckRight");
                if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                //Moving up
                else if (player.transform.position.z - gameObject.transform.position.z >= 0.0f)
                {
                    tpCheck = player.transform.Find("TpCheckDown");
                    if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                    else
                    {
                        tpCheck = player.transform.Find("TpCheckUp");
                        if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        else
                        {
                            tpCheck = player.transform.Find("TpCheckLeft");
                            if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        }
                    }
                }
                //moving down
                else
                {
                    tpCheck = player.transform.Find("TpCheckUp");
                    if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                    else
                    {
                        tpCheck = player.transform.Find("TpCheckDown");
                        if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        else
                        {
                            tpCheck = player.transform.Find("TpCheckLeft");
                            if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        }
                    }
                }
            }
        }
        //Z coord
        else
        {
            //Moving up
            if (player.transform.position.z - gameObject.transform.position.z >= 0.0f)
            {
                tpCheck = player.transform.Find("TpCheckDown");
                if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                //Moving right
                else if (player.transform.position.x - gameObject.transform.position.x >= 0.0f)
                {
                    tpCheck = player.transform.Find("TpCheckLeft");
                    if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                    else
                    {
                        tpCheck = player.transform.Find("TpCheckRight");
                        if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        else
                        {
                            tpCheck = player.transform.Find("TpCheckUp");
                            if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        }
                    }
                }
                //Moving left
                else
                {
                    tpCheck = player.transform.Find("TpCheckRight");
                    if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                    else
                    {
                        tpCheck = player.transform.Find("TpCheckLeft");
                        if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        else
                        {
                            tpCheck = player.transform.Find("TpCheckUp");
                            if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        }
                    }
                }
            }
            //moving down
            else
            {
                tpCheck = player.transform.Find("TpCheckUp");
                if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                //Moving right
                else if (player.transform.position.x - gameObject.transform.position.x >= 0.0f)
                {
                    tpCheck = player.transform.Find("TpCheckLeft");
                    if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                    else
                    {
                        tpCheck = player.transform.Find("TpCheckRight");
                        if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        else
                        {
                            tpCheck = player.transform.Find("TpCheckDown");
                            if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        }
                    }
                }
                //Moving left
                else
                {
                    tpCheck = player.transform.Find("TpCheckRight");
                    if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                    else
                    {
                        tpCheck = player.transform.Find("TpCheckLeft");
                        if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        else
                        {
                            tpCheck = player.transform.Find("TpCheckDown");
                            if (tpCheck.GetComponent<TpCheckScript>().IsFree()) gameObject.transform.position = tpCheck.position;
                        }
                    }
                }
            }
        }
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", false);
    }
}
