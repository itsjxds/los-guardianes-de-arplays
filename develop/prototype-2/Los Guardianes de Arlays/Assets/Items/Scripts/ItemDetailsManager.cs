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
    private GameObject item;

    void Update ()
    {
        if (PlayerPrefs.money < price || InventoryManager.inventoryFull())
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
        item = details.item;
    }

    public void hideDetails()
    {
        detailsUI.SetActive(false);
    }

    public void buy ()
    {
        if (PlayerPrefs.money >= price)
        {
            InventoryManager.addItem(item);
            PlayerPrefs.money -= price;
        }
    }
}
