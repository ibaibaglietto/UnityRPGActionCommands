using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JarScript : MonoBehaviour
{
    //The actual fill
    private float fill;
    //The battle controller
    private GameObject battleController;

    void Start()
    {
        //We find the battle controller and initialize the fill
        battleController = GameObject.Find("BattleController");
        fill = 0.0f;
    }


    void FixedUpdate()
    {
        //We slowly fill the jar to the actual fill
        if (transform.GetChild(2).GetComponent<Image>().fillAmount < fill) transform.GetChild(2).GetComponent<Image>().fillAmount += 0.004f;
    }

    //Function to increase the actual fill of the jar
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("redSoul"))
        {
            transform.GetChild(4).GetComponent<AudioSource>().Play();
            battleController.GetComponent<BattleController>().GatherRedSoul();
            fill += 0.1f;
            Destroy(other.gameObject);
        }
    }
}
