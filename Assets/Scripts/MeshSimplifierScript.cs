using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSimplifierScript : MonoBehaviour
{
    public float quality;
    // Start is called before the first frame update
    void Start()
    {
        var originalMesh = GetComponent<MeshFilter>().sharedMesh;
        var meshSimplifier = new UnityMeshSimplifier.MeshSimplifier();
        meshSimplifier.Initialize(originalMesh);
        meshSimplifier.SimplifyMesh(quality);
        var destMesh = meshSimplifier.ToMesh();
        GetComponent<MeshFilter>().sharedMesh = destMesh;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
