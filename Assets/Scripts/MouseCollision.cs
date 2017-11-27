using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Source File Name: MouseController.cs
 * Author's Name: Kyung Neung Lee
 * Last Modified by Kyung Neung Lee
 * Last Modified Date: Nov/22/2017
 * Program Description: Controls collision effect of mouse game object on what happens with its states
 * 						when it collides with other object, how it add and reduce score and life, and when it plays explosion and cake sound effect.
 * Revision History: Added BlinkShake and HappyShake fuction to give visual effect when mouse game object collides with bomb game object and cake game object.
 * 
*/

public class MouseCollision : MonoBehaviour {

	[SerializeField]
	GameController gameController;//Scoreboard and GUI controller that is affected by collision

	[SerializeField]
	GameObject explosion;

	private bool isImmune = false; //flag for mouse object that will be invincible for short time after collision
	private AudioSource _cakeSound;
	private AudioSource _bombSound;

	// Use this for initialization
	void Start () {
		
		_bombSound = gameObject.GetComponents<AudioSource>()[0];//assign explosion sound effect for bomb object collision
		_cakeSound = gameObject.GetComponents<AudioSource> ()[1];//assig sound effect for colliding cake object
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other){
		//Trigger when mouse object collide with colliders
		//Reference to COMP3064 lab

		if (other.gameObject.tag.Equals ("cake")) {//When colliding cake
			Debug.Log ("Collision cake\n");
			if (_cakeSound != null) {
				_cakeSound.Play ();
			}

			other.gameObject.GetComponent<CakeController>().Reset();//cake reset

			if(Player.Instance.Life >0)//Add points only when life is over 0 and game is playable
			{
				Player.Instance.Score+=100;//Add points
			}
			StartCoroutine("HappyShake");//Effect for colliding cake object
		}
		else if(other.gameObject.tag.Equals ("bomb") && !isImmune)//When colliding bomb and not under BlinkShake effect;
		{
			Debug.Log ("Collision bomb\n");
			if (_bombSound != null) 
			{
				_bombSound.Play ();//explosion sound played
			}
			Instantiate (explosion).GetComponent<Transform> ().position = other.gameObject.GetComponent<Transform> ().position; //explosion animation played
			other.gameObject.GetComponent<BombController>().Reset ();//bomb reset



			//Effect for colliding bomb starts
			StartCoroutine("BlinkShake");
			//Player loses a life
			Player.Instance.Life-=1;
		}

	}

	private IEnumerator BlinkShake(){
		//Mouse object makes BlinkShake effect
		//reference to comp3064 lab

		isImmune = true;//while BlinkShake, mouse object is immune to collision
		Color c;
		Renderer renderer = gameObject.GetComponent<Renderer> ();
		Vector2 shakePos;
		Transform _transform = gameObject.GetComponent<Transform>();

		//vertical movement
		for (int i = 0; i < 3; i++) {
			for (float f = 1f; f >= 0; f -= 0.1f) {
				shakePos = _transform.position;
				shakePos.x += 2f;
				_transform.position = shakePos;
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				yield return null;
			}
			for (float f = 0f; f <= 1.1; f += 0.1f) {
				shakePos = _transform.position;
				shakePos.x -= 2f;
				_transform.position = shakePos;
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				yield return null;
			}
			if (i == 2) {
				isImmune = false;
			}
		}
	}

	private IEnumerator HappyShake(){
		//Mouse object makes HappyShake effect
		Vector2 shakePos;
		Transform _transform = gameObject.GetComponent<Transform>();

		//horizontal movement
		for (int i = 0; i < 3; i++) {
			for (float f = 1f; f >= 0; f -= 0.1f) {
				shakePos = _transform.position;
				shakePos.y += 2f;
				_transform.position = shakePos;
				yield return null;
			}
			for (float f = 0f; f <= 1; f += 0.1f) {
				shakePos = _transform.position;
				shakePos.y -= 2f;
				_transform.position = shakePos;

				yield return null;
			}
		}
	}
}
