using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {


	public Sprite[] hitSprites;
	public AudioClip crack;
	//TODO this doesnt reset when teh game restarts
	public static int breakableCount = 0;
	
	private LevelManager levelManager; 
	private int timesHit = 0;
	private bool isBreakable;

	void Start () {
		isBreakable = (this.tag == "Breakable");
		if(isBreakable){
			breakableCount++;
		}
		
		levelManager  = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnCollisionEnter2D(Collision2D collision ){
		if(isBreakable){
			AudioSource.PlayClipAtPoint(crack, transform.position, .3F);
			HandleDamage();
		}
	}
	
	void HandleDamage(){
		timesHit++;
		//always 1 more hit than the number of damage stages added
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			breakableCount--;
			//message the level manager when a  brick is destroyed
			levelManager.BrickDestroyed();
			print (breakableCount);
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
