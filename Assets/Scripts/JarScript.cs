using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JarScript : MonoBehaviour
{
    //The actual fill
    private float fill;
    // Start is called before the first frame update
    void Start()
    {
        fill = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.GetChild(2).GetComponent<Image>().fillAmount < fill) transform.GetChild(2).GetComponent<Image>().fillAmount += 0.004f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "redSoul")
        {
            fill += 0.1f;
            Destroy(other.gameObject);
        }
    }
}
