using UnityEngine;
using System.Collections;

public class AirRunner : Enemy {
	
	float fly = 4f;
	float speed = 8f;
	bool up = true;
	float upTime = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
		if(up)
		{
			fly = 4f;
			++upTime;

			if(upTime == 20f)
			{
				up = false;
			}
		}

		if(!up)
		{
			fly = -4f;
			--upTime;
			
			if(upTime == -20f)
			{
				up = true;
			}
		}



		transform.position -= new Vector3(speed, fly, 0f) * Time.deltaTime;
	}


}
