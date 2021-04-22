using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    //The canvas
    private GameObject canvas;
    //A boolean to know if the coin is already picked up
    private bool picked;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        picked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.transform.tag == "Player" || other.transform.tag == "Companion") && !picked)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            PlayerPrefs.SetInt("currentCoins", PlayerPrefs.GetInt("currentCoins") + 1);
            canvas.GetComponent<WorldCanvasScript>().UpdateCoins();
            picked = true;
            GetComponent<Animator>().SetTrigger("Pick");
        }
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
