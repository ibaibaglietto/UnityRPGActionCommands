using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSoulScript : MonoBehaviour
{
    
    void Update()
    {
        if (GetComponent<RectTransform>().anchoredPosition.y < -5.0f) Destroy(gameObject);
    }
}
