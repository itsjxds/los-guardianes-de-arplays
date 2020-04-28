using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDetailsManager : MonoBehaviour
{
    public Image iconUI;
    public TextMeshProUGUI nameUI;
    public TextMeshProUGUI priceUI;
    public TextMeshProUGUI effectsUI;
    public GameObject detailsUI;

    private int price;

    public Button buyButton;

    void Update ()
    {
        if (PlayerPrefs.money < price)
        {
            buyButton.interactable = false;
        } else
        {
            buyButton.interactable = true;
        }
    }

    public void displayDetails(ItemDetails details)
    {
        detailsUI.SetActive(true);

        iconUI.sprite = details.icon;
        iconUI.preserveAspect = true;
        nameUI.text = details.name;
        priceUI.text = details.price.ToString();
        effectsUI.text = details.effects;

        price = details.price;
    }

    public void hideDetails()
    {
        detailsUI.SetActive(false);
    }

    public void buy ()
    {
        if (PlayerPrefs.money >= price)
        {
            //TODO BUY
            PlayerPrefs.money -= price;
        }
    }
}
