using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour{
    public int health;          //assign in engine
    
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        //if the enemy collides with the player...

        //if a bullet hits the enemy...
        if (collider.tag == "Bullet")
        {
            health -= 1;
            Destroy(collider.gameObject);
        }
    }
}
