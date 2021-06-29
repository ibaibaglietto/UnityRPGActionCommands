using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldShurikenScript : MonoBehaviour
{

    //The objective of the shuriken
    private Vector3 objective;
    //A float to save the y rotation of the shuriken
    private float rotationY;
    //A float to save the z rotation of the shuriken
    private float rotationZ;
    // Start is called before the first frame update
    void Awake()
    {
        rotationY = 0.0f;
        rotationZ = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if((Mathf.Abs(gameObject.transform.position.x - transform.position.x) + Mathf.Abs(gameObject.transform.position.y - transform.position.y) + Mathf.Abs(gameObject.transform.position.z - transform.position.z))<10.0f) gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.39f * Mathf.Cos(rotationZ) * Mathf.Abs(Mathf.Sin(rotationY)), gameObject.transform.position.y + 0.39f * Mathf.Sin(rotationZ), gameObject.transform.position.z + 0.39f * Mathf.Cos(rotationY));
        else SelfDestroy();
    }

    //A function to set the objective
    public void SetObjective(Vector3 obj)
    {
        objective = obj;
        rotationY = Mathf.Atan2(objective.x - transform.position.x, objective.z - transform.position.z);
        rotationZ = Mathf.Atan2(objective.y - transform.position.y, objective.x - transform.position.x);        
        transform.rotation = Quaternion.Euler(0.0f, (rotationY - (Mathf.PI / 2)) * Mathf.Rad2Deg, rotationZ * Mathf.Rad2Deg);
    }

    //Function to self destroy
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
