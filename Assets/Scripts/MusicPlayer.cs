using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	// Use this for initialization
	void Awake(){
		Debug.Log ("I am Awake: " + GetInstanceID());
		if(instance != null){
			Destroy(gameObject);
			print("Duplicate Music Player self destructing");
		} else{
			instance = this;
		}
		GameObject.DontDestroyOnLoad(gameObject);
	}
	void Start () {
		Debug.Log("I am Start: " + GetInstanceID());

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
