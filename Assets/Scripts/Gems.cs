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
    public int id;
    public Texture2D icon;
    [TextArea(3, 10)]
    public string name;
    public int points;
}
