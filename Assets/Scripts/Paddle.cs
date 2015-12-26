using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public bool autoPlay = false;
	
	private Ball ball;
	private float paddleLeftScreenBound;
	private float paddleRightScreenBound;
	
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
		SetPaddleScreenBounds();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			autoPlay =true;
		}
		if(Input.GetKeyDown(KeyCode.S)){
			autoPlay = false;
		}
	
		if(!autoPlay){
			MoveWithMouse();
		}
		else{
			AutoPlay();
		}
		
	}
	
	void AutoPlay(){
		//start the paddle in the current position in the editor
		Vector3 paddlePos = new Vector3(this.transform.position.x,this.transform.position.y,0f);
	
		paddlePos.x = Mathf.Clamp(ball.transform.position.x,paddleLeftScreenBound, paddleRightScreenBound);
		
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse(){
		//start the paddle in the current position in the editor
		Vector3 paddlePos = new Vector3(this.transform.position.x,this.transform.position.y,0f);
		
		//mouse pos in blocks = % of screen it is currently on times 16 world units
		float mousePositionInBlocks = (Input.mousePosition.x / Screen.width) * 16;
		paddlePos.x = Mathf.Clamp(mousePositionInBlocks,paddleLeftScreenBound, paddleRightScreenBound);
		
		this.transform.position = paddlePos;
	}
	
	void SetPaddleScreenBounds(){
		Vector2[] colliderBounds = this.GetComponent<PolygonCollider2D>().points;
		float leftBound = 0;
		float rightBoound = 0;
		//determine the width of the paddle far left and right bounds using its collider bounds
		foreach(Vector2 bound in colliderBounds){
			if(bound.x < leftBound){
				leftBound = bound.x;
			}
			if(bound.x > rightBoound){
				rightBoound = bound.x;
			}
		}
		
		//multiply collider bounds by the obejct scale
		paddleLeftScreenBound = 0f - (leftBound * this.transform.localScale.x);
		paddleRightScreenBound = 16f - (rightBoound * this.transform.localScale.x);
	
	}
}
