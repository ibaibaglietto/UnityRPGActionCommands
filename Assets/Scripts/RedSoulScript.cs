using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSoulScript : MonoBehaviour
{
    //If the red soul passes the jar area we destroy it
    void Update()
    {
        if (GetComponent<RectTransform>().anchoredPosition.y < -5.0f) Destroy(gameObject);
    }
}
