using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Sprite[] heartSprites = new Sprite[6];
    public Image heartUI;
    private PlayerController player;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        heartUI.sprite = heartSprites[player.health / 5];
    }

}
