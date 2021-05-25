using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGemScript : MonoBehaviour
{
    //The canvas
    private GameObject canvas;
    //A boolean to know if the coin is already picked up
    private bool picked;
    //The current data
    private GameObject currentData;
    //The id of the gem
    [SerializeField] private int id;
    //The name of the gem in every language
    public string nameEnglish;
    public string nameSpanish;
    public string nameBasque;
    //The description of the gem in every language
    public string descriptionEnglish;
    public string descriptionSpanish;
    public string descriptionBasque;

    void Start()
    {
        currentData = GameObject.Find("CurrentData");
        canvas = GameObject.Find("Canvas");
        picked = false;
        if (currentData.GetComponent<CurrentDataScript>().IsGemFound(id)) Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && !picked)
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            picked = true;
            currentData.GetComponent<CurrentDataScript>().SetGemFound(id);
            other.GetComponent<Animator>().SetBool("Pick", true);
            other.GetComponent<WorldPlayerMovementScript>().SetPickedObject(gameObject);
        }
    }

}
