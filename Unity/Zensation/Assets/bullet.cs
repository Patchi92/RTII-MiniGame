using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	
	GameObject Player;
	float speed;

	// Use this for initialization
	void Start () {

		Player = GameObject.FindWithTag("Player");
		Vector2 direction = Player.transform.position - transform.position;
		this.rigidbody2D.velocity = direction * 0.5f;

	}
	
	// Update is called once per frame
	void Update () {
	
			
	}
}
