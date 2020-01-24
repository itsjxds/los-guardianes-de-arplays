using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            col.GetComponent<EnemyController>().takeDamage(10);
            //col.SendMessageUpwards("takeDamage", GetComponentInParent<PlayerController>().damage);
            //col.GetComponent<EnemyController>().takeDamage(GetComponentInParent<PlayerController>().damage);
        }
    }
}
