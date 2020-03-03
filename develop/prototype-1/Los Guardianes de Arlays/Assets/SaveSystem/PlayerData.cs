using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData    
{
    public float[] position = new float[3];
    public int health;

    public PlayerData(PlayerController player) {
        health = player.health;
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
