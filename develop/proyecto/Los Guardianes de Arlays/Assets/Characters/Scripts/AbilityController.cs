using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour
{
    public GameObject alastair;
    public Button thunderButton;
    private float timeBtwThunder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeBtwThunder = alastair.GetComponent<AlastairController>().timeBtwAttack;

        if (timeBtwThunder <= 0)
        {
            thunderButton.interactable = true;
        }
        else
        {   
            thunderButton.interactable = false;
        }
    }

    public void thunder ()
    {
        alastair.GetComponent<AlastairController>().buttonPressed = true;
    }
}
