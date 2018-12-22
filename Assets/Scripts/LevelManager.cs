using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel(string name){
		Debug.Log("Level load is requested for " + name);
		SceneManager.LoadScene(name);
		Brick.breakableCount = 0;
	}

	public void QuitRequest(){
		Debug.Log("Quit request has been sent");
		Application.Quit();
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		Brick.breakableCount=0;
	}

	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}

}