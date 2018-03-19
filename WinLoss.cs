using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoss : MonoBehaviour {
    public Button returnToMain;
	// Use this for initialization
	void Start () {
        returnToMain = returnToMain.GetComponent<Button>();
	}
	
	public void ReturnToMainMenu()
    {
        Application.LoadLevel(0);
    }
}
