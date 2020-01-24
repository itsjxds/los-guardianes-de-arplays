using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed = 1.5f;
    public float speed = 1.5f;
    public bool moveRight;

    private bool canJump;

    private float dazedTime=0;
    public float startDazedTime=0.6f;

    private Rigidbody2D rbd2d;
    public float startScaleX;

    public int health;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        rbd2d = GetComponent<Rigidbody2D>();
        startScaleX = transform.localScale.x;
    }

    void Update()
    {
        //comprueba si el enemigo se ha chocado (cosa que disminuye su velocidad) para cambiar de dirección
        if (rbd2d.velocity.x > -0.01f && rbd2d.velocity.x < 0.01f)
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

        daze();
        

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
    }

    public void takeDamage(int damage)
    {
        dazedTime = startDazedTime;
        GetComponentInChildren<ChangeColorKnockback>().changeColorRed();

        health -= damage;
        Debug.Log("Enemy: damage taken: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy: dead");
        }
    }

    //todo doesnt work
    public void daze ()
    {
        if (dazedTime <= 0)
        {
            GetComponentInChildren<ChangeColorKnockback>().changeColorWhite();
            speed = maxSpeed;
        }
        else
        {
            dazedTime -= Time.deltaTime;
            //no va
            speed = 0;
        }
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
                
                
                col.gameObject.GetComponent<PlayerController>().enemyJump();
            } else
            {
                col.gameObject.GetComponent<PlayerController>().takeDamage(damage, transform.position.x);
            }
            
            
        }
    }
}
