using UnityEngine;
using System.Collections;

public class AirRunner : Enemy {
	
	float fly = 4f;
	float speed = 8f;
	bool up = true;
	float upTime = 0f;

	public Sprite texOne;
	public Sprite texTwo;



	// Use this for initialization
	void Start () {
	
		int randomEnemy = Random.Range(1,3);
		
		
		if(randomEnemy == 1)
			gameObject.GetComponent<SpriteRenderer> ().sprite = texOne;
		
		if(randomEnemy == 2)
			gameObject.GetComponent<SpriteRenderer> ().sprite = texTwo;




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
