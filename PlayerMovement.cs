using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //initiate variables
    public float moveSpeed = 10.0f;
    public float immuneTime;
    public float immuneRunOut;      //assign in engine
    public bool immune = false;
    public bool canImmune = false;
    public bool takenDamage = false;
    public GameObject level;

	void Start () {
        //assign variables
        level = GameObject.FindGameObjectWithTag("Level");
        //lock cursor in window
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	void Update () {
        //begin immunity timer
        immuneTime += Time.deltaTime;

        //set movement
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);

        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);

        //if the player's immunity counter is below the Runout time...
        if (immuneTime <= immuneRunOut)
        {
            //allow the player to be immune to damage
            immune = true;
        }//if not...
        else
        {
            //make the player vulnerable to attack
            immune = false;
        }

        //knock the player back after being hit
        if (takenDamage == true)
        {
            
        }
    }
}
