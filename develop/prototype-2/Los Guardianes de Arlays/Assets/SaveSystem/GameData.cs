using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Characters currentCharacter;
    public int levelAt;

    public GameData()
    {
        currentCharacter = PlayerPrefs.activeCharacter;
        levelAt = MenuManager.levelAt;
    }
}
