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
    //The rect transform of the arrow
    private RectTransform arrow; 
    //The UI offset
    private Vector2 uiOffset;
    //The canvas
    private GameObject canvas;
    //The speaker
    private Transform speaker;
    //The viewport position;
    private Vector2 viewportPosition;
    //The proportional position;
    private Vector2 proportionalPosition;

    //We find the next button and the text areas
    void Start()
    {
        dialogueText = GameObject.Find("DialogueText").GetComponent<Text>();
        next = GameObject.Find("DialogueNext");
        canvas = GameObject.Find("Canvas");
        arrow = transform.GetChild(2).GetComponent<RectTransform>(); 
        uiOffset = new Vector2((float)canvas.transform.GetComponent<RectTransform>().sizeDelta.x / 2f, (float)canvas.transform.GetComponent<RectTransform>().sizeDelta.y / 2f);
    }

    //Function to make the dialogue box appear
    public void appear()
    {
        dialogueText.enabled = true;
        next.GetComponent<Image>().color = new Color(next.GetComponent<Image>().color.r, next.GetComponent<Image>().color.g, next.GetComponent<Image>().color.b, 0.0f);

        viewportPosition = Camera.main.WorldToViewportPoint(speaker.position);
        proportionalPosition = new Vector2(viewportPosition.x * canvas.transform.GetComponent<RectTransform>().sizeDelta.x, 0.0f);

        // Set the position and remove the screen offset
        arrow.localPosition = new Vector2( proportionalPosition.x - uiOffset.x, -135.09f);

    }
    private void Update()
    {
        if (dialogueText.enabled)
        {
            viewportPosition = Camera.main.WorldToViewportPoint(speaker.position);
            proportionalPosition = new Vector2(viewportPosition.x * canvas.transform.GetComponent<RectTransform>().sizeDelta.x, 0.0f);

            // Set the position and remove the screen offset
            arrow.localPosition = new Vector2(proportionalPosition.x - uiOffset.x, -135.09f);
        }
        
    }

    //Function to make the dialogue box disappear
    public void disappear()
    {
        dialogueText.enabled = false;
        next.GetComponent<Image>().color = new Color(next.GetComponent<Image>().color.r, next.GetComponent<Image>().color.g, next.GetComponent<Image>().color.b, 0.0f);
    }

    //Function to set the speaker
    public void SetSpeaker(Transform s)
    {
        speaker = s;
    }
}
