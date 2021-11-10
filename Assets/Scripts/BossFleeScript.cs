using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFleeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public void RunLeft()
    {
        transform.GetChild(0).GetComponent<NPCScript>().RunLeft();
        transform.GetChild(1).GetComponent<NPCScript>().RunLeft();
    }

    public void StopRunning()
    {
        transform.GetChild(0).GetComponent<NPCScript>().StopRunning();
        transform.GetChild(1).GetComponent<NPCScript>().StopRunning();
    }

    public void RunRight()
    {
        transform.GetChild(0).GetComponent<NPCScript>().RunRight();
        transform.GetChild(1).GetComponent<NPCScript>().RunRight();
    }
}
