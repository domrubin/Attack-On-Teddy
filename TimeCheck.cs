using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCheck : MonoBehaviour
{
    //initiate variables
    public LevelControl level;
    public int showTime;          //assign in engine
    public RawImage clock;
    void Start()
    {
        //assign variables
        level = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelControl>();
        clock = GetComponent<RawImage>();
    }

    void Update()
    {
        //show the current health bar if the corresponding health is reached
        if (showTime == level.waveCount)
        {
            clock.enabled = true;
        }
        else
        {
            clock.enabled = false;
        }
    }
}
