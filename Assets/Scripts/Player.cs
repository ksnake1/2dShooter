using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Source File Name: Player.cs
 * Author's Name: Kyung Neung Lee
 * Last Modified by Kyung Neung Lee
 * Last Modified Date: Nov/22/2017
 * Program Description: It helps to keep player information such as score, life, and score recored information
 * Revision History: Revised to call newRecord method of gameController class when _highScore is modified.
 * 
*/

public class Player {

	static private Player _instance;
	static public Player Instance{
		//player instance associated to game controller to make change to GUI and player record
		get{ 
			if (_instance == null) {
				_instance = new Player ();
			}
			return _instance;
		}
	}
	private Player (){


		
	}

	public GameController gCtrl;//associated to game controller to make change on GUI textboxes

	public int _score = 0;
	public int _life = 3;
	public int _highScore = 0;

	public int Score{
		get{
			return _score;
		}
		set{ 
			_score = value;//when score changes ui is updated
			gCtrl.updateUI ();
		}
	}

	public int Life{
		get{
			return _life;
		}
		set{ 
			_life = value;
			if (_life <= 0) {
				if (Score > HighScore) {
					HighScore = Score;// at gameover, if score exceeds highest previous score, the score becomes the new highest score

				}
				gCtrl.gameOver ();//gameover is called when life goes less than 1
			} 
			else {
				gCtrl.updateUI ();//ui is updated when life is above 0 and there is change

			}
		}
	}

	public int HighScore{
		get{
			return _highScore;
		}
		set{ 
			_highScore = value;
			gCtrl.newRecord ();//when highestscore changes new score is recorded

		}
	}
}
