using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{

    //initialize variables
    public float timer;         //assign in engine
    public GameObject baby;
    public PlayerMovement playerMovement;
    public bool onoff;


    void Start()
    {
        //assign variables
        baby = GameObject.FindGameObjectWithTag("Baby");
        playerMovement = baby.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        //set blinking to signify immunity
        if (Time.time > timer && playerMovement.immune == true)
        {
            //set timer to be .4 higher than in-game time
            timer = Time.time + .2f;
            //alternate the renderer, making the object blink
            onoff = !onoff;
            GetComponent<Renderer>().enabled = onoff;
        } else if (playerMovement.immune == false)
        {
            GetComponent<Renderer>().enabled = true;
        }
    }
}