using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Player : MonoBehaviour {
	// Arduino
	SerialPort sp = new SerialPort("COM4", 9600);

	bool arduW = false;
	bool arduS = false;
	bool arduQ = false;


	//Day and Night Cycle
	public bool cycle = true;
	public Sprite daySprite;
	public Sprite nightSprite;

	//Movement

	public bool up = true;
	public bool down = true;

	// Game Mechanics
	public int irritationLevel = 0;

	// Use this for initialization
	void Start () {
		sp.Open();
		sp.ReadTimeout = 1;

		sp.Write("GameStart");
	}

	// Update is called once per frame
	void Update () {

		arduW = false;
		arduS = false;



		if(sp.IsOpen)
		{
			try
			{
				Arduino(sp.ReadByte());
			}
			catch
			{

			}
		}
	
		float movment = 10f * Time.deltaTime;

		Debug.Log (irritationLevel);

		//Movement keys

		if((Input.GetKey (KeyCode.W) || arduW == true) && up == true)
		{
			transform.position += new Vector3(0f, movment, 0f);
		}
		
		if((Input.GetKey (KeyCode.S) || arduS == true) && down == true)
		{
			transform.position -= new Vector3(0f, movment, 0f);
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

	void Arduino(int ArduInput)
	{
		//Movement
		
		if(ArduInput == 1)
		{
			arduW = true;
			Debug.Log("W");
		}else {
			arduW = false;
		}

		if(ArduInput == 2)
		{
			arduS = true;
			Debug.Log("S");
		}else {
			arduS = false;
		}

		if(ArduInput == 3)
		{
			cycle = true;
			Debug.Log("Q");
		}

		if(ArduInput == 4)
		{
			cycle = false;
			Debug.Log("Q");
		}
	}
}
