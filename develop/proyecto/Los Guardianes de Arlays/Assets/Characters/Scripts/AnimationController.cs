using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = GetComponentInParent<PlayerController>().axisH;
        animator.SetFloat("speed", Mathf.Abs(speed));

        if(PlayerPrefs.activeCharacter == Characters.Alastair)
        {
            bool thunder = GetComponent<AlastairController>().thunderActive;
            animator.SetBool("thunder_ability", thunder);
        }

        bool attack = GetComponentInParent<PlayerController>().attackActive;
        animator.SetBool("attack", attack);
    }
}
