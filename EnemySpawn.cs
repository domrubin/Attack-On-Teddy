using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public LevelControl level;
    public int hour;
    public int spawnbuffer;
    public float timer;
    public bool canSpawn;
    public bool shouldSpawn = false;
    public GameObject enemy1;       //assign in engine
    public GameObject enemy2;       //assign in engine
    public GameObject enemy3;       //assign in engine
    public int enemyChoose;

    void Start () {
        level = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelControl>();
        hour = level.waveCount;
    }

	void Update () {
        timer += Time.deltaTime;
        canSpawn = level.E_Spawn;
        spawnbuffer = level.spawnRate;

        if (timer >= spawnbuffer)
        {
            shouldSpawn = true;
            timer = 0;
        }

        if (canSpawn == true && shouldSpawn == true) {
            enemyChoose = Random.Range(1, 4);
            switch (enemyChoose)
            {
                case 1:
                    Instantiate(enemy1, transform.position, transform.rotation);
                    break;
                case 2:
                    Instantiate(enemy2, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
                    break;
                case 3:
                    Instantiate(enemy3, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
                    break;
                default:
                    break;
            }
            shouldSpawn = false;
        }
	}
}
