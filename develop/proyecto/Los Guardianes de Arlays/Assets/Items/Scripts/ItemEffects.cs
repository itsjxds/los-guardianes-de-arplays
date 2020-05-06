using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffects : MonoBehaviour
{
    private PlayerController player;
    public GameObject healingEffect;
    private GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
       player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void healthPotion ()
    {
        player.healthPotionHealing = true;
        particles = Instantiate(healingEffect, player.transform.position, Quaternion.identity) as GameObject;

        Invoke("destroySelf", 0.2f);
    }

    private void destroySelf()
    {
        Destroy(gameObject);
    }

    private void destroyParticles(GameObject particles)
    {
        Destroy(particles);
    }
}
