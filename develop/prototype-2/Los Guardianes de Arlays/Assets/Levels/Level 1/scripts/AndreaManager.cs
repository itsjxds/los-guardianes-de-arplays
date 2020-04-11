using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndreaManager : MonoBehaviour
{
    public GameObject door;
    public GameObject andreaWaiting;
    public GameObject music1;
    public GameObject music2;
    public GameObject[] guards;
    public bool interacting = false;

    void Update()
    {
        if(interacting)
        {
            openDoor();
            interacting = false;
        }
    }

    private void openDoor ()
    {
        door.GetComponent<DoorManager>().doorOpen = true;
        andreaWaiting.SetActive(true);
        music1.SetActive(false);
        music2.SetActive(true);

        foreach (GameObject guard in guards)
        {
            if (guard!=null)
            {
                guard.SetActive(true);
            }
        }
    }
}
