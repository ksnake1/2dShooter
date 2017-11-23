using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseContoller : MonoBehaviour {

	[SerializeField]
	private float speed = 3f;
	[SerializeField]
	private float jumpSpeed = 7f;
	[SerializeField]
	private float leftX;
	[SerializeField]
	private float rightX;
	[SerializeField]
	private int jumpHeight = 80;
	[SerializeField]
	private int crawlHeight = 50;


	private int jumpHeightCnt;
	private bool jumping = false;

	private int crawlHeightCnt;
	private bool crawling = false;
	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		jumpHeightCnt = jumpHeight;
		crawlHeightCnt = crawlHeight;
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		_currentPos = _transform.position;
		if (Input.GetKeyDown (KeyCode.UpArrow) && jumpHeightCnt == jumpHeight && crawlHeightCnt == crawlHeight) {
			jumping = true;
			jump ();
		}
		else if (jumping) {
			
			jump ();
		}
		else if (jumpHeightCnt < jumpHeight && !jumping) {
			fall ();
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow) && crawlHeightCnt == crawlHeight && jumpHeightCnt == jumpHeight) {
			crawling = true;
			crawlDown ();
		}
		else if (crawling) {

			crawlDown ();
		}
		else if (crawlHeightCnt < crawlHeight && !crawling) {
			crawlUp ();
		}
		if (Input.GetKey (KeyCode.LeftArrow) && crawlHeightCnt == crawlHeight) {
			_currentPos -= new Vector2 (speed, 0);
		}
		if (Input.GetKey (KeyCode.RightArrow) && crawlHeightCnt == crawlHeight) {
			_currentPos += new Vector2 (speed, 0);
		} 
		/*else {
			_currentPos -= new Vector2 (0, speed);
		}*/
		checkBounds();
		_transform.position = _currentPos;
	}

	private void checkBounds(){
		/*if (_currentPos.y > topY) {
			_currentPos.y = topY;
		}
		if (_currentPos.y < bottomY) {
			_currentPos.y = bottomY;
		}*/
		if (_currentPos.x < leftX) {
			_currentPos.x = leftX;
		}
		if (_currentPos.x > rightX) {
			_currentPos.x = rightX;
		}
	}

	private void jump(){
		if (jumpHeightCnt > 0) {
			_currentPos += new Vector2 (0, jumpSpeed);
			jumpHeightCnt--;
		} 
		else {
			jumping = false;

		}
		
	}

	private void fall(){
		if (jumpHeightCnt < jumpHeight) {
			_currentPos -= new Vector2 (0, jumpSpeed);
			jumpHeightCnt++;
		} 

	}

	private void crawlDown(){
		if (crawlHeightCnt > 0) {
			_currentPos -= new Vector2 (0, jumpSpeed);
			crawlHeightCnt--;
		} 
		else {
			crawling = false;

		}

	}

	private void crawlUp(){
		if (crawlHeightCnt < crawlHeight) {
			_currentPos += new Vector2 (0, jumpSpeed);
			crawlHeightCnt++;
		} 

	}
}
