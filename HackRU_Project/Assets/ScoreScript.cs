using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public static int score = 0;
	public static int highscore = 0;
	// Use this for initialization
	public Text scoreboard;
	public Text highscoreboard;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "Green_Wall" || coll.gameObject.name == "Yellow Wall 2" || 
		    coll.gameObject.name == "Yellow Wall" ) {
			score++;
			if(score>highscore){
				highscore = score;
			}
		}
		
	}

	void Update(){
		scoreboard.text ="Bounces: " + score;
		highscoreboard.text = "Highscore: " + highscore;
	}


}
