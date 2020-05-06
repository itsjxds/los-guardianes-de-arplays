using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryManager
{
    public static int numberOfSlots = PlayerPrefs.numberOfSlots;
    
    public static bool[] newInventory ()
    {
        bool[] isFull = new bool[numberOfSlots];

        for (int i = 0; i<numberOfSlots; i++)
        {
            isFull[i] = false;
        }

        return isFull;
    }

    public static bool inventoryFull()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            if (!PlayerPrefs.isFull[i])
            {
                return false;
            }
        }

        return true;
    }

    public static void addItem(GameObject item)
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            if (!PlayerPrefs.isFull[i])
            {
                PlayerPrefs.items[i] = item;
                PlayerPrefs.isFull[i] = true;
                break;
            }
        }
    }
}
