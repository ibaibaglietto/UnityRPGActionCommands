using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceScript : MonoBehaviour
{
    [SerializeField] private float leftChairX;
    [SerializeField] private float leftChairZ;
    [SerializeField] private float rightChairX;
    [SerializeField] private float rightChairZ;
    private GameObject companion;
    //The dialogue
    public Dialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        companion = GameObject.Find("AdventurerWorld");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {            
            other.GetComponent<WorldPlayerMovementScript>().SetCanRest(true);
            other.GetComponent<WorldPlayerMovementScript>().SetRestPosition(leftChairX,leftChairZ);
            other.GetComponent<WorldPlayerMovementScript>().SetFireXPos(transform.position.x);
            other.GetComponent<WorldPlayerMovementScript>().SetFirePlace(gameObject);
            companion.GetComponent<WorldCompanionMovementScript>().SetRestPosition(rightChairX, rightChairZ);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<WorldPlayerMovementScript>().SetCanRest(false);
        }
    }
}
