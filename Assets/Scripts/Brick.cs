using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	
	private LevelManager levelManager; 
	private int timesHit = 0;
	// Use this for initialization
	void Start () {
		levelManager  = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D collision ){
		timesHit++;
		if(timesHit >= maxHits){
			Destroy(gameObject);
		}
	}
	
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
	
}
