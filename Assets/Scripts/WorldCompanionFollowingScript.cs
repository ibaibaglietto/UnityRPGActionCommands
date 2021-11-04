using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCompanionFollowingScript : MonoBehaviour
{
    //A boolean to know if the companion will follow the player the normal way or not
    public bool normalFollow;
    //The position in z coords that the companion will follow the player
    public float followPos;
    //The companion
    private GameObject companion;

    private void Start()
    {
        companion = GameObject.Find("CompanionWorld");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player") companion.GetComponent<WorldCompanionMovementScript>().ChangeFollow(normalFollow, followPos);
    }
}
