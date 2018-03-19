using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour {
    //initialize variables
    public LevelControl level;
    public float spawnTime;
    public GameObject chest;        //assign in engine
    public Transform spawn1;        //assign in engine
    public Transform spawn2;        //assign in engine
    public Transform spawn3;        //assign in engine
    public Transform spawn4;        //assign in engine
    public Transform spawn5;        //assign in engine
    public Transform spawn6;        //assign in engine
    public bool canSpawn = false;
    public bool shouldSpawn = true;
    // Use this for initialization
    void Start () {
        level = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelControl>();
	}

	void FixedUpdate () {

        //if the hour has progressed for a set period of time...
		if (level.waveTimer >= spawnTime && level.boxCount <= 0)
        {
            //allow the chests to spawn
            canSpawn = true;
        }

        if (canSpawn == true && shouldSpawn == true)
        {
            //spawn the chests in specific areas given the current wave
            switch (level.waveCount)
            {
                case 0:
                    Instantiate(chest, spawn1.position, spawn1.rotation);
                    shouldSpawn = false;
                    break;
                case 1:
                    Instantiate(chest, spawn2.position, spawn2.rotation);
                    Instantiate(chest, spawn3.position, spawn4.rotation);
                    shouldSpawn = false;
                    break;
                case 2:
                    Instantiate(chest, spawn4.position, spawn4.rotation);
                    Instantiate(chest, spawn5.position, spawn5.rotation);
                    Instantiate(chest, spawn6.position, spawn6.rotation);
                    shouldSpawn = false;
                    break;
                case 3:
                    Instantiate(chest, spawn1.position, spawn1.rotation);
                    Instantiate(chest, spawn3.position, spawn3.rotation);
                    Instantiate(chest, spawn5.position, spawn5.rotation);
                    shouldSpawn = false;
                    break;
                case 4:
                    Instantiate(chest, spawn1.position, spawn1.rotation);
                    Instantiate(chest, spawn2.position, spawn2.rotation);
                    Instantiate(chest, spawn4.position, spawn4.rotation);
                    Instantiate(chest, spawn5.position, spawn5.rotation);
                    Instantiate(chest, spawn6.position, spawn6.rotation);
                    shouldSpawn = false;
                    break;
                case 5:
                    Instantiate(chest, spawn1.position, spawn1.rotation);
                    Instantiate(chest, spawn2.position, spawn2.rotation);
                    Instantiate(chest, spawn3.position, spawn3.rotation);
                    Instantiate(chest, spawn4.position, spawn4.rotation);
                    Instantiate(chest, spawn5.position, spawn5.rotation);
                    Instantiate(chest, spawn6.position, spawn6.rotation);
                    shouldSpawn = false;
                    break;
            }
        }
	}
}
