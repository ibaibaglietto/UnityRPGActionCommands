using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public bool facingRight;
    public float animationFrame;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
