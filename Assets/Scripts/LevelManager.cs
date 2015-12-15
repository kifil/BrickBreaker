using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log("level load for" + name);
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Debug.Log("quit requested");
		Application.Quit();
	}

}
