using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float speed = 25f;
	public float maxSpeed = 5f;
	private bool attack;
	private Rigidbody2D rigidBody2D;
	private Animator animator;
	public Transform fireArrow;
	public GameObject Normalarrow;
	public float fireRate = 1F;
	private float nextFire = 0.0F;


	void Start () {
		rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();



	}

	void Update () {
		animator.SetFloat ("Speed", Mathf.Abs (rigidBody2D.velocity.x));

		if (Input.GetMouseButtonDown (0)) {
			if (Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Instantiate (Normalarrow, fireArrow.position, fireArrow.rotation);
			}
				animator.SetTrigger ("Attack");
		}

	}


    void FixedUpdate ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		// this moves the player//
		rigidBody2D.AddForce ((Vector2.right * speed) * horizontal);
    }

}