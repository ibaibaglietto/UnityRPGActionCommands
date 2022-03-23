using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PauseCompanionsScript : MonoBehaviour
{

    //The video player
    private VideoPlayer videoPlayer;
    private bool isAdventurer;

    //The clips
    [SerializeField] private VideoClip adventurer1Clip;
    [SerializeField] private VideoClip adventurer2Clip;
    [SerializeField] private VideoClip adventurer3Clip;
    [SerializeField] private VideoClip adventurer4Clip;
    [SerializeField] private VideoClip adventurer5Clip;
    [SerializeField] private VideoClip wizard1Clip;
    [SerializeField] private VideoClip wizard2Clip;
    [SerializeField] private VideoClip wizard3Clip;
    [SerializeField] private VideoClip wizard4Clip;
    [SerializeField] private VideoClip wizard5Clip;

    void Start()
    {
        videoPlayer = transform.parent.Find("PauseExtraMenuCompanionsImages").Find("Video Player").GetComponent<VideoPlayer>();
    }

    //Function to show an animation of the gem attack
    public void ShowAttack(int id)
    {
        if(isAdventurer)
        {
            if (id == 1) videoPlayer.clip = adventurer1Clip;
            else if (id == 2) videoPlayer.clip = adventurer2Clip;
            else if (id == 3) videoPlayer.clip = adventurer3Clip;
            else if (id == 4) videoPlayer.clip = adventurer4Clip;
            else if (id == 5) videoPlayer.clip = adventurer5Clip;
        }
        else
        {
            if (id == 1) videoPlayer.clip = wizard1Clip;
            else if (id == 2) videoPlayer.clip = wizard2Clip;
            else if (id == 3) videoPlayer.clip = wizard3Clip;
            else if (id == 4) videoPlayer.clip = wizard4Clip;
            else if (id == 5) videoPlayer.clip = wizard5Clip;
        }
    }
}
