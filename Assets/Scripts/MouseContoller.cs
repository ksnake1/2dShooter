using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Source File Name: MouseController.cs
 * Author's Name: Kyung Neung Lee
 * Last Modified by Kyung Neung Lee
 * Last Modified Date: Nov/22/2017
 * Program Description: Controls behaviour of mouse game object, how it moves by the control of a player
 * Revision History: Added functions that can help the mouse game object to jump and crawl down by the player's control
 * 
*/

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
	private int jumpHeight = 80;// Jump for 80 frames
	[SerializeField]
	private int crawlHeight = 50;// Crawl down for 80 frames


	private int jumpHeightCnt;// Counter for jump height calculation
	private bool jumping = false;//Signal that proghibit jumping again while jumping

	private int crawlHeightCnt;//Counter for crawl down height calculation
	private bool crawling = false;//Signal that proghibit crawling down again while crawling
	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		//initialize jumpheigh counter and crawl heignt counter
		jumpHeightCnt = jumpHeight;
		crawlHeightCnt = crawlHeight;
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		_currentPos = _transform.position;
		if (Input.GetKeyDown (KeyCode.W) && jumpHeightCnt == jumpHeight && crawlHeightCnt == crawlHeight) {//when w key triggered, and while not jumping and crawling previously initial jumping begins
			jumping = true;//singal jumping has started
			jump ();
		}
		else if (jumping) {
			
			jump ();//While jumping jump() called until it reaches maximum jump height
		}
		else if (jumpHeightCnt < jumpHeight && !jumping) {//maximum jump height reached
			fall ();//falls down until ground level
		}
		else if (Input.GetKeyDown (KeyCode.S) && crawlHeightCnt == crawlHeight && jumpHeightCnt == jumpHeight) {//when s key triggered, and while not jumping and crawling previously initial crawling begins
			crawling = true;//signal crawling has started
			crawlDown ();
		}
		else if (crawling) {

			crawlDown ();//While crawling crawlDown() called until it reaches maximum crawl height
		}
		else if (crawlHeightCnt < crawlHeight && !crawling) {//maximum crawl height reached
			crawlUp ();//Crawls back up to ground level
		}
		if (Input.GetKey (KeyCode.A) && crawlHeightCnt == crawlHeight) {//Horizontal move prohibited while crawling
			_currentPos -= new Vector2 (speed, 0);
		}
		if (Input.GetKey (KeyCode.D) && crawlHeightCnt == crawlHeight) {//Horizontal move prohibited while crawling
			_currentPos += new Vector2 (speed, 0);
		} 

		checkBounds();//Playable game object cannot go outside of view of camera
		_transform.position = _currentPos;
	}

	private void checkBounds(){
		//prohibit bounds of horizontal movement
		if (_currentPos.x < leftX) {
			_currentPos.x = leftX;
		}
		if (_currentPos.x > rightX) {
			_currentPos.x = rightX;
		}
	}

	private void jump(){
		// jumping function change vertical position until maximum height reached
		if (jumpHeightCnt > 0) {
			_currentPos += new Vector2 (0, jumpSpeed);
			jumpHeightCnt--;
		} 
		else {
			jumping = false;//at maximum height jumping becomes false

		}
		
	}

	private void fall(){//falls down to ground level
		if (jumpHeightCnt < jumpHeight) {
			_currentPos -= new Vector2 (0, jumpSpeed);
			jumpHeightCnt++;
		} 

	}

	private void crawlDown(){// crawling function change vertical position until maximum height reached
		if (crawlHeightCnt > 0) {
			_currentPos -= new Vector2 (0, jumpSpeed);
			crawlHeightCnt--;
		} 
		else {
			crawling = false;//at maximum height crawling becomes false

		}

	}

	private void crawlUp(){//crawls back up to ground level
		if (crawlHeightCnt < crawlHeight) {
			_currentPos += new Vector2 (0, jumpSpeed);
			crawlHeightCnt++;
		} 

	}
}
