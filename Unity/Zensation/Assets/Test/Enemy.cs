using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject Player;
	public GameObject Spawn;
	public Sprite daySprite;
	public Sprite nightSprite;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Player.GetComponent<Player>().cycle == true)
			gameObject.GetComponent<SpriteRenderer> ().sprite = daySprite;
		
		if(Player.GetComponent<Player>().cycle == false)
			gameObject.GetComponent<SpriteRenderer> ().sprite = nightSprite;
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player")
		{
			Player playerScript = other.gameObject.GetComponent<Player>();
			playerScript.IncreaseLevel();
		}

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
