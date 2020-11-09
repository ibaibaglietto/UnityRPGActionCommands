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
        next.SetActive(true);
    }

    //Function to make the dialogue box disappear
    public void disappear()
    {
        nameText.enabled = false;
        dialogueText.enabled = false;
        next.SetActive(false);
    }
}
