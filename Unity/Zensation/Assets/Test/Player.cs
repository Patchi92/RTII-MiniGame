using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//Day and Night Cycle
	public bool cycle = true;
	public Sprite daySprite;
	public Sprite nightSprite;

	//Movement
	public bool left = true;
	public bool right = true;
	public bool up = true;
	public bool down = true;

	// Game Mechanics
	public int irritationLevel = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		float movment = 10f * Time.deltaTime;

		Debug.Log (irritationLevel);

		//Movement Keys

		if(Input.GetKey (KeyCode.W) && up == true)
		{
			transform.position += new Vector3(0f, movment, 0f);
		}

		if(Input.GetKey (KeyCode.S) && down == true)
		{
			transform.position -= new Vector3(0f, movment, 0f);
		}

		if(Input.GetKey (KeyCode.A) && left == true)
		{
			transform.position -= new Vector3(movment, 0f, 0f);
		}

		if(Input.GetKey (KeyCode.D) && right == true)
		{
			transform.position += new Vector3(movment, 0f, 0f);
		}


		//Switch

		if(Input.GetKeyDown (KeyCode.Q))
		{

			if(cycle == true)
				cycle = false;
			else if (cycle == false)
				cycle = true;
		}



		if(cycle)
			gameObject.GetComponent<SpriteRenderer> ().sprite = daySprite;

		if(!cycle)
			gameObject.GetComponent<SpriteRenderer> ().sprite = nightSprite;

	}

	public void IncreaseLevel(){
		irritationLevel++;
	}
}
