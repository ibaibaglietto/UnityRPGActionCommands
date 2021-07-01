using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject gate;
    public Material pressed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "shuriken")
        {
            gate.GetComponent<Animator>().SetTrigger("Open");
            GetComponent<MeshRenderer>().material = pressed;
            other.GetComponent<WorldShurikenScript>().SelfDestroy();
        }
    }
}
