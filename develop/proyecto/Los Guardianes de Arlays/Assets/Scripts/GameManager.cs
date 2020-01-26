using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject levelCompletedUI;
    public static GameObject levelFailedUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void levelFailed ()
    {
        levelFailedUI.SetActive(true);
    }

    public static void levelCompleted()
    {
        levelCompletedUI.SetActive(true);
    }
}
