using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //Name of the speaker
    public Transform speaker;

    //Text in english
    [TextArea(3, 10)]
    public string[] sentencesEnglish;
    //Text in spanish
    [TextArea(3, 10)]
    public string[] sentencesSpanish;
    //Text in basque
    [TextArea(3, 10)]
    public string[] sentencesBasque;
}
