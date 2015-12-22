using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 ballToPaddleVector;
	// Use this for initialization
	void Start () {
		paddle = FindObjectOfType<Paddle>();
		ballToPaddleVector = this.transform.position - paddle.transform.position;
	}
	
	
	void Update () {
		
		if(!hasStarted){
			//set the ball's position = to paddles current position + the offselt that it got form game start
			this.transform.position = paddle.transform.position + ballToPaddleVector;
			
			if(Input.GetMouseButtonDown(0)){
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2(2.0f,15.0f);
				print ("mouse clicked");
			}
		
		
		}
	

	}
}
