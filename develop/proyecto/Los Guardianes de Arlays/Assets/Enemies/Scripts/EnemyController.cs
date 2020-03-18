using System.Collections;
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


    // Start is called before the first frame update
    void Start()
    {
        rbd2d = GetComponent<Rigidbody2D>();
        startScaleX = transform.localScale.x;
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
            GetComponentInChildren<ChangeColorKnockback>().changeColorRed();
            rbd2d.velocity = new Vector2(rbd2d.velocity.x, 5f);

            health -= damage;
            Debug.Log("Enemy: damage taken: " + health);

            Invoke("enableMovement", 0.6f);

            if (health <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Enemy: dead");
            }
        }
    }


    private void enableMovement ()
    {
        GetComponentInChildren<ChangeColorKnockback>().changeColorWhite();
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
