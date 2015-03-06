using UnityEngine;
using System.Collections;

public class GroundUnite : Enemy {

	public GameObject bullet;
	Vector3 bulletRotation;
	bool fire;
	float CD;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float speed = 5f * Time.deltaTime;
		
		transform.position -= new Vector3(speed, 0f, 0f);
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Player")
		{

			if(fire){

				Rigidbody2D Bullet = Instantiate(bullet, transform.position, Quaternion.identity) as Rigidbody2D;
				CD = Time.time + 2f;
				fire = false;

			}

			if(CD < Time.time)
			{
				fire = true;
			}



			
		}
	}


}
