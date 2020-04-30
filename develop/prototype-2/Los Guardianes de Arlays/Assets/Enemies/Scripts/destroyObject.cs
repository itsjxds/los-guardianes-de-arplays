using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour
{
    public bool dontDestroyOnStart = false;

    void Start ()
    {
        if (!dontDestroyOnStart)
        {
            Invoke("destroy", 2f);
        }
    }

    public void destroy() {
        Destroy(gameObject);
    }
}
