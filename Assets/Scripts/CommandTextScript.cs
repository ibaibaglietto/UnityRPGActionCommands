using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandTextScript : MonoBehaviour
{
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
