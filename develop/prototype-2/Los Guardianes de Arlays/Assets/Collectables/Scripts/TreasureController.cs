using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    public int numCoins = 10;
    public Sprite openTresureSprite;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("collision treasure");
        if (col.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = openTresureSprite;
            GetComponent<coinInstantiate>().instantiateCoins(numCoins, transform);
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
