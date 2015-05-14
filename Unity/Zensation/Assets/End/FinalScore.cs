using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {
	


	public int Score;
	public GameObject Load;
	GameObject Player;

	// Use this for initialization
	void Start () {
	

		Player = GameObject.FindWithTag("Player");


		DontDestroyOnLoad(Load);

	

	}
	
	// Update is called once per frame
	void Update () {

		Score = Player.GetComponent<Player>().playerScore;






	}
}
