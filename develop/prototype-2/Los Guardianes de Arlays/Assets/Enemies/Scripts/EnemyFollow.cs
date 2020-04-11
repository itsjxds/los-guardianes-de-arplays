using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFollow : MonoBehaviour
{
    public Animator animator;

    //variables de seguir al jugador
    public float speed;
    private float startStoppingDistance;
    public float stoppingDistance = 2.3f;
    public float inactiveDistance = 20;

    //variables para atacar
    public float startTimeBtwAttack = 2f;
    private float timeBtwAttack = 0f;
    public GameObject weapon;

    private bool knockedBack = false;

    //variable para cambiar la dirección del personaje según hacia dónde se mueva
    private float startScaleX;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<EnemyController>().patrolEnemy = false;

        startScaleX = transform.localScale.x;

        startStoppingDistance = GetComponent<EnemyFollow>().stoppingDistance;

        speed = GetComponent<EnemyController>().speed + 1.2f;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        knockedBack = GetComponent<EnemyController>().knockedBack;

        if (Vector2.Distance(transform.position, target.position) < inactiveDistance)
        {
            if (Vector2.Distance(transform.position, target.position) < stoppingDistance + 2)
            {
                //agranda la distancia para que no se acerque al jugador cuando está saltando por encima
                if (target.position.y > transform.position.y)
                {
                    stoppingDistance++;
                }
                else
                {
                    stoppingDistance = startStoppingDistance;
                }
            }

            //si la distancia entre el enemigo y el jugador es mayor que la distancia a la que hay que pararse
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                if(!knockedBack)
                {
                    //el enemigo se mueve hacia el jugador
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    //animación de caminar
                    animator.SetFloat("speed", 1);
                }

                timeBtwAttack = 0;
            }
            else
            {
                animator.SetFloat("speed", 0);

                attack();
            }
        }
        else
        {
            timeBtwAttack = 0;

            animator.SetFloat("speed", 0);
        }

        changeScaleX();
    }

    private void attack()
    {
        if (timeBtwAttack <= 0)
        {
            timeBtwAttack = startTimeBtwAttack;

            animator.SetBool("attack2", true);
            weapon.SetActive(true);
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
            stopAttacking();
        }
    }

    private void stopAttacking ()
    {
        weapon.SetActive(false);
        animator.SetBool("attack2", false);
    }

    private void changeScaleX()
    {
        //cambia la scale de x de positiva si va a la derecha a negativa si va a la izquierda
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(startScaleX, transform.localScale.y, transform.localScale.z);
        }
        if (target.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-startScaleX, transform.localScale.y, transform.localScale.z);
        }
    }

}
