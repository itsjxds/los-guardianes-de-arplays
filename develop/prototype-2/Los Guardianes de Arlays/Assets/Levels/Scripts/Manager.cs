using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject[] characters;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (i == (int)PlayerPrefs.activeCharacter)
            {
                characters[i].SetActive(true);
            } else
            {
                characters[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
