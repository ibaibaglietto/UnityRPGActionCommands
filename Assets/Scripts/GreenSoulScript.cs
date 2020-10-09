using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSoulScript : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.parent.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "RedRing" && !other.GetComponent<RingScript>().isCrossed())
        {
            other.GetComponent<RingScript>().Cross();
            Debug.Log("rojo");
        }
        if (other.tag == "YellowRing" && !other.GetComponent<RingScript>().isCrossed())
        {
            other.GetComponent<RingScript>().Cross();
            Debug.Log("amarillo");
        }
    }

}
