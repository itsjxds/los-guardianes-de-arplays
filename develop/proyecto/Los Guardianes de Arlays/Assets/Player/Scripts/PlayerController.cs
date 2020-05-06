using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //variable para moverse
    public float speed = 6.5f;
    public float axisH;

    //variable para cambiar la dirección del personaje según hacia dónde se mueva
    private float startScaleX;

    //variables para saltar
    public float jumpPower= 12f;
    private float jumpTimeCounter;
    private float jumpTime = 0.3f;
    private bool isJumping = false;
    private bool doubleJumpCharacter = false;

    //variables para saber si está tocando el suelo
    public bool isGrounded; //true si el jugador está tocando el suelo, false si no
    public Transform groundCheck;  //objeto a los pies del jugador que servirá para crear un circulo
    public LayerMask whatIsGround;  //capa del suelo

    //variables para atacar
    public GameObject attackObject;
    private float timeBtwAttack = 0;
    private float startTimeBtwAttack = 0.7f;
    public LayerMask whatIsEnemies;
    public bool attackActive = false;

    private bool movement = true;
    private bool beingDamaged = false;

    public int health;
    private int maxHealth;
    public int damage;
    private int bonusDamage = PlayerPrefs.bonusDamage;
    private bool healing = false;
    public bool healthPotionHealing = false;
    public GameObject bloodEffect;
    private GameObject particles;

    private Rigidbody2D rbd2d;


    // Start is called before the first frame update
    void Start()
    {
        damage += bonusDamage;

        rbd2d = GetComponent<Rigidbody2D>();
        startScaleX = transform.localScale.x;

        maxHealth = health;

        if (PlayerPrefs.activeCharacter == Characters.Andrea)
        {
            doubleJumpCharacter = true;
        }
    }


    // Update is called once per frame
    void Update ()
    {
        complexJump();

        attack();

        //healing over time
        if(health<maxHealth && !healing)
        {
            healing = true;
            Invoke("heal", 18f);
        }

        if (healthPotionHealing)
        {
            heal();
        }

    }
    
    void FixedUpdate()
    {
        axisH = Input.GetAxis("Horizontal");

        if(!movement)
        {
            axisH = 0;
        }
        
        //comprueba si el personaje está tocando el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, whatIsGround);

        move(axisH);

        changeScaleX(axisH);

    }
    


    /*Este método permite que el personaje se mueva y que no supere la velocidad máxima*/
    void move (float axis)
    {
        //hace que se mueva el personaje
        rbd2d.velocity = new Vector2(speed*axis, rbd2d.velocity.y);
    }


    public void basicJump()
    {
        rbd2d.velocity = new Vector2(rbd2d.velocity.x, jumpPower);
    }

    private void complexJump ()
    {
        float jumpForce = 8f;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (doubleJumpCharacter)
            {
                //double jump
                GetComponentInChildren<DoubleJump>().isGrounded = isGrounded;
                GetComponentInChildren<DoubleJump>().doubleJump();
            } else
            {
                if (isGrounded)
                {
                    isJumping = true;
                    jumpTimeCounter = jumpTime;
                    rbd2d.velocity = Vector2.up * jumpForce;
                }
            }
        }

        if(!doubleJumpCharacter)
        {
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && isJumping)
            {
                if (jumpTimeCounter > 0)
                {
                    rbd2d.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else {
                    isJumping = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            {
                isJumping = false;
            }
        }
    }


    void attack ()
    {
        if (timeBtwAttack <= 0)
        {
            //si el tiempo de recarga del ataque ha llegado a 0, puedes atacar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                attackActive = true;

                attackObject.SetActive(true);

                //el contador de tiempo entre ataque se reinicia
                timeBtwAttack = startTimeBtwAttack;
            }
            
        }
        else
        {   //si el tiempo entre ataque no es cero, sigue bajando hasta que lo sea
            timeBtwAttack -= Time.deltaTime;

            attackActive = false;

            attackObject.SetActive(false);
        }
    }


    public void takeDamage(int damage, float posEnemy)
    {
        if (!beingDamaged)
        {
            particles = Instantiate(bloodEffect, transform.position, Quaternion.identity) as GameObject;

            Invoke("destroyParticles(particles)", 0.2f);

            health -= damage;

            beingDamaged = true;

            enemyKnockback(posEnemy);

            if (health <= 0)
            {
                health = 0;
            }

            //el script PlayerDied comprueba paralelamente si la salud es 0 o menos y mata al jugador si lo es
        }
    }

    private void destroyParticles (GameObject particles)
    {
        Destroy(particles);
    }


    /*Este método cambia la dirección a la que mira el personaje dependiendo de hacia qué lado se mueva*/
    void changeScaleX(float axis)
    {
        //cambia la scale de x de positiva si va a la derecha a negativa si va a la izquierda
        if (axis > 0.1f)
        {
            transform.localScale = new Vector3(startScaleX, transform.localScale.y, transform.localScale.z);
        }
        if (axis < -0.1f)
        {
            transform.localScale = new Vector3(-startScaleX, transform.localScale.y, transform.localScale.z);
        }
    }




    public void enemyKnockback (float enemyPosition)
    {
        float side = Mathf.Sign(enemyPosition - transform.position.x);

        enemyJump(10f);

        movement = false;
        GetComponentInChildren<ChangeColorKnockback>().changeColorRed();

        Invoke("enableMovement", 0.75f);
    }

   

    public void enemyJump(float power)
    {
        rbd2d.velocity = new Vector2(rbd2d.velocity.x, power);
    }


    void enableMovement()
    {
        beingDamaged = false;
        movement = true;
        GetComponentInChildren<ChangeColorKnockback>().changeColorWhite();
    }


    void die ()
    {
        SceneManager.LoadScene("LevelSelect");
    }


    void heal ()
    {      
        if (healthPotionHealing)
        {
            if (health < maxHealth)
            {
                health += 5;

                if (health < maxHealth - 5)
                {
                    health += 5;
                }
            }
            healthPotionHealing = false;
        } else if (healing)
        {
            if (health < maxHealth - 5)
            {
                health += 5;
            }
        }

        healing = false;
    }
}
