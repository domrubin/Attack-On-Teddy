using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour {
    //initialize variables
    public GameObject pickup;       //assign in engine
    public float timer;
    public int spawnTime;           //assign in engine
    public bool canSpawn = true;

	void Start () {
		
	}
	
	void Update () {
        timer += Time.deltaTime;

        if (timer >= spawnTime && canSpawn == true)
        {
            Instantiate(pickup, transform.position, transform.rotation);
            canSpawn = false;
            timer = 0;
        }
	}
}
