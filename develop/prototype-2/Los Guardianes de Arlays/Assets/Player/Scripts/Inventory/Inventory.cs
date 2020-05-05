using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static int numberOfSlots = PlayerPrefs.numberOfSlots;
    private bool[] isFull = PlayerPrefs.isFull;
    public GameObject[] slots = new GameObject[numberOfSlots];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            if (isFull[i])
            {                
                GameObject item = Instantiate(PlayerPrefs.items[i], slots[i].transform.position, Quaternion.identity) as GameObject;
                item.transform.SetParent(slots[i].transform, false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i<numberOfSlots; i++)
        {
            if (slots[i].transform.childCount <= 0)
            {
                PlayerPrefs.isFull[i] = false;
                PlayerPrefs.items[i] = null;
            }
        }
    }

}
