using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour {
    public int hour;              //assign in engine
    public float waveTimer = 0f;
    public int waveCount;
    public int playerHealth;        //assign in engine
    public int maxHealth;
    public int spawnRate;           //assign in engine
    public int boxCount;
    public float boxSpawnTime = 3.0f;
    public int enemyCount;
    public int enemyLimit;          //assign in engine
    public bool hasPlayed = true;
    public bool hasWon = false;
    public bool hasLost = false;
    public bool E_Spawn;
    public bool B_Spawn;
    public bool isPaused = false;
    public GameObject player;
    public ChestSpawner boxControl;

    //create array
    public AudioSource[] chimes;
    //add audio to be added to array
    public AudioSource chime1;
    public AudioSource chime2;
    public AudioSource chime3;
    public AudioSource chime4;
    public AudioSource chime5;
    public AudioSource chime6;
    
    void Start () {
		//assign variables
        chimes = GetComponents<AudioSource>();
        chime1 = chimes[0];
        chime2 = chimes[1];
        chime3 = chimes[2];
        chime4 = chimes[3];
        chime5 = chimes[4];
        chime6 = chimes[5];

        player = GameObject.FindGameObjectWithTag("Baby");
        boxControl = GameObject.FindGameObjectWithTag("ChestControl").GetComponent<ChestSpawner>();
        maxHealth = playerHealth;
    }
	
	// Update is called once per frame
	void Update () {

        //if escape is pushed...
        if (Input.GetKeyDown("escape") && isPaused == false)
        {
            //start or stop pausing actions
            isPaused = !isPaused;
        }

        //count the number of enemies and boxes
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        boxCount = GameObject.FindGameObjectsWithTag("EnemyBox").Length;

        //stop spawning enemies if too many are on screen
        if (enemyCount >= enemyLimit)
        {
            E_Spawn = false;
        }
        else
        {
            E_Spawn = true;
        }

        //set hourly timer
        waveTimer += Time.deltaTime;

        //when the timer has reached an in-game hour...
        if (boxCount == 0 && waveTimer >= 10)
        {
            waveTimer = 0;
            waveCount += 1;
            hasPlayed = false;
        }
        //set the correct chime to play given the different hours
       if (waveCount == 1 && hasPlayed == false)
        {
            chime1.Play();
            hasPlayed = true;
            spawnRate = spawnRate - (spawnRate / 3);
            boxControl.shouldSpawn = true;
        }
        else if (waveCount == 2 && hasPlayed == false)
        {
            chime2.Play();
            hasPlayed = true;
            spawnRate = spawnRate - (spawnRate / 3);
            boxControl.shouldSpawn = true;
        }
        else if (waveCount == 3 && hasPlayed == false)
        {
            chime3.Play();
            hasPlayed = true;
            spawnRate = spawnRate - (spawnRate / 3);
            boxControl.shouldSpawn = true;
        }
        else if (waveCount == 4 && hasPlayed == false)
        {
            chime4.Play();
            hasPlayed = true;
            spawnRate = spawnRate - (spawnRate / 3);
            boxControl.shouldSpawn = true;
        }
        else if (waveCount == 5 && hasPlayed == false)
        {
            chime5.Play();
            hasPlayed = true;
            spawnRate = spawnRate - (spawnRate / 3);
            boxControl.shouldSpawn = true;
        }
        else if (waveCount == 6 && hasPlayed == false)
        {
            chime6.Play();
            hasPlayed = true;
            hasWon = true;
        }

       

       //if the player has won...
       if (hasWon == true)
        {
            print("You did it!");
        }

       //if the game is paused...
       if (isPaused == true)
        {
            //stop time
            Time.timeScale = 0.0f;
        }
        else
        {
            //continue time
            Time.timeScale = 1.0f;
        }
    }
}
