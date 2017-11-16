using System.Collections;
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
		//move ocean down
		_currentPos -= new Vector2 (speed, 0);

		//check if we need to reset
		if (_currentPos.x < endX) {
			//reset
			Reset ();
		}
		//apply changes
		_transform.position = _currentPos;
		
	}

	private void Reset(){

		float y = Random.Range (startY, endY);
		float dx = Random.Range (0, 300);
		_currentPos = new Vector2 (startX + dx, y);
	}
}
