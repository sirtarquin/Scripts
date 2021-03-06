using UnityEngine;
using System.Collections;

public class Arrowcontroller : MonoBehaviour {

	public float speed;
	public float Damage;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnTriggerEnter2D (Collider2D other)
	{	
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			Destroy (gameObject);
			if (other.tag == "Enemy"){
				Zombie1 hurtZombie = other.gameObject.GetComponent<Zombie1> ();
				hurtZombie.addDamage (Damage);
			}
		}
		
	}

}
