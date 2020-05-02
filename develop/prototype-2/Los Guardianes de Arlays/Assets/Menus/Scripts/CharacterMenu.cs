using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Button[] buttons;
    void Start ()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if(PlayerPrefs.unlockedCharacters[i])
            {
                buttons[i].interactable = true;
            } else
            {
                buttons[i].interactable = false;
            }
        }
    }

    public void activateAlastair() {
        PlayerPrefs.activeCharacter = Characters.Alastair;
    }

    

    public void activateAndrea()
    {
        PlayerPrefs.activeCharacter = Characters.Andrea;
    }
}
