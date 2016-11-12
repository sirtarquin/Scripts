using UnityEngine;
using System.Collections;

public class PHealth : MonoBehaviour {

	private Animator animator;
	public int fullHealth;
	public int currentHealth;
	ZombieDamage ZD;

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		//HUD
		animator = gameObject.GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {

	}
	public void addDamage (int damage){
		if (currentHealth >= 0) return; {
			currentHealth -= damage;
			animator.SetTrigger ("Hit");
		}
		if (currentHealth < 0)
		{
			animator.SetTrigger ("Death");
		}
	}
	public void Die (){
		Application.LoadLevel (Application.loadedLevel);
	}
}
