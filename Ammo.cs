using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
    //initiate variables
    public GameObject shooter;
    public GameObject baby;
    public Shooting shooting;
    public Material currentColor;
    public LevelControl level;
    public int ammoPlus;            //assign in engine
    public int spawnCheck;         //assign in engine
    public int pickupChoose;
    public float timer;
    public PickupSpawn pickupSpawn;
    public bool canPickUp = true;
    public bool isAmmo;
    public bool changePickup;

	void Start () {
        //assign variables
        shooter = GameObject.FindGameObjectWithTag("Shooter");
        baby = GameObject.FindGameObjectWithTag("Baby");
        level = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelControl>();
        shooting = shooter.GetComponent<Shooting>();
        pickupSpawn = GetComponentInParent<PickupSpawn>();
        timer = spawnCheck;
        currentColor = gameObject.GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        transform.Rotate(50 * Time.deltaTime, 0, 0);

        //if the timer reaches the spawn time
        if (timer >= spawnCheck)
        {
            //allow the pickup to be picked up
            GetComponent<Renderer>().enabled = true;
            canPickUp = true;
            
        }

        if (changePickup == true)
        {
            //Check which pickup version can be obtained
            pickupChoose = Random.Range(1, 3);
            if (pickupChoose == 1)
            {
                isAmmo = true;
            }
            else
            {
                isAmmo = false;
            }
            changePickup = false;

        }
        //change the pickup's color depending on what it does
        if (isAmmo == true)
        {
            currentColor.color = Color.white;
        }
        else
        {
            currentColor.color = Color.red;
        }
    }

    void OnTriggerEnter (Collider collider)
    {
        //if the player touches the pickup...
        if (collider.tag == "Baby" && canPickUp == true)
        {
            if (isAmmo == true)
            {
                //add ammo to the player's weapon
                shooting.ammo = shooting.ammo + ammoPlus;
                print("Ammo obtained");
            }
            else
            {
                //add health to the player if possible
                if (level.playerHealth < level.maxHealth)
                {
                    level.playerHealth += 1;
                    print("Health Regained");
                }
            }
            //make the pickup disappear
            GetComponent<Renderer>().enabled = false;
            //pickupSpawn.canSpawn = true;
            timer = 0;
            canPickUp = false;
            changePickup = true;
        }
    }
}
