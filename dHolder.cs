using UnityEngine;
using System.Collections;

public class dHolder : MonoBehaviour {
	public string dialogue;
	private dialogueM dMAn;


	// Use this for initialization
	void Start () {
		dMAn = FindObjectOfType<dialogueM> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void onTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
				dMAn.ShowBox (dialogue);
		}

	}
}
