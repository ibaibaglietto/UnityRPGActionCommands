using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    //The next button and the text areas
    private GameObject next;
    private Text nameText;
    private Text dialogueText;

    //We find the next button and the text areas
    void Start()
    {
        nameText = GameObject.Find("DialogueName").GetComponent<Text>();
        dialogueText = GameObject.Find("DialogueText").GetComponent<Text>();
        next = GameObject.Find("DialogueNext");
    }

    //Function to make the dialogue box appear
    public void appear()
    {
        nameText.enabled = true;
        dialogueText.enabled = true;
        next.GetComponent<Image>().color = new Color(next.GetComponent<Image>().color.r, next.GetComponent<Image>().color.g, next.GetComponent<Image>().color.b, 0.0f);
    }

    //Function to make the dialogue box disappear
    public void disappear()
    {
        nameText.enabled = false;
        dialogueText.enabled = false;
        next.GetComponent<Image>().color = new Color(next.GetComponent<Image>().color.r, next.GetComponent<Image>().color.g, next.GetComponent<Image>().color.b, 0.0f);
    }
}
