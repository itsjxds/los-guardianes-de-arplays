using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public GameObject andreaNPC;
    public GameObject autodialogue;

    // Start is called before the first frame update
    void Start()
    {
        //si al empezar el nivel el jugador juega con Andrea desactivamos el NPC de Andrea y abrimos la puerta
        if(PlayerPrefs.activeCharacter == Characters.Andrea)
        {
            GameObject door = andreaNPC.GetComponent<AndreaManager>().door;
            door.GetComponent<DoorManager>().doorOpen = true;

            GameObject[] guards = andreaNPC.GetComponent<AndreaManager>().guards;

            foreach (GameObject guard in guards)
            {
                if (guard != null)
                {
                    guard.SetActive(true);
                }
            }

            andreaNPC.SetActive(false);
            autodialogue.SetActive(false);
        }
    }
}
