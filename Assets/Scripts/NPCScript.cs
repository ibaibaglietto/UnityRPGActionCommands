using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public bool facingRight;
    public float animationFrame;
    //The movement speed of the NPC
    private float speedX;
    private float speedZ;
    //The destination of the movement (x,z)
    private Vector2 destination;
    //A bool to know if the NPC is moving
    private bool moving;
    //A bool to set the NPC running to the right
    private bool runRight;
    //A bool to set the NPC running to the left
    private bool runLeft;
    //A bool to set the NPC rolling to the right
    private bool rollRight;
    //A bool to set the NPC rolling to the left
    private bool rollLeft;


    // Start is called before the first frame update
    void Start()
    {
        runRight = false;
        runLeft = false;
        moving = false;
        GetComponent<Animator>().SetBool("FacingRight", facingRight);
        GetComponent<Animator>().speed = 0f;
        if (facingRight)
        {
            GetComponent<Animator>().Play("IdleRight", 0, (1f / 4) * animationFrame);
        }
        else
        {
            GetComponent<Animator>().Play("IdleLeft", 0, (1f / 4) * animationFrame);
        }
        GetComponent<Animator>().speed = 1f;
        speedX = 0.0f;
        speedZ = 0.0f;
    }

    void Update()
    {
        if (moving)
        {
            if (transform.position.x > destination[0] + 0.5f) speedX = -1.0f;
            else if ((transform.position.x < destination[0] - 0.5f)) speedX = 1.0f;
            else speedX = 0.0f;
            if (transform.position.z > destination[1] + 0.5f) speedZ = -1.0f;
            else if ((transform.position.z < destination[1] - 0.5f)) speedZ = 1.0f;
            else speedZ = 0.0f;
            if (speedX != 0.0f || speedZ != 0.0f) GetComponent<Animator>().SetBool("Moving", true);
            else
            {
                moving = false;
                GetComponent<Animator>().SetBool("Moving", false);
            }
            if (speedX >= 0.0f) GetComponent<Animator>().SetBool("FacingRight", true);
            else GetComponent<Animator>().SetBool("FacingRight", false);
        }
        else if (runRight)
        {
            GetComponent<Animator>().SetBool("Moving", true);
            GetComponent<Animator>().SetBool("FacingRight", true);
        }
        else if (runLeft)
        {
            GetComponent<Animator>().SetBool("Moving", true);
            GetComponent<Animator>().SetBool("FacingRight", false);
        }
        else if (rollRight)
        {
            GetComponent<Animator>().SetBool("Rolling", true);
            GetComponent<Animator>().SetBool("FacingRight", true);
            GetComponent<Animator>().SetBool("Moving", false);
        }
        else if (rollLeft)
        {
            GetComponent<Animator>().SetBool("Rolling", true);
            GetComponent<Animator>().SetBool("FacingRight", false);
            GetComponent<Animator>().SetBool("Moving", false);
        }
        else GetComponent<Animator>().SetBool("Moving", false);
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speedX * 4, gameObject.GetComponent<Rigidbody>().velocity.y, speedZ * 4);
    }

    public void LookRight()
    {
        GetComponent<Animator>().SetBool("FacingRight", true);
    }
    public void LookLeft()
    {
        GetComponent<Animator>().SetBool("FacingRight", false);
    }

    public void RunRight()
    {
        runRight = true;
        runLeft = false;
    }
    public void RunLeft()
    {
        runLeft = true;
        runRight = false;
    }
    public void RollLeft()
    {
        runLeft = false;
        runRight = false;
        rollLeft = true;
        rollRight = false;
    }
    public void RollRight()
    {
        runLeft = false;
        runRight = false;
        rollLeft = false;
        rollRight = true;
    }
    public void StopRunning()
    {
        runLeft = false;
        runRight = false;
    }
    public void SetDestination(Vector2 dest)
    {
        moving = true;
        destination = dest;
    }

    public void SelfDeastroy()
    {
        Destroy(gameObject);
    }

}
