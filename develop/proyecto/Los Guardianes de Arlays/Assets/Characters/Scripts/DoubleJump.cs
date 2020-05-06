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
            GetComponentInParent<PlayerController>().basicJump();
            extraJumps--;
        } else
        {
            if(isGrounded)
            {
                extraJumps = extraJumpsValue;
                GetComponentInParent<PlayerController>().basicJump();
            }
        }
        
    }
}
