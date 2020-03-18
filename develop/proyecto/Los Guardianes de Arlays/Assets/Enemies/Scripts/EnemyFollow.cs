using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Animator animator;

    //variables de seguir al jugador
    public float speed;
    public float stoppingDistance = 2.5f;
    public float inactiveDistance = 20;

    //variables para atacar
    public float startTimeBtwAttack = 3f;
    private float timeBtwAttack = 0f;
    public GameObject weapon;

    //variable para cambiar la dirección del personaje según hacia dónde se mueva
    private float startScaleX;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<EnemyController>().patrolEnemy = false;

        startScaleX = transform.localScale.x;

        speed = GetComponent<EnemyController>().speed + 1.2f;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < inactiveDistance)
        {
            //si la distancia entre el enemigo y el jugador es mayor que la distancia a la que hay que pararse
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                //el enemigo se mueve hacia el jugador
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                //animación de caminar
                animator.SetFloat("speed", 1);
            }
            else
            {
                animator.SetFloat("speed", 0);

                //todo no ataca
                Debug.Log("Meele enemy attack "+timeBtwAttack);

                animator.SetBool("attack", true);

                attack();
            }
        }
        else
        {
            animator.SetFloat("speed", 0);
        }

        changeScaleX();
    }

    private void attack()
    {
        if (timeBtwAttack <= 0)
        {
            timeBtwAttack = startTimeBtwAttack;

            animator.SetBool("attack", true);

            /*weapon.SetActive(true);
            weapon.SetActive(false);*/

            

        }
        else
        {
            animator.SetBool("attack", false);
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void changeScaleX()
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
