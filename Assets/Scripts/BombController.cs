using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Source File Name: BombController.cs
 * Author's Name: Kyung Neung Lee
 * Last Modified by Kyung Neung Lee
 * Last Modified Date: Nov/22/2017
 * Program Description: Controls behaviour of bomb game object 
 * 						where it resets and how it moves and where it plays sound effect.
 * Revision History: Added isPlayed boolean variable as a flag to control when shooting sound effect is played.
 * 
*/

public class BombController : MonoBehaviour {

	//maximum and minimum speed bomb object will travel
	[SerializeField]
	float minXSpeed = 5f;
	[SerializeField]
	float maxXSpeed = 10f;
	[SerializeField]
	float minYSpeed = -2f;
	[SerializeField]
	float maxYSpeed = 2f;

	private Transform _tranform;
	private Vector2 _currentSpeed;
	private Vector2 _currentPos;
	private AudioSource _shootingSound;
	private bool isPlayed = false;//a flag to keep shooting ound played only once per shot

	// Use this for initialization
	void Start () {
		_tranform = gameObject.GetComponent<Transform> ();//transformation of bomb object
		_shootingSound = gameObject.GetComponent<AudioSource> ();
		Reset ();//travel begins from the reset position
	}
	
	// Update is called once per frame
	void Update () {
		_currentPos = _tranform.position;
		_currentPos -= _currentSpeed;//position of bomb object updates toward left
		_tranform.position = _currentPos;

		if (_currentPos.x <= -650) {//bomb reset after out of camera view
			Reset ();
		}
		if (_currentPos.x <= 534 && !isPlayed){//shooting sound played once it fully appears in camera view
			Debug.Log ("shooting sound\n");
			_shootingSound.Play();
			isPlayed = true;//shooting sound not played remaining trip until resetted
		}
	}

	public void Reset(){
		//Bomb is reset to starting position to shot thru again after it gets out of sight
		//Reference to COMP3064 lab
		float xSpeed = Random.Range (minXSpeed, maxXSpeed);//every reset ramdomly set speed of bomb object
		float ySpeed = Random.Range (minYSpeed, maxYSpeed);

		_currentSpeed = new Vector2 (xSpeed, ySpeed);

		float y = Random.Range (-405, 414);//randomly set initial position of bomb
		_tranform.position = new Vector2 (670 + Random.Range(0,1000), y);
		isPlayed = false;//shooting sound is available for trigger



	}
}
