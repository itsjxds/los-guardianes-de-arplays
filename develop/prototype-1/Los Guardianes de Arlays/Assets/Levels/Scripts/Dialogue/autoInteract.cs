using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class autoInteract : MonoBehaviour
{
    public bool interactionAllowed = false;
    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(interactionAllowed)
        {
            interact();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("collision");
        if (col.gameObject.tag == "Player")
        {
            interact();
        }
    }

    private void interact()
    {
        FindObjectOfType<DialogueManager>().startDialogue(dialogue);
        gameObject.SetActive(false);
    }
}
