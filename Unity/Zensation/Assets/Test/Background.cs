using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public GameObject Player;
	public GameObject newBackground;
	public Transform Spawn;

	public Sprite daySprite;
	public Sprite nightSprite;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float speed = 5f * Time.deltaTime;

		transform.position -= new Vector3(speed, 0f, 0f);

		if(Player.GetComponent<Player>().cycle == true)
			gameObject.GetComponent<SpriteRenderer> ().sprite = daySprite;
		
		if(Player.GetComponent<Player>().cycle == false)
			gameObject.GetComponent<SpriteRenderer> ().sprite = nightSprite;

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "SpawnEnd")
		{
			GameObject createBackground = Instantiate(newBackground, Spawn.position, Spawn.rotation) as GameObject;
			Destroy(this.gameObject);
		}
	}
}
