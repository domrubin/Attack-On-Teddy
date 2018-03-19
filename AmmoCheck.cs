using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCheck : MonoBehaviour
{
    //initialize variables
    public Shooting shoot;
    public Text ammoDisplay;
    public Font ammoFont;       //assign in engine

    // Use this for initialization
    void Start()
    {
        //assign variables
        shoot = GameObject.FindGameObjectWithTag("Shooter").GetComponent<Shooting>();
        ammoDisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //set the text to display the current amount of ammo
        ammoDisplay.font = ammoFont;
        ammoDisplay.text = shoot.ammo.ToString();

    }
}
