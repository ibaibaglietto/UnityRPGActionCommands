using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryScript : MonoBehaviour
{
    public Item[] items;
}

[System.Serializable]
public class Item
{
    //a boolean to knwo if the item is a badge or not
    public bool isBadge;

    //the id of the item
    public int id;

    //The price of the item
    public int price;
}
