using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	public GameObject bulletBoom;
	GameObject Player;
	float speed = 0.4f;

	public Sprite daySprite;
	public Sprite nightSprite;

	// Use this for initialization
	void Start () {

		Player = GameObject.FindWithTag("Player");
		Vector2 direction = Player.transform.position - transform.position;
		this.GetComponent<Rigidbody2D>().velocity = direction * speed;



	}
	
	// Update is called once per frame
	void Update () {

		
		if(Player.GetComponent<Player>().cycle == true)
			gameObject.GetComponent<SpriteRenderer> ().sprite = daySprite;
		
		if(Player.GetComponent<Player>().cycle == false)
			gameObject.GetComponent<SpriteRenderer> ().sprite = nightSprite;

		Destroy(gameObject,2);
			
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player")
		{
			Player playerScript = other.gameObject.GetComponent<Player>();
			playerScript.IncreaseLevel();

			Destroy(gameObject);
			
		}
	}

	void OnDestroy() {

		Rigidbody2D BulletBoom = Instantiate(bulletBoom, transform.position, Quaternion.identity) as Rigidbody2D;
	}
}
