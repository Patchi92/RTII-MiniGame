using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void ChangeToScene (string nameOfScene) {
		Application.LoadLevel(nameOfScene);
	}
	public void Exit () {
		Application.Quit();
	}

}