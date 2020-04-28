using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDetails
{
    public Sprite icon;
    public string name;
    public int price;
    [TextArea(1, 2)]
    public string effects;
}
