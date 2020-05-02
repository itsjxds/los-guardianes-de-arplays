using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefs
{
    public static Characters activeCharacter = Characters.Alastair;
    public static bool[] unlockedCharacters = { true, false };
    public static int money = 0;
}

public enum Characters
{
    Alastair = 0,
    Andrea = 1
}
