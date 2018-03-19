using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCheck : MonoBehaviour {
    //initiate variables
    public LevelControl level;
    public int showHealth;          //assign in engine
    public RawImage healthBar;
	void Start () {
        //assign variables
        level = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelControl>();
        healthBar = GetComponent<RawImage>();
    }

    void Update () {
		//show the current health bar if the corresponding health is reached
        if (showHealth == level.playerHealth)
        {
            healthBar.enabled = true;
        }
        else
        {
            healthBar.enabled = false;
        }
    }
}
