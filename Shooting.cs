using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    //initiate variables
    public GameObject milk;
    public GameObject bullet;
    public LevelControl level;
    public float bulletSpeed = 1000.0f;
    public int ammo = 0;                
    public bool canShoot;

    void Start () {
        level = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelControl>();

    }

    void Update () {

        //if the player has no ammo, make them unable to shoot
        if (ammo == 0 || level.isPaused == true)
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }
        //if the player presses the shoot input...
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            //spawn the milk splatter...
            Instantiate(milk, transform.position, transform.rotation);
            Instantiate(bullet, transform.position, transform.rotation);
            ammo -= 1;
        }
    }
}
