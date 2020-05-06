using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Characters currentCharacter;
    public bool[] unlockedCharacters;
    public int money;
    public int levelAt;
    public float volume;
    public int attackBonus;

    public GameData()
    {
        money = PlayerPrefs.money;
        currentCharacter = PlayerPrefs.activeCharacter;
        unlockedCharacters = PlayerPrefs.unlockedCharacters;
        levelAt = MenuManager.levelAt;
        volume = MenuManager.audioVolume;
        attackBonus = PlayerPrefs.bonusDamage;
    }
}
