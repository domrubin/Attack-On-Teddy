using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
    //initiate variables
    public GameObject player;
    public float rSpeed = 5.0f;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        //assign variables
        player = GameObject.FindGameObjectWithTag("Baby");
        offset = player.transform.position - transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        //retrieve mouse movement and apply the mouse movement to camera movement
        float horizontal = Input.GetAxis("Mouse X") * rSpeed;
        player.transform.Rotate(0, horizontal, 0);

        //set offset to keep camera behind player
        float desAngle = player.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desAngle, 0);
        transform.position = player.transform.position - (rotation * offset);

        //keep the camera looking at the player
        transform.LookAt(player.transform);

    }
}
