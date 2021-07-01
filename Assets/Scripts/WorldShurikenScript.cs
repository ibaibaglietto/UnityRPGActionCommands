using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldShurikenScript : MonoBehaviour
{

    //The objective of the shuriken
    private Vector3 objective;
    //A float to save the rotation of the shuriken
    private Vector3 rotation;
    //The player
    private GameObject player;

    void Awake()
    {
        player = GameObject.Find("PlayerWorld");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Mathf.Abs(player.transform.position.x - transform.position.x) + Mathf.Abs(player.transform.position.y - transform.position.y) + Mathf.Abs(player.transform.position.z - transform.position.z)) < 30.0f) gameObject.transform.position += rotation * Time.deltaTime * 10.0f;
        else SelfDestroy();
    }

    //A function to set the objective
    public void SetObjective(Vector3 obj)
    {
        objective = obj;

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        rotation = (objective - transform.position).normalized;
    }

    //Function to self destroy
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
