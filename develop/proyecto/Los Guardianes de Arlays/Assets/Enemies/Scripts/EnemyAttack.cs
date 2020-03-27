using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damageIncrement = 0;
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        //damage = GetComponentInParent<EnemyController>().damage + damageIncrement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("collision enemy sword with player");
            col.GetComponent<PlayerController>().takeDamage(GetComponentInParent<EnemyController>().damage + damageIncrement, transform.position.y);
        }
    }

}
