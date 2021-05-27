using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectScript : MonoBehaviour
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
        if (gameObject.tag == "Gem" && currentData.GetComponent<CurrentDataScript>().IsGemFound(id)) Destroy(gameObject);
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
            if (gameObject.tag == "Gem") currentData.GetComponent<CurrentDataScript>().SetGemFound(id);
            else if (gameObject.tag == "Item")
            {
                if (currentData.GetComponent<CurrentDataScript>().itemSize() < 20) currentData.GetComponent<CurrentDataScript>().AddItem(id);
                else other.GetComponent<WorldPlayerMovementScript>().FullItems();
            }
            other.GetComponent<Animator>().SetBool("Pick", true);
            other.GetComponent<WorldPlayerMovementScript>().SetPickedObject(gameObject);
        }
    }

    //Function to change the id
    public void SetId(int i)
    {
        id = i;
    }

    //Function to get the id
    public int GetId()
    {
        return id;
    }

    //Function to change the picked state of an item
    public void SetPicked(bool p)
    {
        picked = p;
    }

}
