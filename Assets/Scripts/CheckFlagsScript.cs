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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
