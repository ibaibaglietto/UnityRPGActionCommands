﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //The text areas
    private Text nameText;
    private Text dialogueText;
    //The animator of the dialogue box
    private Animator animator;
    //The next button
    private GameObject next;
    //The battlecontroller
    private GameObject battleController;
    //The speak sound source
    private AudioSource speak;
    //The player
    private GameObject player;
    //The sentences
    private Queue<string> sentences;
    //A boolean to know if it is a battle dialogue or a world one
    private bool battle;
    //The current data
    private GameObject currentData;

    void Start()
    {
        currentData = GameObject.Find("CurrentData");
        //We find everything
        sentences = new Queue<string>();
        nameText = GameObject.Find("DialogueName").GetComponent<Text>();
        dialogueText = GameObject.Find("DialogueText").GetComponent<Text>();
        animator = GameObject.Find("DialogueBox").GetComponent<Animator>();
        next = GameObject.Find("DialogueNext");
        nameText.enabled = false;
        dialogueText.enabled = false;
        speak = GameObject.Find("SpeakSource").GetComponent<AudioSource>();
    }

    //Function to start the world dialogue
    public void StartWorldDialogue(Dialogue dialogue)
    {
        battle = false;
        player = GameObject.Find("PlayerWorld");
        //We open the dialogue box
        animator.SetBool("Open", true);
        //Clear the previous sentences
        sentences.Clear();
        //Check the language and enqueue the sentences
        if (currentData.GetComponent<CurrentDataScript>().language == 1)
        {
            //Set the name of the speaker
            nameText.text = dialogue.nameEnglish;
            foreach (string sentence in dialogue.sentencesEnglish)
            {
                sentences.Enqueue(sentence);
            }
        }
        else if (currentData.GetComponent<CurrentDataScript>().language == 2)
        {
            //Set the name of the speaker
            nameText.text = dialogue.nameSpanish;
            foreach (string sentence in dialogue.sentencesSpanish)
            {
                sentences.Enqueue(sentence);
            }
        }
        else if (currentData.GetComponent<CurrentDataScript>().language == 3)
        {
            //Set the name of the speaker
            nameText.text = dialogue.nameBasque;
            foreach (string sentence in dialogue.sentencesBasque)
            {
                sentences.Enqueue(sentence);
            }
        }
        //Display the next sentence
        DisplayNextSentence();
    }

    //Function to start the battle dialogue
    public void StartBattleDialogue(Dialogue dialogue)
    {
        battle = true;
        battleController = GameObject.Find("BattleController");
        //We put the talking state
        battleController.GetComponent<BattleController>().SetTalking(true);
        //We open the dialogue box
        animator.SetBool("Open", true);
        //Clear the previous sentences
        sentences.Clear();
        //Check the language and enqueue the sentences
        if (currentData.GetComponent<CurrentDataScript>().language == 1)
        {
            //Set the name of the speaker
            nameText.text = dialogue.nameEnglish;
            foreach (string sentence in dialogue.sentencesEnglish)
            {
                sentences.Enqueue(sentence);
            }
        }
        else if (currentData.GetComponent<CurrentDataScript>().language == 2)
        {
            //Set the name of the speaker
            nameText.text = dialogue.nameSpanish;
            foreach (string sentence in dialogue.sentencesSpanish)
            {
                sentences.Enqueue(sentence);
            }
        }
        else if (currentData.GetComponent<CurrentDataScript>().language == 3)
        {
            //Set the name of the speaker
            nameText.text = dialogue.nameBasque;
            foreach (string sentence in dialogue.sentencesBasque)
            {
                sentences.Enqueue(sentence);
            }
        }
        //Display the next sentence
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        next.GetComponent<Image>().color = new Color(next.GetComponent<Image>().color.r, next.GetComponent<Image>().color.g, next.GetComponent<Image>().color.b, 0.0f);
        //When we dont have more sentences we end the dialogue
        if (sentences.Count == 0)
        {
            if (battle) EndBattleDialogue();
            else EndWorldDialogue();
            StopAllCoroutines();
            return;
        }
        //If we have more sentences we dequeue them and type them
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        //We stop the coroutines to be able to pass a sentence without reading it
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //Function to write a sentence letter by letter
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            speak.Play();
            dialogueText.text += letter;
            yield return new WaitForFixedUpdate();
        }
        next.GetComponent<Image>().color = new Color(next.GetComponent<Image>().color.r, next.GetComponent<Image>().color.g, next.GetComponent<Image>().color.b, 1.0f);
    }

    //Function to end the battle dialogue
    void EndBattleDialogue()
    {
        battleController.GetComponent<BattleController>().SetTalking(false);
        animator.SetBool("Open", false);
        battleController.GetComponent<BattleController>().EndPlayerTurn(2);
    }

    //Function to end the world dialogue
    void EndWorldDialogue()
    {
        animator.SetBool("Open", false);
        player.GetComponent<WorldPlayerMovementScript>().ShowRestUI();
    }
}
