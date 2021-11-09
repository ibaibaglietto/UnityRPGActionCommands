using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFlagsScript : MonoBehaviour
{
    //1-1
    private Transform JailGuard;
    private Transform JailDoor;
    private GameObject JailTrigger;
    private Transform JailCompanionNPC;
    private Transform JailCompanion;
    public Material buttonPressed;
    //1-2
    private GameObject storageItem1;
    private GameObject storageItem2;
    //1-3
    private GameObject cityItem1;
    private GameObject cityGem1;
    private GameObject cityCoin1;
    private GameObject cityCoin2;
    private GameObject cityCoin3;
    private GameObject cityCoin4;
    private GameObject cityCoin5;
    private GameObject cityCoin6;
    private GameObject cityCoin7;
    private GameObject cityCoin8;
    private GameObject cityCoin9;
    private GameObject cityCoin10;
    private GameObject cityCoin11;
    private GameObject cityCoin12;
    //1-4
    private GameObject brokenBridgeItem1;
    private GameObject brokenBridgeItem2;
    private GameObject brokenBridgeCoin1;
    private GameObject brokenBridgeCoin2;
    private GameObject brokenBridgeCoin3;
    private GameObject brokenBridgeCoin4;
    private GameObject brokenBridgeCoin5;
    private GameObject brokenBridgeCoin6;
    private GameObject brokenBridgeCoin7;
    private GameObject brokenBridgeCoin8;
    private GameObject brokenBridgeCoin9;
    private GameObject brokenBridgeCoin10;
    private GameObject brokenBridgeCoin11;
    private GameObject brokenBridgeCoin12;
    private GameObject brokenBridgeCoin13;
    private GameObject brokenBridgeCoin14;
    private GameObject brokenBridgeCoin15;
    private GameObject brokenBridgeCoin16;
    //1-5
    private GameObject citySideItem1;
    private GameObject citySideGem1;
    private GameObject citySideCoin1;
    private GameObject citySideCoin2;
    private GameObject citySideCoin3;
    private GameObject citySideCoin4;
    private GameObject citySideCoin5;
    private GameObject citySideCoin6;
    private GameObject citySideCoin7;
    private GameObject citySideCoin8;
    private GameObject citySideCoin9;
    private GameObject citySideCoin10;
    private GameObject citySideCoin11;
    private GameObject citySideCoin12;
    private GameObject citySideCoin13;
    private GameObject citySideCoin14;
    private GameObject citySideCoin15;
    private GameObject citySideCoin16;
    private GameObject citySideCoin17;
    private GameObject citySideCoin18;
    private GameObject citySideCoin19;
    private GameObject citySideCoin20;
    private GameObject citySideCoin21;
    private GameObject citySideCoin22;
    private GameObject citySideCoin23;
    private GameObject citySideCoin24;
    //1-6
    private GameObject waterItem1;
    private GameObject waterEnemy1;
    private GameObject waterEnemy2;
    private GameObject waterCompanion;
    private GameObject waterBattleTrigger1;
    private GameObject waterBattleTrigger2;
    //1-7
    private GameObject bridge1Coin1;
    private GameObject bridge1Coin2;
    private GameObject bridge1Coin3;
    private GameObject bridge1Coin4;
    private GameObject bridge1Coin5;
    private GameObject bridge1Coin6;
    private GameObject bridge1Coin7;
    private GameObject bridge1Coin8;
    private GameObject bridge1Coin9;
    private GameObject bridge1Coin10;
    private GameObject bridge1Coin11;
    private GameObject bridge1Coin12;
    private GameObject bridge1Coin13;
    private GameObject bridge1Coin14;
    private GameObject bridge1Coin15;
    private GameObject bridge1Coin16;
    private GameObject bridge1Coin17;
    private GameObject bridge1Coin18;
    private GameObject bridge1Coin19;
    private GameObject bridge1Coin20;
    private GameObject bridge1Coin21;
    private GameObject bridge1Coin22;
    private GameObject bridge1Coin23;
    private GameObject bridge1Coin24;
    //1-8
    private GameObject bridge2Coin1;
    private GameObject bridge2Coin2;
    private GameObject bridge2Coin3;
    private GameObject bridge2Coin4;
    private GameObject bridge2Coin5;
    private GameObject bridge2Coin6;
    private GameObject bridge2Coin7;
    private GameObject bridge2Coin8;
    private GameObject bridge2Coin9;
    private GameObject bridge2Coin10;
    private GameObject bridge2Coin11;
    private GameObject bridge2Coin12;
    private GameObject bridge2Coin13;
    private GameObject bridge2Coin14;
    private GameObject bridge2Coin15;
    private GameObject bridge2Coin16;
    private GameObject bridge2Coin17;
    private GameObject bridge2Coin18;
    private GameObject bridge2Coin19;
    private GameObject bridge2Coin20;
    private GameObject bridge2Coin21;
    private GameObject bridge2Coin22;
    private GameObject bridge2Coin23;
    private GameObject bridge2Coin24;
    private GameObject bridge2Coin25;
    private GameObject bridge2Coin26;
    private GameObject bridge2Coin27;
    private GameObject bridge2Coin28;
    private GameObject bridge2Coin29;
    private GameObject bridge2Coin30;
    private GameObject bridge2Coin31;
    private GameObject bridge2Coin32;
    private GameObject bridge2Coin33;
    private GameObject bridge2Coin34;
    private GameObject bridge2Coin35;
    private GameObject bridge2Coin36;
    //1-10
    private GameObject doorItem1;
    private GameObject doorCoin1;
    private GameObject doorCoin2;
    private GameObject doorCoin3;
    private GameObject doorCoin4;
    private GameObject doorCoin5;
    private GameObject doorCoin6;
    private GameObject doorCoin7;
    private GameObject doorCoin8;
    private GameObject doorCoin9;
    private GameObject doorCoin10;
    private GameObject doorCoin11;
    private GameObject doorCoin12;
    private GameObject doorCoin13;
    private GameObject doorCoin14;
    //1-11
    private GameObject base1Item1;
    private GameObject base1Item2;
    private GameObject base1Coin1;
    private GameObject base1Coin2;
    private GameObject base1Coin3;
    private GameObject base1Coin4;
    private GameObject base1Coin5;
    private GameObject base1Coin6;
    private GameObject base1Coin7;
    private GameObject base1Coin8;
    private GameObject base1Coin9;
    //1-12
    private GameObject base2Item1;
    private GameObject base2Item2;
    private GameObject base2Gem1;
    private GameObject base2Coin1;
    private GameObject base2Coin2;
    private GameObject base2Coin3;
    private GameObject base2Coin4;
    private GameObject base2Coin5;
    private GameObject base2Coin6;
    private GameObject base2Coin7;
    private GameObject base2Coin8;
    private GameObject base2Coin9;
    private GameObject base2Coin10;
    private GameObject base2Coin11;
    private GameObject base2Coin12;
    private GameObject base2Coin13;
    private GameObject base2Coin14;
    private GameObject base2Coin15;
    private GameObject base2Coin16;
    private GameObject base2Coin17;
    private GameObject base2Coin18;
    private GameObject base2Coin19;
    private GameObject base2Coin20;
    private GameObject base2Coin21;
    private GameObject base2Door;
    private GameObject base2DialogueTrigger;
    //1-13
    private GameObject base3Trigger1;
    private GameObject base3Trigger2;
    private GameObject base3Boss;
    private GameObject base3Enemy1;
    private GameObject base3Enemy2;
    private GameObject base3Enemy3;

    void OnEnable()
    {
        SceneManager.sceneLoaded += CheckFlags;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= CheckFlags;
    }

    void CheckFlags(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(scene.name);
        if (scene.name == "1-1")
        {
            JailGuard = GameObject.Find("BanditWorld").transform;
            JailDoor = GameObject.Find("Jail").transform;
            JailTrigger = GameObject.Find("BattleTrigger");
            JailCompanionNPC = GameObject.Find("PrisonerAdventurer").transform;
            JailCompanion = GameObject.Find("CompanionWorld").transform;
            if (gameObject.GetComponent<CurrentDataScript>().clearJail == 1)
            {
                Destroy(JailGuard.gameObject);
                JailDoor.GetComponent<Animator>().SetBool("Opened", true);
                Destroy(JailTrigger);
                Destroy(JailCompanionNPC.gameObject);
                JailCompanion.GetComponent<Rigidbody>().useGravity = true;
                JailCompanion.GetComponent<BoxCollider>().enabled = true;
                JailCompanion.GetComponent<SphereCollider>().enabled = true;
                JailCompanion.GetChild(0).GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                JailDoor.GetChild(6).GetComponent<MeshRenderer>().material = buttonPressed;
                JailDoor.GetChild(6).GetChild(0).GetComponent<BoxCollider>().enabled = false;
            }
        }
        else if (SceneManager.GetActiveScene().name == "1-2")
        {
            storageItem1 = GameObject.Find("LightPotionItem");
            storageItem2 = GameObject.Find("AppleItem");
            if (gameObject.GetComponent<CurrentDataScript>().storageItem1 == 1) Destroy(storageItem1);
            if (gameObject.GetComponent<CurrentDataScript>().storageItem2 == 1) Destroy(storageItem2);
        }
        else if (SceneManager.GetActiveScene().name == "1-3")
        {
            cityItem1 = GameObject.Find("ResurrectPotiontem");
            cityGem1 = GameObject.Find("MultistrikeSwordGem");
            cityCoin1 = GameObject.Find("Coin1");
            cityCoin2 = GameObject.Find("Coin2");
            cityCoin3 = GameObject.Find("Coin3");
            cityCoin4 = GameObject.Find("Coin4");
            cityCoin5 = GameObject.Find("Coin5");
            cityCoin6 = GameObject.Find("Coin6");
            cityCoin7 = GameObject.Find("Coin7");
            cityCoin8 = GameObject.Find("Coin8");
            cityCoin9 = GameObject.Find("Coin9");
            cityCoin10 = GameObject.Find("Coin10");
            cityCoin11 = GameObject.Find("Coin11");
            cityCoin12 = GameObject.Find("Coin12");
            if (gameObject.GetComponent<CurrentDataScript>().cityItem1 == 1) Destroy(cityItem1);
            if (gameObject.GetComponent<CurrentDataScript>().cityGem1 == 1) Destroy(cityGem1);
            if (gameObject.GetComponent<CurrentDataScript>().cityCoin1 == 1) Destroy(cityCoin1);
            if (gameObject.GetComponent<CurrentDataScript>().cityCoin2 == 1) Destroy(cityCoin2);
            if (gameObject.GetComponent<CurrentDataScript>().cityCoin3 == 1) Destroy(cityCoin3);
            if (gameObject.GetComponent<CurrentDataScript>().cityCoin4 == 1) Destroy(cityCoin4);
            if (gameObject.GetComponent<CurrentDataScript>().cityCoin5 == 1) Destroy(cityCoin5);
            if (gameObject.GetComponent<CurrentDataScript>().cityCoin6 == 1) Destroy(cityCoin6);
            if (gameObject.GetComponent<CurrentDataScript>().cityCoin7 == 1) Destroy(cityCoin7);
            if (gameObject.GetComponent<CurrentDataScript>().cityCoin8 == 1) Destroy(cityCoin8);
            if (gameObject.GetComponent<CurrentDataScript>().cityCoin9 == 1) Destroy(cityCoin9);
            if (gameObject.GetComponent<CurrentDataScript>().cityCoin10 == 1) Destroy(cityCoin10);
            if (gameObject.GetComponent<CurrentDataScript>().cityCoin11 == 1) Destroy(cityCoin11);
            if (gameObject.GetComponent<CurrentDataScript>().cityCoin12 == 1) Destroy(cityCoin12);
        }
        else if (SceneManager.GetActiveScene().name == "1-4")
        {
            brokenBridgeItem1 = GameObject.Find("AppleItem");
            brokenBridgeItem2 = GameObject.Find("LightPotionItem");
            brokenBridgeCoin1 = GameObject.Find("Coin1");
            brokenBridgeCoin2 = GameObject.Find("Coin2");
            brokenBridgeCoin3 = GameObject.Find("Coin3");
            brokenBridgeCoin4 = GameObject.Find("Coin4");
            brokenBridgeCoin5 = GameObject.Find("Coin5");
            brokenBridgeCoin6 = GameObject.Find("Coin6");
            brokenBridgeCoin7 = GameObject.Find("Coin7");
            brokenBridgeCoin8 = GameObject.Find("Coin8");
            brokenBridgeCoin9 = GameObject.Find("Coin9");
            brokenBridgeCoin10 = GameObject.Find("Coin10");
            brokenBridgeCoin11 = GameObject.Find("Coin11");
            brokenBridgeCoin12 = GameObject.Find("Coin12");
            brokenBridgeCoin13 = GameObject.Find("Coin13");
            brokenBridgeCoin14 = GameObject.Find("Coin14");
            brokenBridgeCoin15 = GameObject.Find("Coin15");
            brokenBridgeCoin16 = GameObject.Find("Coin16");
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeItem1 == 1) Destroy(brokenBridgeItem1);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeItem2 == 1) Destroy(brokenBridgeItem2);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin1 == 1) Destroy(brokenBridgeCoin1);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin2 == 1) Destroy(brokenBridgeCoin2);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin3 == 1) Destroy(brokenBridgeCoin3);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin4 == 1) Destroy(brokenBridgeCoin4);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin5 == 1) Destroy(brokenBridgeCoin5);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin6 == 1) Destroy(brokenBridgeCoin6);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin7 == 1) Destroy(brokenBridgeCoin7);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin8 == 1) Destroy(brokenBridgeCoin8);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin9 == 1) Destroy(brokenBridgeCoin9);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin10 == 1) Destroy(brokenBridgeCoin10);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin11 == 1) Destroy(brokenBridgeCoin11);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin12 == 1) Destroy(brokenBridgeCoin12);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin13 == 1) Destroy(brokenBridgeCoin13);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin14 == 1) Destroy(brokenBridgeCoin14);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin15 == 1) Destroy(brokenBridgeCoin15);
            if (gameObject.GetComponent<CurrentDataScript>().brokenBridgeCoin16 == 1) Destroy(brokenBridgeCoin16);
        }
        else if (SceneManager.GetActiveScene().name == "1-5")
        {
            citySideItem1 = GameObject.Find("AppleItem");
            citySideGem1 = GameObject.Find("LPUpGem");
            citySideCoin1 = GameObject.Find("Coin1");
            citySideCoin2 = GameObject.Find("Coin2");
            citySideCoin3 = GameObject.Find("Coin3");
            citySideCoin4 = GameObject.Find("Coin4");
            citySideCoin5 = GameObject.Find("Coin5");
            citySideCoin6 = GameObject.Find("Coin6");
            citySideCoin7 = GameObject.Find("Coin7");
            citySideCoin8 = GameObject.Find("Coin8");
            citySideCoin9 = GameObject.Find("Coin9");
            citySideCoin10 = GameObject.Find("Coin10");
            citySideCoin11 = GameObject.Find("Coin11");
            citySideCoin12 = GameObject.Find("Coin12");
            citySideCoin13 = GameObject.Find("Coin13");
            citySideCoin14 = GameObject.Find("Coin14");
            citySideCoin15 = GameObject.Find("Coin15");
            citySideCoin16 = GameObject.Find("Coin16");
            citySideCoin17 = GameObject.Find("Coin17");
            citySideCoin18 = GameObject.Find("Coin18");
            citySideCoin19 = GameObject.Find("Coin19");
            citySideCoin20 = GameObject.Find("Coin20");
            citySideCoin21 = GameObject.Find("Coin21");
            citySideCoin22 = GameObject.Find("Coin22");
            citySideCoin23 = GameObject.Find("Coin23");
            citySideCoin24 = GameObject.Find("Coin24");
            if (gameObject.GetComponent<CurrentDataScript>().citySideItem1 == 1) Destroy(citySideItem1);
            if (gameObject.GetComponent<CurrentDataScript>().citySideGem1 == 1) Destroy(citySideGem1);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin1 == 1) Destroy(citySideCoin1);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin2 == 1) Destroy(citySideCoin2);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin3 == 1) Destroy(citySideCoin3);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin4 == 1) Destroy(citySideCoin4);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin5 == 1) Destroy(citySideCoin5);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin6 == 1) Destroy(citySideCoin6);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin7 == 1) Destroy(citySideCoin7);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin8 == 1) Destroy(citySideCoin8);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin9 == 1) Destroy(citySideCoin9);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin10 == 1) Destroy(citySideCoin10);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin11 == 1) Destroy(citySideCoin11);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin12 == 1) Destroy(citySideCoin12);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin13 == 1) Destroy(citySideCoin13);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin14 == 1) Destroy(citySideCoin14);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin15 == 1) Destroy(citySideCoin15);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin16 == 1) Destroy(citySideCoin16);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin17 == 1) Destroy(citySideCoin17);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin18 == 1) Destroy(citySideCoin18);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin19 == 1) Destroy(citySideCoin19);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin20 == 1) Destroy(citySideCoin20);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin21 == 1) Destroy(citySideCoin21);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin22 == 1) Destroy(citySideCoin22);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin23 == 1) Destroy(citySideCoin23);
            if (gameObject.GetComponent<CurrentDataScript>().citySideCoin24 == 1) Destroy(citySideCoin24);
        }
        else if (SceneManager.GetActiveScene().name == "1-6")
        {
            waterItem1 = GameObject.Find("LightPotionItem");
            waterEnemy1 = GameObject.Find("EvilWizardWorld (1)");
            waterEnemy2 = GameObject.Find("EvilWizardWorld");
            waterCompanion = GameObject.Find("Wizard");
            waterBattleTrigger1 = GameObject.Find("BattleTrigger1");
            waterBattleTrigger1 = GameObject.Find("BattleTrigger2");
            if (gameObject.GetComponent<CurrentDataScript>().waterItem1 == 1) Destroy(waterItem1);
            if (gameObject.GetComponent<CurrentDataScript>().waterClear == 1)
            {
                Destroy(waterEnemy1);
                Destroy(waterEnemy2);
                Destroy(waterCompanion);
                Destroy(waterBattleTrigger1);
                Destroy(waterBattleTrigger2);
            }
        }
        else if (SceneManager.GetActiveScene().name == "1-7")
        {
            bridge1Coin1 = GameObject.Find("Coin1");
            bridge1Coin2 = GameObject.Find("Coin2");
            bridge1Coin3 = GameObject.Find("Coin3");
            bridge1Coin4 = GameObject.Find("Coin4");
            bridge1Coin5 = GameObject.Find("Coin5");
            bridge1Coin6 = GameObject.Find("Coin6");
            bridge1Coin7 = GameObject.Find("Coin7");
            bridge1Coin8 = GameObject.Find("Coin8");
            bridge1Coin9 = GameObject.Find("Coin9");
            bridge1Coin10 = GameObject.Find("Coin10");
            bridge1Coin11 = GameObject.Find("Coin11");
            bridge1Coin12 = GameObject.Find("Coin12");
            bridge1Coin13 = GameObject.Find("Coin13");
            bridge1Coin14 = GameObject.Find("Coin14");
            bridge1Coin15 = GameObject.Find("Coin15");
            bridge1Coin16 = GameObject.Find("Coin16");
            bridge1Coin17 = GameObject.Find("Coin17");
            bridge1Coin18 = GameObject.Find("Coin18");
            bridge1Coin19 = GameObject.Find("Coin19");
            bridge1Coin20 = GameObject.Find("Coin20");
            bridge1Coin21 = GameObject.Find("Coin21");
            bridge1Coin22 = GameObject.Find("Coin22");
            bridge1Coin23 = GameObject.Find("Coin23");
            bridge1Coin24 = GameObject.Find("Coin24");
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin1 == 1) Destroy(bridge1Coin1);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin2 == 1) Destroy(bridge1Coin2);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin3 == 1) Destroy(bridge1Coin3);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin4 == 1) Destroy(bridge1Coin4);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin5 == 1) Destroy(bridge1Coin5);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin6 == 1) Destroy(bridge1Coin6);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin7 == 1) Destroy(bridge1Coin7);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin8 == 1) Destroy(bridge1Coin8);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin9 == 1) Destroy(bridge1Coin9);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin10 == 1) Destroy(bridge1Coin10);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin11 == 1) Destroy(bridge1Coin11);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin12 == 1) Destroy(bridge1Coin12);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin13 == 1) Destroy(bridge1Coin13);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin14 == 1) Destroy(bridge1Coin14);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin15 == 1) Destroy(bridge1Coin15);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin16 == 1) Destroy(bridge1Coin16);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin17 == 1) Destroy(bridge1Coin17);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin18 == 1) Destroy(bridge1Coin18);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin19 == 1) Destroy(bridge1Coin19);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin20 == 1) Destroy(bridge1Coin20);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin21 == 1) Destroy(bridge1Coin21);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin22 == 1) Destroy(bridge1Coin22);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin23 == 1) Destroy(bridge1Coin23);
            if (gameObject.GetComponent<CurrentDataScript>().bridge1Coin24 == 1) Destroy(bridge1Coin24);
        }
        else if (SceneManager.GetActiveScene().name == "1-8")
        {
            bridge2Coin1 = GameObject.Find("Coin1");
            bridge2Coin2 = GameObject.Find("Coin2");
            bridge2Coin3 = GameObject.Find("Coin3");
            bridge2Coin4 = GameObject.Find("Coin4");
            bridge2Coin5 = GameObject.Find("Coin5");
            bridge2Coin6 = GameObject.Find("Coin6");
            bridge2Coin7 = GameObject.Find("Coin7");
            bridge2Coin8 = GameObject.Find("Coin8");
            bridge2Coin9 = GameObject.Find("Coin9");
            bridge2Coin10 = GameObject.Find("Coin10");
            bridge2Coin11 = GameObject.Find("Coin11");
            bridge2Coin12 = GameObject.Find("Coin12");
            bridge2Coin13 = GameObject.Find("Coin13");
            bridge2Coin14 = GameObject.Find("Coin14");
            bridge2Coin15 = GameObject.Find("Coin15");
            bridge2Coin16 = GameObject.Find("Coin16");
            bridge2Coin17 = GameObject.Find("Coin17");
            bridge2Coin18 = GameObject.Find("Coin18");
            bridge2Coin19 = GameObject.Find("Coin19");
            bridge2Coin20 = GameObject.Find("Coin20");
            bridge2Coin21 = GameObject.Find("Coin21");
            bridge2Coin22 = GameObject.Find("Coin22");
            bridge2Coin23 = GameObject.Find("Coin23");
            bridge2Coin24 = GameObject.Find("Coin24");
            bridge2Coin25 = GameObject.Find("Coin25");
            bridge2Coin26 = GameObject.Find("Coin26");
            bridge2Coin27 = GameObject.Find("Coin27");
            bridge2Coin28 = GameObject.Find("Coin28");
            bridge2Coin29 = GameObject.Find("Coin29");
            bridge2Coin30 = GameObject.Find("Coin30");
            bridge2Coin31 = GameObject.Find("Coin31");
            bridge2Coin32 = GameObject.Find("Coin32");
            bridge2Coin33 = GameObject.Find("Coin33");
            bridge2Coin34 = GameObject.Find("Coin34");
            bridge2Coin35 = GameObject.Find("Coin35");
            bridge2Coin36 = GameObject.Find("Coin36");
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin1 == 1) Destroy(bridge2Coin1);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin2 == 1) Destroy(bridge2Coin2);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin3 == 1) Destroy(bridge2Coin3);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin4 == 1) Destroy(bridge2Coin4);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin5 == 1) Destroy(bridge2Coin5);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin6 == 1) Destroy(bridge2Coin6);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin7 == 1) Destroy(bridge2Coin7);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin8 == 1) Destroy(bridge2Coin8);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin9 == 1) Destroy(bridge2Coin9);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin10 == 1) Destroy(bridge2Coin10);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin11 == 1) Destroy(bridge2Coin11);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin12 == 1) Destroy(bridge2Coin12);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin13 == 1) Destroy(bridge2Coin13);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin14 == 1) Destroy(bridge2Coin14);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin15 == 1) Destroy(bridge2Coin15);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin16 == 1) Destroy(bridge2Coin16);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin17 == 1) Destroy(bridge2Coin17);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin18 == 1) Destroy(bridge2Coin18);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin19 == 1) Destroy(bridge2Coin19);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin20 == 1) Destroy(bridge2Coin20);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin21 == 1) Destroy(bridge2Coin21);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin22 == 1) Destroy(bridge2Coin22);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin23 == 1) Destroy(bridge2Coin23);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin24 == 1) Destroy(bridge2Coin24);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin25 == 1) Destroy(bridge2Coin25);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin26 == 1) Destroy(bridge2Coin26);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin27 == 1) Destroy(bridge2Coin27);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin28 == 1) Destroy(bridge2Coin28);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin29 == 1) Destroy(bridge2Coin29);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin30 == 1) Destroy(bridge2Coin30);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin31 == 1) Destroy(bridge2Coin31);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin32 == 1) Destroy(bridge2Coin32);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin33 == 1) Destroy(bridge2Coin33);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin34 == 1) Destroy(bridge2Coin34);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin35 == 1) Destroy(bridge2Coin35);
            if (gameObject.GetComponent<CurrentDataScript>().bridge2Coin36 == 1) Destroy(bridge2Coin36);
        }
        else if (SceneManager.GetActiveScene().name == "1-10")
        {
            doorItem1 = GameObject.Find("ResurrectPotionItem");
            doorCoin1 = GameObject.Find("Coin1");
            doorCoin2 = GameObject.Find("Coin2");
            doorCoin3 = GameObject.Find("Coin3");
            doorCoin4 = GameObject.Find("Coin4");
            doorCoin5 = GameObject.Find("Coin5");
            doorCoin6 = GameObject.Find("Coin6");
            doorCoin7 = GameObject.Find("Coin7");
            doorCoin8 = GameObject.Find("Coin8");
            doorCoin9 = GameObject.Find("Coin9");
            doorCoin10 = GameObject.Find("Coin10");
            doorCoin11 = GameObject.Find("Coin11");
            doorCoin12 = GameObject.Find("Coin12");
            doorCoin13 = GameObject.Find("Coin13");
            doorCoin14 = GameObject.Find("Coin14");
            if (gameObject.GetComponent<CurrentDataScript>().doorItem1 == 1) Destroy(doorItem1);
            if (gameObject.GetComponent<CurrentDataScript>().doorCoin1 == 1) Destroy(doorCoin1);
            if (gameObject.GetComponent<CurrentDataScript>().doorCoin2 == 1) Destroy(doorCoin2);
            if (gameObject.GetComponent<CurrentDataScript>().doorCoin3 == 1) Destroy(doorCoin3);
            if (gameObject.GetComponent<CurrentDataScript>().doorCoin4 == 1) Destroy(doorCoin4);
            if (gameObject.GetComponent<CurrentDataScript>().doorCoin5 == 1) Destroy(doorCoin5);
            if (gameObject.GetComponent<CurrentDataScript>().doorCoin6 == 1) Destroy(doorCoin6);
            if (gameObject.GetComponent<CurrentDataScript>().doorCoin7 == 1) Destroy(doorCoin7);
            if (gameObject.GetComponent<CurrentDataScript>().doorCoin8 == 1) Destroy(doorCoin8);
            if (gameObject.GetComponent<CurrentDataScript>().doorCoin9 == 1) Destroy(doorCoin9);
            if (gameObject.GetComponent<CurrentDataScript>().doorCoin10 == 1) Destroy(doorCoin10);
            if (gameObject.GetComponent<CurrentDataScript>().doorCoin11 == 1) Destroy(doorCoin11);
            if (gameObject.GetComponent<CurrentDataScript>().doorCoin12 == 1) Destroy(doorCoin12);
            if (gameObject.GetComponent<CurrentDataScript>().doorCoin13 == 1) Destroy(doorCoin13);
            if (gameObject.GetComponent<CurrentDataScript>().doorCoin14 == 1) Destroy(doorCoin14);
        }
        else if (SceneManager.GetActiveScene().name == "1-11")
        {
            base1Item1 = GameObject.Find("AppleItem");
            base1Item2 = GameObject.Find("LightPotionItem");
            base1Coin1 = GameObject.Find("Coin1");
            base1Coin2 = GameObject.Find("Coin2");
            base1Coin3 = GameObject.Find("Coin3");
            base1Coin4 = GameObject.Find("Coin4");
            base1Coin5 = GameObject.Find("Coin5");
            base1Coin6 = GameObject.Find("Coin6");
            base1Coin7 = GameObject.Find("Coin7");
            base1Coin8 = GameObject.Find("Coin8");
            base1Coin9 = GameObject.Find("Coin9");
            if (gameObject.GetComponent<CurrentDataScript>().base1Item1 == 1) Destroy(base1Item1);
            if (gameObject.GetComponent<CurrentDataScript>().base1Item2 == 1) Destroy(base1Item2);
            if (gameObject.GetComponent<CurrentDataScript>().base1Coin1 == 1) Destroy(base1Coin1);
            if (gameObject.GetComponent<CurrentDataScript>().base1Coin2 == 1) Destroy(base1Coin2);
            if (gameObject.GetComponent<CurrentDataScript>().base1Coin3 == 1) Destroy(base1Coin3);
            if (gameObject.GetComponent<CurrentDataScript>().base1Coin4 == 1) Destroy(base1Coin4);
            if (gameObject.GetComponent<CurrentDataScript>().base1Coin5 == 1) Destroy(base1Coin5);
            if (gameObject.GetComponent<CurrentDataScript>().base1Coin6 == 1) Destroy(base1Coin6);
            if (gameObject.GetComponent<CurrentDataScript>().base1Coin7 == 1) Destroy(base1Coin7);
            if (gameObject.GetComponent<CurrentDataScript>().base1Coin8 == 1) Destroy(base1Coin8);
            if (gameObject.GetComponent<CurrentDataScript>().base1Coin9 == 1) Destroy(base1Coin9);
        }
        else if (SceneManager.GetActiveScene().name == "1-12")
        {
            base2Item1 = GameObject.Find("AppleItem");
            base2Item2 = GameObject.Find("LightPotionItem");
            base2Coin1 = GameObject.Find("Coin1");
            base2Coin2 = GameObject.Find("Coin2");
            base2Coin3 = GameObject.Find("Coin3");
            base2Coin4 = GameObject.Find("Coin4");
            base2Coin5 = GameObject.Find("Coin5");
            base2Coin6 = GameObject.Find("Coin6");
            base2Coin7 = GameObject.Find("Coin7");
            base2Coin8 = GameObject.Find("Coin8");
            base2Coin9 = GameObject.Find("Coin9");
            base2Coin10 = GameObject.Find("Coin10");
            base2Coin11 = GameObject.Find("Coin11");
            base2Coin12 = GameObject.Find("Coin12");
            base2Coin13 = GameObject.Find("Coin13");
            base2Coin14 = GameObject.Find("Coin14");
            base2Coin15 = GameObject.Find("Coin15");
            base2Coin16 = GameObject.Find("Coin16");
            base2Coin17 = GameObject.Find("Coin17");
            base2Coin18 = GameObject.Find("Coin18");
            base2Coin19 = GameObject.Find("Coin19");
            base2Coin20 = GameObject.Find("Coin20");
            base2Coin21 = GameObject.Find("Coin21");
            base2Door = GameObject.Find("Door");
            base2DialogueTrigger = GameObject.Find("PlatformCompanionDialogueTrigger");
            if (gameObject.GetComponent<CurrentDataScript>().base2Item1 == 1) Destroy(base2Item1);
            if (gameObject.GetComponent<CurrentDataScript>().base2Item2 == 1) Destroy(base2Item2);
            if (gameObject.GetComponent<CurrentDataScript>().base2Gem1 == 1) Destroy(base2Gem1);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin1 == 1) Destroy(base2Coin1);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin2 == 1) Destroy(base2Coin2);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin3 == 1) Destroy(base2Coin3);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin4 == 1) Destroy(base2Coin4);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin5 == 1) Destroy(base2Coin5);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin6 == 1) Destroy(base2Coin6);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin7 == 1) Destroy(base2Coin7);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin8 == 1) Destroy(base2Coin8);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin9 == 1) Destroy(base2Coin9);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin10 == 1) Destroy(base2Coin10);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin11 == 1) Destroy(base2Coin11);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin12 == 1) Destroy(base2Coin12);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin13 == 1) Destroy(base2Coin13);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin14 == 1) Destroy(base2Coin14);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin15 == 1) Destroy(base2Coin15);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin16 == 1) Destroy(base2Coin16);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin17 == 1) Destroy(base2Coin17);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin18 == 1) Destroy(base2Coin18);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin19 == 1) Destroy(base2Coin19);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin20 == 1) Destroy(base2Coin20);
            if (gameObject.GetComponent<CurrentDataScript>().base2Coin21 == 1) Destroy(base2Coin21);
            if (gameObject.GetComponent<CurrentDataScript>().base2DoorOpened == 1) base2Door.GetComponent<Animator>().SetBool("Opened", true);
            if (gameObject.GetComponent<CurrentDataScript>().base2Dialogue == 1) Destroy(base2DialogueTrigger);
        }
        else if (SceneManager.GetActiveScene().name == "1-13")
        {
            base3Trigger1 = GameObject.Find("Conversation1");
            base3Trigger2 = GameObject.Find("Conversation2");
            base3Boss = GameObject.Find("BanditBossWorld");
            base3Enemy1 = GameObject.Find("BanditNPCBoss1");
            base3Enemy2 = GameObject.Find("BanditNPCBoss2");
            base3Enemy3 = GameObject.Find("BanditNPCBoss3");
            if (gameObject.GetComponent<CurrentDataScript>().base3BossDefeated == 1) 
            {
                Destroy(base3Trigger1);
                Destroy(base3Trigger2);
                Destroy(base3Boss);
                Destroy(base3Enemy1);
                Destroy(base3Enemy2);
                Destroy(base3Enemy3);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
