using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefs
{
    public static Characters activeCharacter = Characters.Alastair;
    public static bool[] unlockedCharacters = { true, false };
    public static int money = 0;
    public static int numberOfSlots = 1;
    public static bool[] isFull = InventoryManager.newInventory();
    public static GameObject[] items = new GameObject[numberOfSlots];
}

public enum Characters
{
    Alastair = 0,
    Andrea = 1
}
