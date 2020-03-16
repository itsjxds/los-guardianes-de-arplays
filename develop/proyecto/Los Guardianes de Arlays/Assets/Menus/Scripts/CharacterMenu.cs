using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
    private void saveCharacter()
    {
        SaveSystem.saveGameData();
    }

    public void activateAlastair() {
        PlayerPrefs.activeCharacter = Characters.Alastair;
        Debug.Log(PlayerPrefs.activeCharacter);
        saveCharacter();
    }

    public void activateAndrea()
    {
        PlayerPrefs.activeCharacter = Characters.Andrea;
        Debug.Log(PlayerPrefs.activeCharacter);
        saveCharacter();
    }
}
