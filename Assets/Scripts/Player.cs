using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

	static private Player _instance;
	static public Player Instance{
		get{ 
			if (_instance == null) {
				_instance = new Player ();
			}
			return _instance;
		}
	}
	private Player (){


		
	}

	public GameController gCtrl;

	public int _score = 0;
	public int _life = 3;
	public int _highScore = 0;

	public int Score{
		get{
			return _score;
		}
		set{ 
			_score = value;
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
					HighScore = Score;
				}
				gCtrl.gameOver ();
			} 
			else {
				gCtrl.updateUI ();

			}
		}
	}

	public int HighScore{
		get{
			return _highScore;
		}
		set{ 
			_highScore = value;
			gCtrl.updateUI ();

		}
	}
}
