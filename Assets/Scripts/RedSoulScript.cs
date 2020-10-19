using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSoulScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<RectTransform>().anchoredPosition.y < -5.0f) Destroy(gameObject);
    }
}
