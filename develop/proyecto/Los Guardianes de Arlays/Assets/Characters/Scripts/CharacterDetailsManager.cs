using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDetailsManager : MonoBehaviour
{
    public Image iconUI;
    public TextMeshProUGUI nameUI;
    public TextMeshProUGUI statsUI;
    public TextMeshProUGUI abilitiesUI;
    public GameObject detailsUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayDetails(CharacterDetails details)
    {
        detailsUI.SetActive(true);

        iconUI.sprite = details.icon;
        nameUI.text = details.name;
        statsUI.text = details.stats;
        abilitiesUI.text = details.abilities;
    }

    public void hideDetails()
    {
        detailsUI.SetActive(false);
    }
}
