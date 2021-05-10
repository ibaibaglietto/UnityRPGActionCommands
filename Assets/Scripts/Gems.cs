using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Gems
{
    public Gem[] gems;
}

[System.Serializable]
public class Gem
{
    public Texture2D icon;
    [TextArea(3, 10)]
    public string[] nameEnglish;
    [TextArea(3, 10)]
    public string[] nameSpanish;
    [TextArea(3, 10)]
    public string[] nameBasque;
    public int points;
}
