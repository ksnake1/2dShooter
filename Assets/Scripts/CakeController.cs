﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		_bakeSound = gameObject.GetComponent<AudioSource> ();
		Reset ();
		
	}
	
	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;
		//move ocean down
		_currentPos -= new Vector2 (speed, 0);

		//check if we need to reset
		if (_currentPos.x < endX) {
			//reset
			Reset ();
		}
		//apply changes
		_transform.position = _currentPos;
		if (_currentPos.x <= 530 && !isPlayed) {
			Debug.Log ("bake sound\n");
			_bakeSound.Play ();
			isPlayed = true;
		}
		
	}

	public void Reset(){

		float y = Random.Range (startY, endY);
		float dx = Random.Range (0, 300);
		_currentPos = new Vector2 (startX + dx, y);
		_transform.position = _currentPos;
		isPlayed = false;
	}
}
