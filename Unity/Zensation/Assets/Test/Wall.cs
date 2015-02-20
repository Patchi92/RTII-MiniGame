using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public bool upWall;
	public bool downWall;
	public bool leftWall;
	public bool rightWall;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player")
		{
			if(upWall == true)
				other.GetComponent<Player>().up = false;
			else if(downWall == true)
				other.GetComponent<Player>().down = false;
			else if(leftWall == true)
				other.GetComponent<Player>().left = false;
			else if(rightWall == true)
				other.GetComponent<Player>().right = false;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player")
		{
			if(upWall == true)
				other.GetComponent<Player>().up = true;
			else if(downWall == true)
				other.GetComponent<Player>().down = true;
			else if(leftWall == true)
				other.GetComponent<Player>().left = true;
			else if(rightWall == true)
				other.GetComponent<Player>().right = true;
		}
	}
}
