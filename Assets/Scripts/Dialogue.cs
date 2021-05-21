using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //Name of the speaker
    public Transform speaker;

    //A boolean to know if the dialogue is previous a rest or not
    public bool prevRest;

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
