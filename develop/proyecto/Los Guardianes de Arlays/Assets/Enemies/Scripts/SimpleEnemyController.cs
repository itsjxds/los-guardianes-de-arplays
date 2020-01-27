using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController : MonoBehaviour
{
    public float maxSpeed = 1.5f;
    public float speed = 1.5f;
    public bool moveRight;

    private Rigidbody2D rbd2d;
    public float startScaleX;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        rbd2d = GetComponent<Rigidbody2D>();
        startScaleX = transform.localScale.x;
    }

    void Update ()
    {
        //comprueba si el enemigo se ha chocado (cosa que disminuye su velocidad) para cambiar de dirección
        if(rbd2d.velocity.x > -0.01f && rbd2d.velocity.x < 0.01f)
        {if(moveRight)
            {
                moveRight = false;
            }
        else
            {
                moveRight = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    void move()
    {
        //hace que se mueva el perso

        rbd2d.velocity = new Vector2(speed, rbd2d.velocity.y);
        
        if(!moveRight)
        {
            rbd2d.velocity = new Vector2(-speed, rbd2d.velocity.y);
            transform.localScale = new Vector3(-startScaleX, transform.localScale.y, transform.localScale.z);
        } else {
            rbd2d.velocity = new Vector2(speed, rbd2d.velocity.y);
            transform.localScale = new Vector3(startScaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    public void takeDamage (int damage)
    {
        health -= damage;
        Debug.Log("Enemy: damage taken: " + health);
    }
}
