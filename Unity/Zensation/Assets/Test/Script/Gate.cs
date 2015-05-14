using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	

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
}
