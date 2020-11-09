using System.Collections;
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
    //The player
    private GameObject battleController;
    //The speak sound source
    //private AudioSource speak;
    //The sentences
    private Queue<string> sentences;

    void Start()
    {
        //We find everything
        battleController = GameObject.Find("BattleController");
        sentences = new Queue<string>();
        nameText = GameObject.Find("DialogueName").GetComponent<Text>();
        dialogueText = GameObject.Find("DialogueText").GetComponent<Text>();
        animator = GameObject.Find("DialogueBox").GetComponent<Animator>();
        next = GameObject.Find("DialogueNext");
        next.GetComponent<Image>().color = new Color(next.GetComponent<Image>().color.r, next.GetComponent<Image>().color.g, next.GetComponent<Image>().color.b, 0.0f);
        nameText.enabled = false;
        dialogueText.enabled = false;
        //speak = GameObject.Find("ConversationSource").GetComponent<AudioSource>();
    }

    //Function to start the dialogue
    public void StartDialogue(Dialogue dialogue)
    {
        //We put the talking state
        battleController.GetComponent<BattleController>().SetTalking(true);
        //We open the dialogue box
        animator.SetBool("Open", true);
        //Set the name of the speaker
        nameText.text = dialogue.name;
        //Clear the previous sentences
        sentences.Clear();
        //Check the language and enqueue the sentences
        if (PlayerPrefs.GetInt("language") == 0)
        {
            foreach (string sentence in dialogue.sentencesEnglish)
            {
                sentences.Enqueue(sentence);
            }
        }
        else if (PlayerPrefs.GetInt("language") == 1)
        {
            foreach (string sentence in dialogue.sentencesSpanish)
            {
                sentences.Enqueue(sentence);
            }
        }
        else if (PlayerPrefs.GetInt("language") == 2)
        {
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
            EndDialogue();
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
            //speak.Play();
            dialogueText.text += letter;
            yield return new WaitForFixedUpdate();
        }
        next.GetComponent<Image>().color = new Color(next.GetComponent<Image>().color.r, next.GetComponent<Image>().color.g, next.GetComponent<Image>().color.b, 1.0f);
    }

    //Function to end the dialogue
    void EndDialogue()
    {
        battleController.GetComponent<BattleController>().SetTalking(false);
        animator.SetBool("Open", false);
        battleController.GetComponent<BattleController>().EndPlayerTurn(2);
    }
}
