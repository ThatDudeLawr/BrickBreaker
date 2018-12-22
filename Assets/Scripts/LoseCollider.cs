using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

private LevelManager levelManager;

void Start(){
	levelManager = GameObject.FindObjectOfType<LevelManager>();
}
void OnCollisionEnter2D (Collision2D collision){
	print ("Collision");
}

void OnTriggerEnter2D (Collider2D collision){
	print ("Trigger lose");
	levelManager.LoadLevel("Lose");
}


}
