using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    public Canvas pauseMenu;
    public Button continuing;
    public Button exit;
    public LevelControl level;
	// Use this for initialization
	void Start () {
        pauseMenu = pauseMenu.GetComponent<Canvas>();
        continuing = continuing.GetComponent<Button>();
        exit = exit.GetComponent<Button>();
        level = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelControl>();
    }

    // Update is called once per frame
    void Update () {
		if (level.isPaused == true)
        {
            pauseMenu.enabled = true;
            continuing.enabled = true;
            exit.enabled = true;
        }
        else
        {
            pauseMenu.enabled = false;
            continuing.enabled = false;
            exit.enabled = false;
        }
    }

    public void ContinuePress()
    {
        level.isPaused = true;
    }

    public void ExitPress()
    {
        Application.LoadLevel(0);
    }
}
