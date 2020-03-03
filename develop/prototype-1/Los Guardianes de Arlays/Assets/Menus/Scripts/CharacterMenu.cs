using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateAlastair() {
        PlayerPrefs.activeCharacter = Characters.Alastair;
        Debug.Log(PlayerPrefs.activeCharacter);
    }

    public void activateAndrea()
    {
        PlayerPrefs.activeCharacter = Characters.Andrea;
        Debug.Log(PlayerPrefs.activeCharacter);
    }
}
