using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();


		if(Input.GetKeyDown(KeyCode.P))
		{
			if(Time.timeScale == 1)
				pauseGame();
			else if (Time.timeScale == 0)
				resumeGame();
		} 
	}

	void resumeGame(){
		Time.timeScale = 1F;
		Screen.showCursor = false;
	}

	void pauseGame(){
		Time.timeScale = 0F;
		Screen.showCursor = true;
	}


}
