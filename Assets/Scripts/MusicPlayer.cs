using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	static MusicPlayer instance = null;
	
//	public MusicPlayer(){
//		musicPlayersCreated++;
//		print ("musics: " + musicPlayersCreated);
//	}
// music player awake and start is only called when there has been a muic plaeyer placed in the scene
	
	void Awake (){
		Debug.Log("music player awake: " + GetInstanceID());
		if(instance != null){
			Destroy(gameObject);
			print("self destructing");
		}
		//else this is the first music player
		else{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	void Start () {
		Debug.Log("music player start: " + GetInstanceID());


		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
