using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScoreText : MonoBehaviour {

	int HighScore;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
		GameObject EndScore = GameObject.FindWithTag("Score");
		HighScore = EndScore.GetComponent<FinalScore>().Score;
		
		Text sText = this.gameObject.GetComponent<Text>();
		sText.text = "Final Score: " + HighScore;

	}
}
