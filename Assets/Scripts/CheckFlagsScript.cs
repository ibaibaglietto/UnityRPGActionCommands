using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFlagsScript : MonoBehaviour
{
    //1-1
    public Transform JailGuard;
    public Transform JailDoor;
    public GameObject JailTrigger;
    public Transform JailCompanionNPC;
    public Transform JailCompanion;
    public Material buttonPressed;
    //1-2
    public GameObject storageItem1;
    public GameObject storageItem2;
    //1-3
    public GameObject cityItem1;
    public GameObject cityGem1;
    public GameObject cityCoin1;
    public GameObject cityCoin2;
    public GameObject cityCoin3;
    public GameObject cityCoin4;
    public GameObject cityCoin5;
    public GameObject cityCoin6;
    public GameObject cityCoin7;
    public GameObject cityCoin8;
    public GameObject cityCoin9;
    public GameObject cityCoin10;
    public GameObject cityCoin11;
    public GameObject cityCoin12;
    //1-4
    public GameObject brokenBridgeItem1;
    public GameObject brokenBridgeItem2;
    public GameObject brokenBridgeCoin1;
    public GameObject brokenBridgeCoin2;
    public GameObject brokenBridgeCoin3;
    public GameObject brokenBridgeCoin4;
    public GameObject brokenBridgeCoin5;
    public GameObject brokenBridgeCoin6;
    public GameObject brokenBridgeCoin7;
    public GameObject brokenBridgeCoin8;
    public GameObject brokenBridgeCoin9;
    public GameObject brokenBridgeCoin10;
    public GameObject brokenBridgeCoin11;
    public GameObject brokenBridgeCoin12;
    public GameObject brokenBridgeCoin13;
    public GameObject brokenBridgeCoin14;
    public GameObject brokenBridgeCoin15;
    public GameObject brokenBridgeCoin16;
    //1-5
    public GameObject citySideItem1;
    public GameObject citySideGem1;
    public GameObject citySideCoin1;
    public GameObject citySideCoin2;
    public GameObject citySideCoin3;
    public GameObject citySideCoin4;
    public GameObject citySideCoin5;
    public GameObject citySideCoin6;
    public GameObject citySideCoin7;
    public GameObject citySideCoin8;
    public GameObject citySideCoin9;
    public GameObject citySideCoin10;
    public GameObject citySideCoin11;
    public GameObject citySideCoin12;
    public GameObject citySideCoin13;
    public GameObject citySideCoin14;
    public GameObject citySideCoin15;
    public GameObject citySideCoin16;
    public GameObject citySideCoin17;
    public GameObject citySideCoin18;
    public GameObject citySideCoin19;
    public GameObject citySideCoin20;
    public GameObject citySideCoin21;
    public GameObject citySideCoin22;
    public GameObject citySideCoin23;
    public GameObject citySideCoin24;
    //1-6
    public GameObject waterItem1;
    public GameObject waterEnemy1;
    public GameObject waterEnemy2;
    public GameObject waterCompanion;
    public GameObject waterBattleTrigger1;
    public GameObject waterBattleTrigger2;
    //1-7
    public GameObject bridge1Coin1;
    public GameObject bridge1Coin2;
    public GameObject bridge1Coin3;
    public GameObject bridge1Coin4;
    public GameObject bridge1Coin5;
    public GameObject bridge1Coin6;
    public GameObject bridge1Coin7;
    public GameObject bridge1Coin8;
    public GameObject bridge1Coin9;
    public GameObject bridge1Coin10;
    public GameObject bridge1Coin11;
    public GameObject bridge1Coin12;
    public GameObject bridge1Coin13;
    public GameObject bridge1Coin14;
    public GameObject bridge1Coin15;
    public GameObject bridge1Coin16;
    public GameObject bridge1Coin17;
    public GameObject bridge1Coin18;
    public GameObject bridge1Coin19;
    public GameObject bridge1Coin20;
    public GameObject bridge1Coin21;
    public GameObject bridge1Coin22;
    public GameObject bridge1Coin23;
    public GameObject bridge1Coin24;


    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "1-1")
        {
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
        else if(SceneManager.GetActiveScene().name == "1-2")
        {
            if (gameObject.GetComponent<CurrentDataScript>().storageItem1 == 1) Destroy(storageItem1);
            if (gameObject.GetComponent<CurrentDataScript>().storageItem2 == 1) Destroy(storageItem2);
        }
        else if (SceneManager.GetActiveScene().name == "1-3")
        {
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

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
