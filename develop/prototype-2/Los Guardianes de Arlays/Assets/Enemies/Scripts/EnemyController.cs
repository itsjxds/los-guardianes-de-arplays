﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed = 1.8f;
    public float speed = 1.8f;
    public bool moveRight;

    public bool patrolEnemy = true;
    private bool movement = true;
    private bool movementWasOff = false;

    private Rigidbody2D rbd2d;
    public float startScaleX;

    public Animator animator;

    public int health;
    public int damage;
    public bool knockedBack = false;
    public GameObject bloodEffect;
    private GameObject particles;

    //cuando muere un enemigo aparecen monedas
    public int numCoins = 2;

    public bool spawnedEnemy = true;
    private Transform target;
    public float spawnDistance = 80f;


    // Start is called before the first frame update
    void Start()
    {
        rbd2d = GetComponent<Rigidbody2D>();
        startScaleX = transform.localScale.x;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (patrolEnemy)
        {
            //comprueba si el enemigo se ha chocado (cosa que disminuye su velocidad) para cambiar de dirección

            if (!movementWasOff)
            {
                if (rbd2d.velocity.x > -0.01f && rbd2d.velocity.x < 0.01f && patrolEnemy)
                {
                    if (moveRight)
                    {
                        moveRight = false;
                    }
                    else
                    {
                        moveRight = true;
                    }
                }
            }
            else
            {
                movementWasOff = false;
            }

                //animación de caminar
                animator.SetFloat("speed", Mathf.Abs(rbd2d.velocity.x));
        }

        if(spawnedEnemy)
        {
            if (Vector2.Distance(transform.position, target.position) > spawnDistance)
            {
                GetComponent<destroyObject>().destroy();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (patrolEnemy)
        {
            move();
        }
        
    }


    void move()
    {
        //hace que se mueva el enemigo

        if(movement)
        {
            rbd2d.velocity = new Vector2(speed, rbd2d.velocity.y);

            if (!moveRight)
            {
                rbd2d.velocity = new Vector2(-speed, rbd2d.velocity.y);
                transform.localScale = new Vector3(-startScaleX, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                rbd2d.velocity = new Vector2(speed, rbd2d.velocity.y);
                transform.localScale = new Vector3(startScaleX, transform.localScale.y, transform.localScale.z);
            }
        } else
        {
            rbd2d.velocity = new Vector2(0, rbd2d.velocity.y);
        }
    }

    public void takeDamage(int damage)
    {
        if (movement)
        {
            movement = false;
            knockedBack = true;

            particles = Instantiate(bloodEffect, transform.position, Quaternion.identity) as GameObject;
            Invoke("destroyParticles", 0.1f);

            GetComponentInChildren<ChangeColorKnockback>().changeColorRed();
            rbd2d.velocity = new Vector2(rbd2d.velocity.x, 5f);

            health -= damage;
            Debug.Log("Enemy: damage taken: " + health);

            Invoke("enableMovement", 0.6f);

            if (health <= 0)
            {
                GetComponent<coinInstantiate>().instantiateCoins(numCoins, transform);

                Destroy(gameObject);
                Debug.Log("Enemy: dead");
            }
        }
    }

    private void destroyParticles()
    {
        Debug.Log("destroy particles");
        Destroy(particles);
    }



    private void enableMovement ()
    {
        GetComponentInChildren<ChangeColorKnockback>().changeColorWhite();
        knockedBack = false;
        movement = true;
        movementWasOff = true;
    }



    void OnTriggerEnter2D (Collider2D col)
    {
        Debug.Log("collision");
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("collision player");

            float yOffSet = 1.2f;

            if(transform.position.y + yOffSet < col.transform.position.y)
            {
                takeDamage(col.GetComponent<PlayerController>().damage);
                
                
                col.gameObject.GetComponent<PlayerController>().enemyJump(10f);
            } else
            {
                col.gameObject.GetComponent<PlayerController>().takeDamage(damage, transform.position.x);
            }
        }
    }
}
