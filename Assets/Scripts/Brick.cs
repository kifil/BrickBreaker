using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {


	public Sprite[] hitSprites;
	public AudioClip crack;
	public static int breakableCount = 0;
	public GameObject smoke;
	
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
	
	void OnCollisionExit2D(Collision2D collision ){
		if(isBreakable){
            AudioSource.PlayClipAtPoint(crack, transform.position, 1F);
			HandleDamage();
		}
	}
	
	void HandleDamage(){
		timesHit++;
		//always 1 more hit than the number of damage stages added
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			PuffSmoke();
			breakableCount--;
			//message the level manager when a  brick is destroyed
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		}
		else{
			UpdateSprite();
		}
	}
	
	void PuffSmoke(){
		GameObject smokePuff = Instantiate(smoke, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity)as GameObject;
		
		smokePuff.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
	}
	
	void UpdateSprite(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else{
			Debug.LogError("Missing damage sprite for brick '" + this.name + "' for damage level: " + timesHit);
		}

	
	}
	
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
	
}
