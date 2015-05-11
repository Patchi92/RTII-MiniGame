using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;

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

	float movment = 25f;
	public bool up = true;
	public bool down = true;
	float stopCD = 0;

	// Score

	int playerScore = 0;
	public GameObject scoreText;

	// Game Mechanics


	// Use this for initialization
	void Start () {

		OpenArduino();

		sp.Write("6");
	}

	// Update is called once per frame
	void Update () {

		//Score

		playerScore++;
		Text sText = scoreText.GetComponent<Text>();
		sText.text = "Score : " + playerScore;






		arduS = false;
		arduW = false;



		//Arduino

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
	
	


		//Movement keys
		

		if(Input.GetKey (KeyCode.W) && up == true)
		{
			transform.position += new Vector3(0f, movment, 0f) * Time.deltaTime;

		}
		
		if(Input.GetKey (KeyCode.S) && down == true)
		{
			transform.position -= new Vector3(0f, movment, 0f) * Time.deltaTime;

		}




		if(arduW == true && up == true)
		{
			transform.position += new Vector3(0f, movment, 0f) * Time.deltaTime;
			Debug.Log("W");
		}

		if(arduS == true && down == true)
		{
			transform.position -= new Vector3(0f, movment, 0f) * Time.deltaTime;
			Debug.Log("S");
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
		Debug.Log("Avs");
		sp.Write("Reduce");
	}

	void Arduino(int ArduInput)
	{
		//Movement

		// Up

			if(ArduInput == 1 && up == true)
		{
			arduW = true;
		} 

		// Down

			if(ArduInput == 2 && down == true)
		{
			arduS = true;
		} 


	

		// Day Time

		if(ArduInput == 3)
		{
			cycle = true;
			Debug.Log("Q");
		}

		// Night time

		if(ArduInput == 4)
		{
			cycle = false;
			Debug.Log("Q");
		}

		// Game Over

		if(ArduInput == 5)
		{
			//Application.LoadLevel("End");
		}
	}

	void OpenArduino()
	{

		if (sp != null) 
		{
			if (sp.IsOpen) 
			{
				sp.Close();
				print("Closing port, because it was already open!");
			}
			else 
			{
				sp.Open();  // opens the connection
				sp.ReadTimeout = 1;  // sets the timeout value before reporting error
				print("Port Opened!");
			}
		}
		else 
		{
			if (sp.IsOpen)
			{
				print("Port is already open");
			}
			else 
			{
				print("Port == null");
			}
		}
	}

	void OnApplicationQuit() 
	{
		sp.Close();
	}
}
