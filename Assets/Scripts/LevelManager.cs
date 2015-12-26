using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		CleanUpLevel();
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Debug.Log("quit requested");
		Application.Quit();
	}
	
	//Loads next level by index
	public void LoadNextLevel(){
		CleanUpLevel();
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	void CleanUpLevel(){
		Brick.breakableCount = 0;
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}

}
