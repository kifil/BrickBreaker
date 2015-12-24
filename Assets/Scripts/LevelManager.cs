using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
	//TODO figure out a nicer solution for this
		Brick.breakableCount = 0;
		Debug.Log("level load for" + name);
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Debug.Log("quit requested");
		Application.Quit();
	}
	
	//Loads next level by index
	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}

}
