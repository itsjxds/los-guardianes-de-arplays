using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Characters currentCharacter;
    public int money;
    public int levelAt;
    public float volume;

    public GameData()
    {
        money = PlayerPrefs.money;
        currentCharacter = PlayerPrefs.activeCharacter;
        levelAt = MenuManager.levelAt;
        volume = MenuManager.audioVolume;
    }
}
