using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abitilyIconManager : MonoBehaviour
{
    public GameObject thunderAbility;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.activeCharacter.Equals(Characters.Alastair))
        {
            thunderAbility.SetActive(true);
        } else
        {
            thunderAbility.SetActive(false);
        }
    }
}
