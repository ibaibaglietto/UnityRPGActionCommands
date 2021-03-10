using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingScript : MonoBehaviour
{
    //The sprites of the rings
    [SerializeField] private Sprite redRingTop;
    [SerializeField] private Sprite redRingFront;
    [SerializeField] private Sprite yellowRingTop;
    [SerializeField] private Sprite yellowRingFront;
    [SerializeField] private Sprite greenRingTop;
    [SerializeField] private Sprite greenRingFront;
    //The battle controller
    private GameObject battleController;
    //A boolean to know if the ring has been crossed
    private bool crossed;
    //A boolean to know the color of the ring
    private bool isRed;
    //The new X of the ring
    private float newX;
    //The transform of the other part of the ring
    private Transform topRing;
    //The transform of the previous ring
    private Transform prevRing;
    //The X position of the previous ring
    private float prevX;
    //The number of times the ring has respawned
    private int respawnNumb;
    void Start()
    {
        respawnNumb = 0;
        battleController = GameObject.Find("BattleController");
        crossed = false;
    }
    private void Update()
    {
        //If the ring reaches the end of the screen 
        if (GetComponent<RectTransform>().anchoredPosition.y > 3.0f) 
        {
            //If the soul crossed it we generate another ring at the top
            if (crossed)
            {
                prevX = prevRing.GetComponent<RectTransform>().anchoredPosition.x;
                if (prevX < (-2.0f + 0.25f * respawnNumb)) prevX = -2.0f;
                else if (prevX > (2.0f - 0.25f * respawnNumb)) prevX = 2.0f;
                newX = Random.Range(prevX - (3.0f + 0.25f * respawnNumb), prevX + (3.0f + 0.25f * respawnNumb));
                if (Random.Range(0.0f, 1.0f) < 0.5f)
                {
                    isRed = true;
                    topRing.GetComponent<Image>().sprite = redRingTop;
                    GetComponent<Image>().sprite = redRingFront;
                }
                else
                {
                    isRed = false;
                    topRing.GetComponent<Image>().sprite = yellowRingTop;
                    GetComponent<Image>().sprite = yellowRingFront;
                }
                if (respawnNumb < 8) respawnNumb += 1;
                topRing.GetComponent<RectTransform>().anchoredPosition = new Vector2(newX, -5.0f);
                GetComponent<RectTransform>().anchoredPosition = new Vector2(newX, -5.0f + 0.009f);
                crossed = false;
            }
            //If not we end the regeneration attack
            else
            {
                battleController.GetComponent<BattleController>().EndRegenerationAttack();
            }
        }
    }
    //Function to cross a ring
    public void Cross()
    {
        topRing.GetComponent<Image>().sprite = greenRingTop;
        GetComponent<Image>().sprite = greenRingFront;
        crossed = true;
    }
    //Function to know if a ring is crossed
    public bool IsCrossed()
    {
        return crossed;
    }
    //Function to set the top ring
    public void SetTopRing(Transform top)
    {
        topRing = top;
    }
    //Function to find the previous ring
    public void SetPrevRing(Transform ring)
    {
        prevRing = ring;
    }
    //function to set the color of the ring.
    public void SetColor(bool red)
    {
        isRed = red;
        if (red) GetComponent<Image>().sprite = redRingFront;
        else GetComponent<Image>().sprite = yellowRingFront;
    }
    //function to get the color of the ring
    public bool GetColor()
    {
        return isRed;
    }
}
