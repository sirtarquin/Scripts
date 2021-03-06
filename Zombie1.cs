using UnityEngine;
using System.Collections;

public class Zombie1 : MonoBehaviour {
	
	private Animator animator;

	private bool isDead
	{
		get
		{
			return currentHealth <=0;
		}
	
	}

	public float enemyMaxHealth;
	float currentHealth;

	// Use this for initialization
	void Start () {
		
		currentHealth = enemyMaxHealth;

		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	public void addDamage(float damage){
		currentHealth -= damage;
		if (currentHealth < 0){
			animator.SetTrigger ("Death");
			Destroy (GetComponent<BoxCollider2D> ());
			Destroy (gameObject, 2.5f);
	}
		if (currentHealth >= 0){
			animator.SetTrigger ("Hit");
	}
	}
}