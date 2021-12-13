using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCompanionHelpScript : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        //We find the player
        player = GameObject.Find("PlayerWorld");
    }

    //Function to end the change animation
    public void EndChange()
    {
        GetComponent<Animator>().SetBool("changing", false);
    }

    //Function to change the transparency
    public void ChangeTransparency(float alpha)
    {
        GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, alpha);
        player.GetComponent<SpriteRenderer>().color = new Color(player.GetComponent<SpriteRenderer>().color.r, player.GetComponent<SpriteRenderer>().color.g, player.GetComponent<SpriteRenderer>().color.b, alpha);
        if(alpha == 0.0f) transform.parent.transform.position = new Vector3(player.transform.position.x, transform.parent.transform.position.y, player.transform.position.z); 
    }

    //Function to change the companion
    public void ChangeNewCompanion(int comp)
    {
        transform.parent.GetComponent<WorldCompanionMovementScript>().ChangeNewCompanion(comp);
    }
}
