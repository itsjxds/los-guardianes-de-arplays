using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSavePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("collision with autosave");

        if (col.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            Debug.Log("autosaving!!");

            SaveSystem.savePlayer(col.GetComponent<PlayerController>());

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Invoke("reactivateAutosave", 10);
    }


    private void reactivateAutosave ()
    {
        Debug.Log("autosaving is active again");
        this.gameObject.SetActive(true);
    }
}
