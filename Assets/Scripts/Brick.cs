using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public Sprite[] hitSprites;
	public AudioClip crack;
	private LevelManager levelManager;
	private int timesHit;
	public static int breakableCount=0;
	private bool isBreakable;
	public GameObject smoke;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if(isBreakable){
			breakableCount++;
			Debug.Log("Total bricks: " + breakableCount);
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnCollisionEnter2D (Collision2D collision){
		AudioSource.PlayClipAtPoint(crack, transform.position, 2f);
		if(isBreakable){
			HandleHits();
		}
	}

	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(maxHits<=timesHit){
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
		} else{
			LoadSprites();
		}
	}

	void PuffSmoke(){
			GameObject smokePuff = Instantiate(smoke,transform.position,Quaternion.identity);
			ParticleSystem.MainModule main = smokePuff.GetComponent<ParticleSystem>().main;
			main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	void LoadSprites(){
		int spriteIndex = timesHit - 1;

		//It is not mandatory, the if statement checks for the existence of the sprite index before loading it to not be able to accept "Blank"
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex]; 
		}else{
			Debug.LogError ("No sprite found at the " + spriteIndex + "index.");
		}
	}
		//SimulateWin();
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}


