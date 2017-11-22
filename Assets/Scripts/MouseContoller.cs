using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseContoller : MonoBehaviour {

	[SerializeField]
	private float speed = 7f;
	[SerializeField]
	private float topY;
	[SerializeField]
	private float bottomY;
	[SerializeField]
	private float leftX;
	[SerializeField]
	private float rightX;




	private int jumpHeight = 20;
	private bool jumping = true;
	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		_currentPos = _transform.position;
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			jump ();
		}
		if (jumpHeight < 20 && jumping) {
			
			jump ();
		}
		if (jumpHeight <= 20 && !jumping) {
			fall ();
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			_currentPos -= new Vector2 (0, speed);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			_currentPos -= new Vector2 (speed, 0);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			_currentPos += new Vector2 (speed, 0);
		} 
		/*else {
			_currentPos -= new Vector2 (0, speed);
		}*/
		checkBounds();
		_transform.position = _currentPos;
	}

	private void checkBounds(){
		if (_currentPos.y > topY) {
			_currentPos.y = topY;
		}
		if (_currentPos.y < bottomY) {
			_currentPos.y = bottomY;
		}
		if (_currentPos.x < leftX) {
			_currentPos.x = leftX;
		}
		if (_currentPos.x > rightX) {
			_currentPos.x = rightX;
		}
	}

	private void jump(){
		if (jumpHeight > 0) {
			_currentPos += new Vector2 (0, speed);
			jumpHeight--;
		} 
		else {
			jumping = false;
		}
		
	}

	private void fall(){
		if (jumpHeight < 20) {
			_currentPos -= new Vector2 (0, speed);
			jumpHeight++;
		} 
		else {
			jumping = true;
		}
	}
}
