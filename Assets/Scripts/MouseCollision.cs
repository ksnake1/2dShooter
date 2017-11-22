using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCollision : MonoBehaviour {

	[SerializeField]
	GameController gameController;

	[SerializeField]
	GameObject explosion;


	private AudioSource _cakeSound;
	private AudioSource _bombSound;

	// Use this for initialization
	void Start () {
		
		_bombSound = gameObject.GetComponents<AudioSource>()[0];
		_cakeSound = gameObject.GetComponents<AudioSource> ()[1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other){


		if (other.gameObject.tag.Equals ("cake")) {
			Debug.Log ("Collision cake\n");
			if (_cakeSound != null) {
				_cakeSound.Play ();
			}

			other.gameObject.GetComponent<CakeController>().Reset();
			//Add points

			Player.Instance.Score+=100;
		}else if(other.gameObject.tag.Equals ("bomb")){
			Debug.Log ("Collision bomb\n");
			if (_bombSound != null) {
				_bombSound.Play ();
			}
			Instantiate (explosion).GetComponent<Transform> ().position = other.gameObject.GetComponent<Transform> ().position;
			other.gameObject.GetComponent<BombController>().Reset ();



			Player.Instance.Life-=1;

			//StartCoroutine( "Blink");
		}

	}

	private IEnumerator Blink(){

		Color c;
		Renderer renderer = 
			gameObject.GetComponent<Renderer> ();
		for (int i = 0; i < 3; i++) {
			for (float f = 1f; f >= 0; f -= 0.1f) {
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				yield return new WaitForSeconds (.1f);
			}
			for (float f = 0f; f <= 1; f += 0.1f) {
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				yield return new WaitForSeconds (.1f);
			}
		}
	}
}
