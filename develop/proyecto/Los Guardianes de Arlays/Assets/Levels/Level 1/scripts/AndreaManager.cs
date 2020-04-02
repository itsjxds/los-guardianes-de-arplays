using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndreaManager : MonoBehaviour
{
    public GameObject door;
    public GameObject andreaWaiting;
    public GameObject music1;
    public GameObject music2;
    public bool interacting = false;

    void Update()
    {
        if(interacting)
        {
            openDoor();
        }
    }

    private void openDoor ()
    {
        door.GetComponent<DoorManager>().doorOpen = true;
        andreaWaiting.SetActive(true);
        music1.SetActive(false);
        music2.SetActive(true);
    }
}
