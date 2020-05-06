using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorKnockback : MonoBehaviour
{
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColorRed ()
    {
        sprite.color = Color.red;
    }

    public void changeColorWhite()
    {
        sprite.color = Color.white;
    }
}
