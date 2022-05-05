using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstantTextScript : MonoBehaviour
{
    [SerializeField] private string text;
    private GameObject currentData;

    // Start is called before the first frame update
    void Start()
    {
        currentData = GameObject.Find("CurrentData");
        GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText(text);
    }

}
