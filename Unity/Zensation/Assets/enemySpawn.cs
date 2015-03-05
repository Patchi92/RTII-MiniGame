using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {

	int enemyCount;

	//Enemy Units

	public GameObject Air;
	public GameObject Ground;

	// Use this for initialization
	void Start () {
		enemyCount = 4;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(enemyCount < 4)
		{
			Spawn();
		}



	}

	public void enemyLeft () {
		enemyCount--;
	}

	void Spawn () {

		enemyCount++;
		int randomEnemy = Random.Range(1,3);

		if(randomEnemy == 1)
		{
			Vector3 position = new Vector3(525f, Random.Range(-495f, -505f), 0f);
			GameObject AirEnemy = Instantiate(Air, position, Quaternion.identity) as GameObject;
		}

		if(randomEnemy == 2)
		{
			Vector3 position = new Vector3(525f, -508f, 0);
			GameObject GroundEnemy = Instantiate(Ground, position, Quaternion.identity) as GameObject;
		}
	}
}
