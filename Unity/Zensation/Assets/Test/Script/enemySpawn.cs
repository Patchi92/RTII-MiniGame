using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {

	int enemyCount;

	//Enemy Units

	public GameObject Air;
	public GameObject Ground;
	public GameObject Gate;

	string lastEnemy;

	// Use this for initialization
	void Start () {
		enemyCount = 5;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(enemyCount < 5 )
		{
			Spawn();
		}



	}

	public void enemyLeft () {
		enemyCount--;
	}

	void Spawn () {

		bool spawnish = true;

		while(spawnish) {

			int randomEnemy = Random.Range(1,10);
			
			if(randomEnemy >= 1 && randomEnemy <= 5 && lastEnemy != "Air")
			{
				Vector3 position = new Vector3(525f, Random.Range(-495f, -505f), 0f);
				GameObject AirEnemy = Instantiate(Air, position, Quaternion.identity) as GameObject;
				lastEnemy = "Air";
				enemyCount++;
				spawnish = false;
			}
			
			
			if(randomEnemy >= 6 && randomEnemy <= 8 && lastEnemy != "Ground")
			{
				Vector3 position = new Vector3(525f, -508f, 0);
				GameObject GroundEnemy = Instantiate(Ground, position, Quaternion.identity) as GameObject;
				lastEnemy = "Ground";
				enemyCount++;
				spawnish = false;
			} 
			
			if(randomEnemy >= 9 && randomEnemy <= 10 && lastEnemy != "Gate")
			{
				Vector3 position = new Vector3(525f, -500.5f, -1);
				GameObject GateOfEvil = Instantiate(Gate, position, Quaternion.identity) as GameObject;
				lastEnemy = "Gate";
				enemyCount++;
				spawnish = false;
			} 

		}

		
	}


}
