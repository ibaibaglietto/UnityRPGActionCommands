using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PauseGemsScript : MonoBehaviour
{
    public int gemUIScroll = 0;
    //The current data
    private CurrentDataScript currentData;
    //An array with all the gems
    private string[] allGems = { "Light Sword", "Multistrike Sword", "Light Shuriken", "Fire Shuriken", "HPUp", "LPUp", "CompHPUp" };
    private Gems gems;
    //The player
    private GameObject player;
    //The texts
    private Text gpCurrent;
    private Text gpMax;
    private Text gpText;
    //The clips
    [SerializeField] private VideoClip LightSwordClip;
    [SerializeField] private VideoClip MultistrikeSwordClip;
    [SerializeField] private VideoClip LightShurikenClip;
    [SerializeField] private VideoClip FireShurikenClip;
    //The video player
    private VideoPlayer videoPlayer;
    //The animator of the video
    private Animator videoAnimator;


    void Awake()
    {
        currentData = GameObject.Find("CurrentData").GetComponent<CurrentDataScript>();
        player = GameObject.Find("PlayerWorld");
        gems = player.GetComponent<WorldPlayerMovementScript>().gems;
        gpCurrent = transform.Find("PauseExtraMenuPlayerGemsAvailableGemPointsText").GetComponent<Text>();
        gpMax = transform.Find("PauseExtraMenuPlayerGemsTotalGemPointsText").GetComponent<Text>();
        gpText = transform.Find("PauseExtraMenuPlayerGemsText").GetComponent<Text>();
        videoPlayer = transform.parent.Find("PauseExtraMenuPlayerImage").Find("Video Player").GetComponent<VideoPlayer>();
        videoAnimator = transform.parent.Find("PauseExtraMenuPlayerImage").GetComponent<Animator>();
    }

    private void OnEnable()
    {
        //TODO: text translation
        CreateGemUI();
    }

    //Function to create the gem UI
    public void CreateGemUI()
    {
        gpCurrent.text = (3 + currentData.playerBadgeLvl * 3 - currentData.spentGP).ToString();
        gpMax.text = (3 + currentData.playerBadgeLvl * 3).ToString();
        //We hide or show the arrows depending on the scroll
        if (gemUIScroll > 0) transform.GetChild(11).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        else transform.GetChild(11).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        if ((gemUIScroll + 6) < currentData.GetComponent<CurrentDataScript>().availableGems) transform.GetChild(12).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        else transform.GetChild(12).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        //We search the gems for all the available spaces, if there are less than 6 we make those spaces disappear
        for (int i = 1; i < 7; i++)
        {
            if (i < currentData.GetComponent<CurrentDataScript>().availableGems + 1)
            {
                if (currentData.GetComponent<CurrentDataScript>().GemUsing(allGems[player.GetComponent<WorldPlayerMovementScript>().FindGemInPos(i) + gemUIScroll - 1], allGems) == 1) transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(0.0f, 1.0f, 0.0f, 1.0f);
                else if (gems.gems[player.GetComponent<WorldPlayerMovementScript>().FindGemInPos(i) + gemUIScroll - 1].points > ((currentData.GetComponent<CurrentDataScript>().playerBadgeLvl * 3 + 3) - currentData.GetComponent<CurrentDataScript>().spentGP)) transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
                else transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                transform.GetChild(4 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = gems.gems[player.GetComponent<WorldPlayerMovementScript>().FindGemInPos(i) + gemUIScroll - 1].nameSpanish[0];
                transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().texture = gems.gems[player.GetComponent<WorldPlayerMovementScript>().FindGemInPos(i) + gemUIScroll - 1].icon;
                transform.GetChild(4 + i).GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("world_rest_gems_GP") + " " + gems.gems[player.GetComponent<WorldPlayerMovementScript>().FindGemInPos(i) + gemUIScroll - 1].points.ToString();
            }
            else
            {
                transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                transform.GetChild(4 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
            }
        }
    }



    //Function to show an animation of the gem attack
    public void ShowAttack(int id)
    {
        videoAnimator.SetInteger("Id", gems.gems[player.GetComponent<WorldPlayerMovementScript>().FindGemInPos(id) + gemUIScroll - 1].id);
        if (gems.gems[player.GetComponent<WorldPlayerMovementScript>().FindGemInPos(id) + gemUIScroll - 1].id == 1) videoPlayer.clip = LightSwordClip;
        else if (gems.gems[player.GetComponent<WorldPlayerMovementScript>().FindGemInPos(id) + gemUIScroll - 1].id == 2) videoPlayer.clip = MultistrikeSwordClip;
        else if (gems.gems[player.GetComponent<WorldPlayerMovementScript>().FindGemInPos(id) + gemUIScroll - 1].id == 3) videoPlayer.clip = LightShurikenClip;
        else if (gems.gems[player.GetComponent<WorldPlayerMovementScript>().FindGemInPos(id) + gemUIScroll - 1].id == 4) videoPlayer.clip = FireShurikenClip;
    }


}
