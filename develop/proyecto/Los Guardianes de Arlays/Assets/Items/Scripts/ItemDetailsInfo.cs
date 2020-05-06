using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetailsInfo : MonoBehaviour
{
    public ItemDetails details;

    public void showDetails()
    {
        FindObjectOfType<ItemDetailsManager>().displayDetails(details);
    }
}
