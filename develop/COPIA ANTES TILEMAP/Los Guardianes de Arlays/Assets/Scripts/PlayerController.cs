using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variable para moverse
    public float speed = 6.5f;

    //variable para cambiar la dirección del personaje según hacia dónde se mueva
    private float startScaleX;

    //variables para saltar
    public float jumpPower= 7.5f;
    private bool canJump;

    //variables para saber si está tocando el suelo
    private bool isGrounded; //true si el jugador está tocando el suelo, false si no
    public Transform groundCheck;  //objeto a los pies del jugador que servirá para crear un circulo
    public LayerMask whatIsGround;  //capa del suelo

    //variables para atacar
    private float timeBtwAttack = 0;
    public float startTimeBtwAttack = 0.3f;
    public Transform attackPos;
    public float attackRange = 0.85f;
    public LayerMask whatIsEnemies;

    private bool movement = true;

    public int health;
    public int damage;

    private Rigidbody2D rbd2d;

    // Start is called before the first frame update
    void Start()
    {
        rbd2d = GetComponent<Rigidbody2D>();
        startScaleX = transform.localScale.x;
    }


    // Update is called once per frame
    void Update ()
    {
        //cuando se pulsa espacio, jump=true, esto se usa de nuevo en el fixed update
        if ((Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            canJump = true;
        }

        

    }
    
    void FixedUpdate()
    {
        float axisH = Input.GetAxis("Horizontal");
        if(!movement)
        {
            axisH = 0;
        }
        
        //comprueba si el personaje está tocando el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, whatIsGround);

        move(axisH);

        changeScaleX(axisH);

        jump();

        attack();

    }

    


    /*Este método permite que el personaje se mueva y que no supere la velocidad máxima*/
    void move (float axis)
    {
        //hace que se mueva el personaje
        rbd2d.velocity = new Vector2(speed*axis, rbd2d.velocity.y);
    }

    void jump()
    {
        if (canJump)
        {
            rbd2d.velocity = Vector2.up * jumpPower;
            canJump = false;
        }
    }

    void attack ()
    {
        if (timeBtwAttack <= 0)
        {   //si el tiempo de recarga del ataque ha llegado a 0, puedes atacar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyController>().takeDamage(damage);
                    //enemiesToDamage[i].GetComponent<EnemyController>().knockback(transform.position.x);
                    Debug.Log("attack! " + damage);
                }
            }

            //el contador de tiempo entre ataque se reinicia
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {   //si el tiempo entre ataque no es cero, sigue bajando hasta que lo sea
            timeBtwAttack -= Time.deltaTime;
        }
    }

    public void takeDamage(int damage, float posEnemy)
    {
        health -= damage;
        enemyKnockback(posEnemy);

        Debug.Log("player: damage taken, health: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("player: dead");
        }
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
        canJump = true;
        float side = Mathf.Sign(enemyPosition - transform.position.x);
        Debug.Log("side: "+side);

        rbd2d.velocity = Vector2.left * side *jumpPower;
        movement = false;
        GetComponentInChildren<ChangeColorKnockback>().changeColorRed();

        Invoke("enableMovement", 0.8f);
    }

    public void enemyJump()
    {
        canJump = true;
    }


    void enableMovement()
    {
        movement = true;
        GetComponentInChildren<ChangeColorKnockback>().changeColorWhite();
    }



    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
