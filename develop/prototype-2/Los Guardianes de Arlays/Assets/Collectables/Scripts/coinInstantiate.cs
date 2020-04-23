using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinInstantiate : MonoBehaviour
{
    public GameObject coins;

    public void instantiateCoins(int coinsNum, Transform transform) {
        for (int i = 0; i < coinsNum; i++)
        {
            float randomX = Random.Range(-2, 2);
            Debug.Log("X" + randomX);
            Vector3 position = new Vector3(transform.position.x + randomX, transform.position.y+1, transform.position.z);
            Instantiate(coins, position, Quaternion.identity);
        }
    }
}
