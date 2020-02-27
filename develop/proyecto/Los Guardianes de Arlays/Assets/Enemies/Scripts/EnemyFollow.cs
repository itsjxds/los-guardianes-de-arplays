using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float stoppingDistance = 3;

    //variable para cambiar la dirección del personaje según hacia dónde se mueva
    private float startScaleX;
    private Rigidbody2D rb2d;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<EnemyController>().patrolEnemy = false;

        startScaleX = transform.localScale.x;
        rb2d = GetComponent<Rigidbody2D>();

        speed = GetComponent<EnemyController>().speed + 1.2f;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  
        } else
        {

        }

        changeScaleX();
    }

    void changeScaleX()
    {
        //cambia la scale de x de positiva si va a la derecha a negativa si va a la izquierda
        if (rb2d.velocity.x > -0.01f)
        {
            transform.localScale = new Vector3(startScaleX, transform.localScale.y, transform.localScale.z);
        }
        if (rb2d.velocity.x > 0.01f)
        {
            transform.localScale = new Vector3(-startScaleX, transform.localScale.y, transform.localScale.z);
        }
    }

}
