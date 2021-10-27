using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    //The canvas
    private GameObject canvas;
    //A boolean to know if the coin is already picked up
    private bool picked;
    //The current data
    private GameObject currentData;
    //the flag
    public string flag;

    void Start()
    {
        currentData = GameObject.Find("CurrentData");
        canvas = GameObject.Find("Canvas");
        picked = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if ((other.transform.tag == "Player" || other.transform.tag == "Companion") && !picked)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            currentData.GetComponent<CurrentDataScript>().currentCoins = currentData.GetComponent<CurrentDataScript>().currentCoins + 1;
            canvas.GetComponent<WorldCanvasScript>().UpdateCoins();
            picked = true;
            SetFlag();
            GetComponent<Animator>().SetTrigger("Pick");
        }
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }


    //Function to set the picked flag
    public void SetFlag()
    {
        currentData.GetComponent<CurrentDataScript>().SetFlag(flag);
    }

}
