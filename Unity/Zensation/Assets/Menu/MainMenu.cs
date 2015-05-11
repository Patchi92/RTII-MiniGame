using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class MainMenu : MonoBehaviour {

	SerialPort sp = new SerialPort("COM4", 9600);

	void Start () {
		
		OpenArduino();
		Cursor.visible = true;
	
	}


	void Update () {

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

	}

	public void ChangeToScene (string nameOfScene) {
		Application.LoadLevel(nameOfScene);
	}
	public void Exit () {
		Application.Quit();
	}


	void Arduino(int ArduInput)
	{
		if(ArduInput == 1)
		{
			Debug.Log("Test");
			Application.LoadLevel("Test");
		}

		
		if(ArduInput == 2)
		{
			Application.Quit();
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