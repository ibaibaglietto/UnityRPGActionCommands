using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseItemsScript : MonoBehaviour
{

    private int itemUIScroll = 0;
    //The current data
    private CurrentDataScript currentData;
    //The images of the items
    [SerializeField] private Texture2D apple;
    [SerializeField] private Texture2D lightPotion;
    [SerializeField] private Texture2D resurrectPotion;

    // Start is called before the first frame update
    void Awake()
    {
        currentData = GameObject.Find("CurrentData").GetComponent<CurrentDataScript>();
    }

    private void OnEnable()
    {
        CreateItemsUI();
    }


    //Function to create the items UI
    public void CreateItemsUI()
    {
        //We hide or show the arrows depending on the scroll
        if (itemUIScroll > 0) transform.GetChild(11).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        else transform.GetChild(11).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        if ((itemUIScroll + 6) < currentData.GetComponent<CurrentDataScript>().itemSize()) transform.GetChild(12).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        else transform.GetChild(12).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        for (int i = 1; i < 7; i++)
        {
            if (i < currentData.GetComponent<CurrentDataScript>().itemSize() + 1)
            {
                transform.GetChild(4 + i).GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                transform.GetChild(4 + i).GetChild(2).GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                if (currentData.GetComponent<CurrentDataScript>().items[i + itemUIScroll - 1] == 1)
                {
                    transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().texture = apple;
                    transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_apple_name");
                }
                else if (currentData.GetComponent<CurrentDataScript>().items[i + itemUIScroll - 1] == 2)
                {
                    transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().texture = lightPotion;
                    transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_lightpotion_name");
                }
                else if (currentData.GetComponent<CurrentDataScript>().items[i + itemUIScroll - 1] == 3)
                {
                    transform.GetChild(4 + i).GetChild(1).GetComponent<RawImage>().texture = resurrectPotion;
                    transform.GetChild(4 + i).GetChild(0).GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText("combat_item_resurrectionpotion_name");
                }
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
