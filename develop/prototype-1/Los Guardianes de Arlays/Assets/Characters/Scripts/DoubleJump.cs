using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private int extraJumps;
    public int extraJumpsValue;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
    }

    public void doubleJump ()
    {
        if(extraJumps > 0)
        {
            Debug.Log("can double jump");
            GetComponentInParent<PlayerController>().jump();
            extraJumps--;
        } else
        {
            if(isGrounded)
            {
                Debug.Log("can not double jump");
                extraJumps = extraJumpsValue;
                GetComponentInParent<PlayerController>().jump();
            }
        }
        
    }
}
