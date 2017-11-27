using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Source File Name: CakeController.cs
 * Author's Name: Kyung Neung Lee
 * Last Modified by Kyung Neung Lee
 * Last Modified Date: Nov/22/2017
 * Program Description: Controls behaviour of cake game object 
 * 						where it resets and how it moves and where it plays sound effect.
 * Revision History: Added isPlayed boolean variable as a flag to control when bake(when the cake game object enters the view of main camera) sound effect is played.
 * 
*/

public class CakeController : MonoBehaviour {

	//Public variables
	[SerializeField]
	private float speed = 3f;
	[SerializeField]
	private float startY;
	[SerializeField]
	private float endY;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;

	//private variables
	private AudioSource _bakeSound;
	private Transform _transform;
	private Vector2 _currentPos;
	private bool isPlayed = false;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		_bakeSound = gameObject.GetComponent<AudioSource> ();//sound effect for initial appearance of cake game object
		Reset ();
		
	}
	
	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;
		//move cake object toward left
		_currentPos -= new Vector2 (speed, 0);

		//check if we need to reset
		if (_currentPos.x < endX) {
			//reset
			Reset ();
		}
		//apply changes
		_transform.position = _currentPos;
		if (_currentPos.x <= 530 && !isPlayed) {//triggers bake sound to be played when cake fully appears within camera view
			Debug.Log ("bake sound\n");
			_bakeSound.Play ();
			isPlayed = true;//flag signals that bake sound played once per appearance until reset
		}
		
	}

	public void Reset(){
		//When cake game object out of sight it reset
		float y = Random.Range (startY, endY);
		float dx = Random.Range (0, 300);//randomly decide initial position of cake outside of right boundary of camera view
		_currentPos = new Vector2 (startX + dx, y);
		_transform.position = _currentPos;
		isPlayed = false;//bake sound is available for play
	}
}
