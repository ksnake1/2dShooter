using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
 * Source File Name: GameController.cs
 * Author's Name: Kyung Neung Lee
 * Last Modified by Kyung Neung Lee
 * Last Modified Date: Nov/22/2017
 * Program Description: Controls UI messages and score boards of the game
 * Revision History: Added newRecord function, so it can show distinct message when new record is made.
 * 
*/

public class GameController : MonoBehaviour {

	[SerializeField]
	Text lifeLabel;
	[SerializeField]
	Text scoreLabel;
	[SerializeField]
	Text gameOverLabel;
	[SerializeField]
	Text highScoreLabel;
	[SerializeField]
	Button restartBtn;
	[SerializeField]
	GameObject Character;//playerble character




	private void initialize (){
		//initially score and life reset, GUI for gameover is set false, gameplay GUI set true
		Player.Instance.Score = 0;
		Player.Instance.Life = 3;

		gameOverLabel.gameObject.SetActive (false);
		highScoreLabel.gameObject.SetActive (false);
		restartBtn.gameObject.SetActive (false);

		lifeLabel.gameObject.SetActive (true);
		scoreLabel.gameObject.SetActive (true);
		Character.gameObject.SetActive (true);
	}

	public void updateUI(){
		//Modify GUI during gameplay
		scoreLabel.text = "Score: " + Player.Instance.Score;
		lifeLabel.text = "Life: " + Player.Instance.Life;
		highScoreLabel.text = "Score Record: " + Player.Instance.HighScore;

	}

	public void gameOver(){
		//gameover disable playerable character, score and life; Displays gameover lable, record score and restart button
		
		gameOverLabel.gameObject.SetActive (true);
		highScoreLabel.gameObject.SetActive (true);
		restartBtn.gameObject.SetActive (true);

		lifeLabel.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
		Character.gameObject.SetActive (false);//playerable game object disappers when game is over
	}

	// Use this for initialization
	void Start () {
		Player.Instance.gCtrl = this;
		initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartBtnClick(){
		//reload the scene
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

	}

	public void newRecord(){
		//show new record score made
		highScoreLabel.text = "New Record: " + Player.Instance.HighScore + "!!!";
	}

}
