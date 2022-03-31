using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    private GameObject currentData;
    [SerializeField] private Texture[] SkillsSprite;
    [SerializeField] private string[] adventurerSkillsName;
    [SerializeField] private string[] adventurerSkillsLp;
    [SerializeField] private string[] wizardSkillsName;
    [SerializeField] private string[] wizardSkillsLp;
    private int selectedCompanion;


    void Start()
    {
        currentData = GameObject.Find("CurrentData");
    }

    public void CreateCompanionAttackMenu(int sC)
    {
        selectedCompanion = sC;
        Transform pauseCompanionAttacks = transform.Find("PauseExtraMenu").Find("PauseExtraMenuCompanions");
        pauseCompanionAttacks.GetChild(8).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        pauseCompanionAttacks.GetChild(9).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        if (selectedCompanion == 0)
        {
            int number = currentData.GetComponent<CurrentDataScript>().adventurerLvl;

            for(int i = 0; i < 6; i++)
            {
                if(i < (number + 2))
                {
                    pauseCompanionAttacks.GetChild(2 + i).GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText(adventurerSkillsName[i]);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(1).GetComponent<RawImage>().texture = SkillsSprite[i];
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(1).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText(adventurerSkillsLp[i]);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(2).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
                else
                {
                    pauseCompanionAttacks.GetChild(2 + i).GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(1).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(2).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                }
            }
        }
        //Wizard
        else if (selectedCompanion == 1)
        {
            int number = currentData.GetComponent<CurrentDataScript>().wizardLvl;

            for (int i = 0; i < 6; i++)
            {
                if (i < (number + 2))
                {
                    pauseCompanionAttacks.GetChild(2 + i).GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText(wizardSkillsName[i]);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(1).GetComponent<RawImage>().texture = SkillsSprite[i];
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(1).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(2).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText(wizardSkillsLp[i]);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(2).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
                else
                {
                    pauseCompanionAttacks.GetChild(2 + i).GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(1).GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                    pauseCompanionAttacks.GetChild(2 + i).GetChild(2).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                }
            }
        }
    }

    public int GetSelectedCompanion()
    {
        return selectedCompanion;
    }


}
