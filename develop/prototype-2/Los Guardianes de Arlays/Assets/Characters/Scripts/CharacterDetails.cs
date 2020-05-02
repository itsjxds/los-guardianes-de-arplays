using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharacterDetails
{
    public Sprite icon;
    public string name;
    public string stats;
    [TextArea(1, 2)]
    public string abilities;
    public int index;
}
