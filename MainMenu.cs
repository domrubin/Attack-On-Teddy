using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    //assign variables
    public Canvas InstrucMenu;
    public Button startText;
    public Button instrucText;
    public Button quitText;

	// Use this for initialization
	void Start () {
        //initialize variables
        InstrucMenu = InstrucMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        instrucText = instrucText.GetComponent<Button>();
        quitText = quitText.GetComponent<Button>();
        InstrucMenu.enabled = false;
	}
	
	public void InstrucPress()
    {
        //open the instruction menu and disable the rest
        InstrucMenu.enabled = true;
        startText.enabled = false;
        quitText.enabled = false;
        instrucText.enabled = false;
    }

    public void BackPress()
    {
        //close the instruction menu and enable the rest
        InstrucMenu.enabled = false;
        startText.enabled = true;
        quitText.enabled = true;
        instrucText.enabled = true;
    }

    public void StartPress()
    {
        //load the main game
        Application.LoadLevel(1);
    }

    public void QuitPress()
    {
        //close the game
        Application.Quit();
    }
}
