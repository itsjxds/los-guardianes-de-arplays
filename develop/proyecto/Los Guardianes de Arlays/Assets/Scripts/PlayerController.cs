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

    //variables para saber si está tocando el suelo
    private bool isGrounded; //true si el jugador está tocando el suelo, false si no
    public Transform groundCheck;  //objeto a los pies del jugador que servirá para crear un circulo
    public LayerMask whatIsGround;  //capa del suelo

    //variables para atacar
    public GameObject attackObject;
    private float timeBtwAttack = 0;
    private float startTimeBtwAttack = 0.4f;
    public LayerMask whatIsEnemies;
    public bool attackActive = false;

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
            jump();
        }
        
        attack();

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


    void jump()
    {
        rbd2d.velocity = new Vector2(rbd2d.velocity.x, jumpPower);
    }


    void attack ()
    {
        if (timeBtwAttack <= 0)
        {
            Debug.Log("can attack");

            //si el tiempo de recarga del ataque ha llegado a 0, puedes atacar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("attacking");

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
        health -= damage;
        
        enemyKnockback(posEnemy);

        Debug.Log("player: damage taken, health: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("player: dead");

            die();
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
        Debug.Log("knockback ");
        //rbd2d.velocity = new Vector2(jumpPower, rbd2d.velocity.y);

        float side = Mathf.Sign(enemyPosition - transform.position.x);
        Debug.Log("side: "+side);

        //rbd2d.velocity = Vector2.left * side * jumpPower;
        //rbd2d.AddForce(Vector2.left * 60, ForceMode2D.Impulse);
        //rbd2d.AddForce(new Vector2(rbd2d.position.x, jumpPower));

        //todo el más convincente hasta la fecha tbh
        rbd2d.velocity = new Vector2(0, rbd2d.position.y);
        //rbd2d.AddForce(new Vector2(jumpPower*side, rbd2d.position.y), ForceMode2D.Impulse);

        //todo A QUIEN LE IMPORTA PORQUE EL KNOCKBACK TIENE CONFLICTO CON EL SALTO LOL IDK WHY

        movement = false;
        GetComponentInChildren<ChangeColorKnockback>().changeColorRed();

        Invoke("enableMovement", 0.8f);
    }

    public void enemyJump()
    {
        jump();
    }


    void enableMovement()
    {
        movement = true;
        GetComponentInChildren<ChangeColorKnockback>().changeColorWhite();
    }


    void die ()
    {
        Debug.Log("YOU DIED!!!");
        SceneManager.LoadScene("LevelSelect");
    }



        
    
    //todo borrar o usar para habilidad
    /*void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }*/
}
