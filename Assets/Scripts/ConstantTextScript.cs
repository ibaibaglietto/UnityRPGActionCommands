using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstantTextScript : MonoBehaviour
{
    [SerializeField] private string text;
    private GameObject currentData;


    void Awake()
    {
        currentData = GameObject.Find("CurrentData");
    }

    private void OnEnable()
    {
        GetComponent<Text>().text = currentData.GetComponent<LangResolverScript>().ResolveText(text);
    }

}
