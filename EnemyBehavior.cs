using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    //assign variables
    public GameObject player;
    public GameObject playerFollow;
    public Transform player_T;
    public GameObject level;
    public float speed;         //assign in engine
    public int knockback;     //assign in engine
    public PlayerMovement playerMovement;
    public LevelControl levelControl;
    public int health;          //assign in engine
    public Rigidbody eBody;
    public Animator n_Teddy;

    void Start () {
        //initialize variables
        playerFollow = GameObject.FindGameObjectWithTag("ComeGetMe");
        player_T = playerFollow.GetComponent<Transform>();
        level = GameObject.FindGameObjectWithTag("Level");
        player = GameObject.FindGameObjectWithTag("Baby");
        playerMovement = player.GetComponent<PlayerMovement>();
        levelControl = level.GetComponent<LevelControl>();
        eBody = GetComponent<Rigidbody>();
        n_Teddy = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //set enemy movement speed
        float step = speed * Time.deltaTime;
        //make the enemy look at the player
        transform.LookAt(player_T);
        //make enemy move towards the player
        transform.position = Vector3.MoveTowards(transform.position, player_T.position, step);

        //if health is 0, kill the enemy
        if (health <= 0)
        {
            DestroyObject(gameObject);
        }
	}

    void OnTriggerEnter(Collider collider)
    {
       //if the enemy collides with the player...
       if(collider.tag == "Baby")
        {
            n_Teddy.Play("Attack", -1, 0f);
            //if the player isn't vulnerable...
            if (playerMovement.immune == false)
            {
                //deal damage and begin the player's invincibility frames
                levelControl.playerHealth -= 1;
                playerMovement.immuneTime = 0;
                playerMovement.takenDamage = true;
                //knock the player backwards
                if (collider.GetComponent<Transform>().position.x < transform.position.x)
                {
                    if (collider.GetComponent<Transform>().position.z < transform.position.z)
                    {
                        collider.GetComponent<Rigidbody>().velocity = new Vector3(-knockback, knockback, -knockback);
                    }
                    else if(collider.GetComponent<Transform>().position.z > transform.position.z)
                    {
                        collider.GetComponent<Rigidbody>().velocity = new Vector3(-knockback, knockback, knockback);
                    }
                }
                else if (collider.GetComponent<Transform>().position.x > transform.position.x)
                {
                    if (collider.GetComponent<Transform>().position.z < transform.position.z)
                    {
                        collider.GetComponent<Rigidbody>().velocity = new Vector3(knockback, knockback, -knockback);
                    }
                    else if (collider.GetComponent<Transform>().position.z > transform.position.z)
                    {
                        collider.GetComponent<Rigidbody>().velocity = new Vector3(knockback, knockback, knockback);
                    }
                }
            }
        }

       //if a bullet hits the enemy...
        if (collider.tag == "Bullet")
        {
            health -= 1;
            Destroy(collider.gameObject);
            n_Teddy.Play("Stagger", -1, 0f);
        }

       
    }
}
