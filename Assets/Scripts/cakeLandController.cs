using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Source File Name: cakeLandController.cs
 * Author's Name: Kyung Neung Lee
 * Last Modified by Kyung Neung Lee
 * Last Modified Date: Nov/18/2017
 * Program Description: Controls behaviour of background image that gives the notion of speed in the game
 * Revision History: Revised to clone the background image so that the cloned image and the original image follow behind of each other 
 * 					to show seamless repetition of the background
 * 
*/

public class cakeLandController : MonoBehaviour {
	//public variables
	[SerializeField]
	private	float speed = 5f;
	[SerializeField]
	private	float startX;
	[SerializeField]
	private	float midX;
	[SerializeField]
	private	float endX;
	[SerializeField]
	private	float repeatX;

	//private variables
	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		Reset ();//background image initially resets 
		_transform.position = _currentPos;
	}
	
	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;
		_currentPos -= new Vector2 (speed, 0);

		if (_currentPos.x < midX) {//when right most side of background image cakeLand reaches right most boundary of camera view, Repeat() method is called to have the images repeats from the beginning
			Repeat ();
		}

		if (_currentPos.x < endX) {
			Reset ();
		}

		_transform.position = _currentPos;
	}

	private void Reset(){
		if (gameObject.name.Contains ("(Clone)")) {//once cloned, images resets different position
			_currentPos = new Vector2 (repeatX, 0);
			return;
		}
		
		_currentPos = new Vector2 (startX, 0);
	}

	private void Repeat(){//background image is cloned and follows original image
		if (!gameObject.name.Contains("(Clone)"))//if there is no image cloned previously, image is cloned once
		{
			Instantiate (gameObject);
			gameObject.name = "(Clone)";
		}
	
	}
}
