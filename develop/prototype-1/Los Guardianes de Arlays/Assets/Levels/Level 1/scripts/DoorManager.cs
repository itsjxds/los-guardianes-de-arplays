using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorManager : MonoBehaviour
{
    public GameObject openDoor;
    public GameObject closedDoor;
    public GameObject endTrigger;

    public bool doorOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doorOpen)
        {
            closedDoor.SetActive(false);
            openDoor.SetActive(true);
            endTrigger.SetActive(true);
        }
    }
}
