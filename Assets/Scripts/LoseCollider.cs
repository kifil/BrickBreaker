using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public LevelManager levelManager;

	//basically event listeners for the OnTrigger and OnCollision events
	void OnTriggerEnter2D(Collider2D collider){
		print ("trigger!");
		levelManager.LoadLevel("Win");
	}
	
	void OnCollisionEnter2D(Collision2D collision ){
		print("collision");
	}
}
