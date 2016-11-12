using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

	public float speed = 10f;
	private Animator zanimator;

	//Attacking 
	public float walkingtime;
	float startWalking;
	bool walking;
	Rigidbody2D ZombieRB;

	// Use this for initialization
	void Start () {
		zanimator = GetComponent<Animator> ();
		ZombieRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void onTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			walking = true;
			startWalking = Time.time + walkingtime;
		}
	}
	void onTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			if (startWalking >= Time.time) {
				ZombieRB.AddForce (new Vector2 (-1, 0) * speed);
				zanimator.SetBool ("speed", walking);
			}
		}
	}

}
