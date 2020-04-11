using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlastairController : MonoBehaviour
{
    //variables para atacar
    public GameObject attackObject;
    public float timeBtwAttack = 0;
    private float startTimeBtwAttack = 20f;
    public LayerMask whatIsEnemies;

    public bool thunderActive = false;
    public bool buttonPressed = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thunderAbility();
    }


    public void thunderAbility()
    {
        if (timeBtwAttack <= 0)
        {
            Debug.Log("can attack");

            //si el tiempo de recarga del ataque ha llegado a 0, puedes atacar
            if (Input.GetKeyDown(KeyCode.C)||buttonPressed)
            {
                Debug.Log("attacking");

                thunderActive = true;

                attackObject.SetActive(true);

                //el contador de tiempo entre ataque se reinicia
                timeBtwAttack = startTimeBtwAttack;
            }

        }
        else
        {   //si el tiempo entre ataque no es cero, sigue bajando hasta que lo sea
            timeBtwAttack -= Time.deltaTime;

            thunderActive = false;

            attackObject.SetActive(false);

        }

        buttonPressed = false;

    }
}
