using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

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


	// Use this for initialization
	void Start () {
		_tranform = gameObject.GetComponent<Transform> ();
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		_currentPos = _tranform.position;
		_currentPos -= _currentSpeed;
		_tranform.position = _currentPos;

		if (_currentPos.x <= -681) {
			Reset ();
		}
	}

	public void Reset(){
		float xSpeed = Random.Range (minXSpeed, maxXSpeed);
		float ySpeed = Random.Range (minYSpeed, maxYSpeed);

		_currentSpeed = new Vector2 (xSpeed, ySpeed);

		float y = Random.Range (-405, 414);
		_tranform.position = new Vector2 (702 + Random.Range(0,100), y);



	}
}
