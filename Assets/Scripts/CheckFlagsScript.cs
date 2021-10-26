using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFlagsScript : MonoBehaviour
{
    public Transform JailGuard;
    public Transform JailDoor;
    public GameObject JailTrigger;
    public Transform JailCompanionNPC;
    public Transform JailCompanion;
    public Material buttonPressed;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
