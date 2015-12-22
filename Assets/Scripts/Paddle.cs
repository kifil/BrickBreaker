﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//start the paddle in the current position in the editor
		Vector3 paddlePos = new Vector3(this.transform.position.x,this.transform.position.y,0f);
	
		float mousePositionInBlocks = (Input.mousePosition.x / Screen.width) * 16;
		paddlePos.x = Mathf.Clamp(mousePositionInBlocks,0.5f, 15.5f);
		
		this.transform.position = paddlePos;
		
	}
}
