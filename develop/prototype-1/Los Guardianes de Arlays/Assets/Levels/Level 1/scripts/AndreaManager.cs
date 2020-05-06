using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndreaManager : MonoBehaviour
{
    public GameObject door;
    public GameObject andreaWaiting;
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
    }
}
