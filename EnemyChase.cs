using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Baby");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.GetComponent<Transform>().position.x, 0.95f, player.GetComponent<Transform>().position.z);
    }
}
