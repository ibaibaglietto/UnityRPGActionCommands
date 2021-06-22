using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPlayerHelpScript : MonoBehaviour
{
    
    public void StartFlight()
    {
        transform.parent.GetComponent<WorldPlayerMovementScript>().StartFlight();
    }

    public void StartEndFlight()
    {
        transform.parent.GetComponent<WorldPlayerMovementScript>().StartEndFlight();
    }
    public void EndFlight()
    {
        transform.parent.GetComponent<WorldPlayerMovementScript>().EndFlight();
    }

}
