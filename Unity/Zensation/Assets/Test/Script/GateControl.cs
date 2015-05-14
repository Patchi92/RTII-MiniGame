using UnityEngine;
using System.Collections;

public class GateControl : MonoBehaviour {

	GameObject Player;
	GameObject Spawn;
	public GameObject day;
	public GameObject night;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		float speed = 5f * Time.deltaTime;
		transform.position -= new Vector3(speed, 0f, 0f);

		Player = GameObject.FindWithTag("Player");

		
		if(Player.GetComponent<Player>().cycle == true) {
			night.SetActive(false);
			day.SetActive(true);

		}
		
		if(Player.GetComponent<Player>().cycle == false) {
			night.SetActive(true);
			day.SetActive(false);

		}
		
	}

	void OnTriggerEnter2D(Collider2D other) {

		
		if (other.gameObject.tag == "SpawnEnd")
		{
			Destroy(this.gameObject);
		}
	}


	void OnDestroy() {
		Spawn = GameObject.FindWithTag("Spawn");
		Spawn.GetComponent<enemySpawn>().enemyLeft();
	}

}
