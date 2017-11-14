using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cakeLandController : MonoBehaviour {
	//public variables
	[SerializeField]
	private	float speed = 5f;
	[SerializeField]
	private	float startX;
	[SerializeField]
	private	float endX;

	//private variables
	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;
		_currentPos -= new Vector2 (speed, 0);

		if (_currentPos.x < endX) {
			Reset ();
		}

		_transform.position = _currentPos;
	}

	private void Reset(){
		_currentPos = new Vector2 (startX, 0);
	}
}
