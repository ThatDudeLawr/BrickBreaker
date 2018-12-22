using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		Debug.Log(paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			//Lock the ball to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			//If Left Click is pressed, ball velocity is changed making it not being locked anymore
			if(Input.GetMouseButtonDown(0)){
				print ("Mouse button is clicked");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f,10f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		AudioSource audio = this.gameObject.GetComponent<AudioSource>();
		Vector2 tweak = new Vector2(Random.Range(0f, 0.25f), Random.Range(0f,0.25f));
		if(hasStarted){
		audio.Play();
		gameObject.GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
