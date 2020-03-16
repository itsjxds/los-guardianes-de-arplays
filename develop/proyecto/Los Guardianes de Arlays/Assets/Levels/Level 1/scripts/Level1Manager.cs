using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public GameObject andreaNPC;

    // Start is called before the first frame update
    void Start()
    {
        //si al empezar el nivel el jugador juega con Andrea desactivamos el NPC de Andrea y abrimos la puerta
        if(PlayerPrefs.activeCharacter == Characters.Andrea)
        {
            GameObject door = andreaNPC.GetComponent<AndreaManager>().door;
            door.GetComponent<DoorManager>().doorOpen = true;

            andreaNPC.SetActive(false);
        }
    }
}
