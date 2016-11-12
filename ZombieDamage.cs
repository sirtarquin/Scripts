using UnityEngine;
using System.Collections;

public class ZombieDamage : MonoBehaviour {
	public int damage;
	public float damageRate;
	public float pushBackForce;
	public float speed = 10f;
	private Animator zanimator;

	//Attacking 
	public float walkingtime;
	float startWalking;
	bool walking;
	Rigidbody2D ZombieRB;


	float nextDamage;

	bool playerInRange = false;
	GameObject Play;
	PHealth thePH;


	// Use this for initialization
	void Start () {
		nextDamage = Time.time;
		Play = GameObject.FindGameObjectWithTag("Player");
		thePH = Play.GetComponent<PHealth> ();
		zanimator = GetComponent<Animator> ();
		ZombieRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInRange) Attack ();

	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			playerInRange = true; 
			walking = true;
			startWalking = Time.time + walkingtime;
			if (startWalking >= Time.time) {
				ZombieRB.AddForce (new Vector2 (-1, 0) * speed);
				zanimator.SetBool ("speed", walking);
				thePH.Die ();
			}
		}
	}
	void OnTriggerExit2D (Collider2D other){
		if (other.tag == "Player") {
			playerInRange = false; 
			walking = false;
			ZombieRB.velocity = new Vector2 (0f, 0f);
			zanimator.SetBool ("speed", walking);
		}
	}
	void Attack (){
		if (nextDamage <= Time.time) {
			thePH.addDamage (damage);
			nextDamage = Time.time + damageRate;

			pushBack (Play.transform);

		}
	}
	void pushBack (Transform pushedObject) {
		Vector2 pushdir = new Vector2 (- pushedObject.position.x, 0 - transform.position.x);
			pushdir*=pushBackForce;

		Rigidbody2D pushRB = pushedObject.GetComponent<Rigidbody2D> ();
		pushRB.velocity = Vector2.zero;
			pushRB.AddForce(pushdir,ForceMode2D.Impulse);
	}

}
