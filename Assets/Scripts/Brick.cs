using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	//public int maxHits;
	public Sprite[] hitSprites;
	
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
		bool isBreakable =(this.tag == "Breakable");
		if(isBreakable){
			HandleDamage();
		}
	}
	
	void HandleDamage(){
		timesHit++;
		//always 1 more hit than the number of damage stages added
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			Destroy(gameObject);
		}
		else{
			UpdateSprite();
		}
	}
	
	void UpdateSprite(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}

	
	}
	
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
	
}
