using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interact : MonoBehaviour
{
    public TextMeshProUGUI popUpMessage;
    private bool interactionAllowed = false;
    public Dialogue dialogue;

    // Update is called once per frame
    void Update()
    {
        if (interactionAllowed && Input.GetKeyDown(KeyCode.E))
        {
            popUpMessage.gameObject.SetActive(false);
            interactionAllowed = false;
            interact();
        }
    }

    private void interact()
    {
        if(GetComponent<AndreaManager>())
        {
            GetComponent<AndreaManager>().interacting = true;
        }
        
        FindObjectOfType<DialogueManager>().startDialogue(dialogue);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("collision");
        if (col.gameObject.tag == "Player")
        {
            popUpMessage.gameObject.SetActive(true);
            interactionAllowed = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("collision");
        if (col.gameObject.tag == "Player")
        {
            popUpMessage.gameObject.SetActive(false);
            interactionAllowed = false;
        }
    }
}
