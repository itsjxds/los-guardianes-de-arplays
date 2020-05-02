using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerPrefs.money += 1;
            Destroy(gameObject);
        }
    }
}
