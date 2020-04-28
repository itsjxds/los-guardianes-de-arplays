using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public TextMeshProUGUI money;

    // Start is called before the first frame update
    void Start()
    {
        money.text = PlayerPrefs.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        money.text = PlayerPrefs.money.ToString();
    }
}
