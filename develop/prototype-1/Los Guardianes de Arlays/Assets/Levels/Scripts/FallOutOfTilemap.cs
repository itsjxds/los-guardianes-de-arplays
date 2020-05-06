using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOutOfTilemap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("collision");
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("player fallen");

            PlayerData data = SaveSystem.loadPlayer();
            col.GetComponent<PlayerController>().health = data.health;

            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            col.GetComponent<PlayerController>().transform.position = position;

        }
    }

}
