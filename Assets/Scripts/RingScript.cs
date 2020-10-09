using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour
{
    private bool crossed;
    void Start()
    {
        crossed = false;
    }

    public void Cross()
    {
        crossed = true;
    }
    public bool isCrossed()
    {
        return crossed;
    }
}
