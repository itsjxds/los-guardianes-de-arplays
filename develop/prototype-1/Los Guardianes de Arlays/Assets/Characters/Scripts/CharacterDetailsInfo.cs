using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDetailsInfo : MonoBehaviour
{
    public CharacterDetails details;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showDetails()
    {
        FindObjectOfType<CharacterDetailsManager>().displayDetails(details);
    }
}
