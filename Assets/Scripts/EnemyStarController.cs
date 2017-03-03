using UnityEngine;
using System.Collections;

public class EnemyStarController : MonoBehaviour {

	public float speed;

	public PlayerMove player;

	//public GameObject enemyDeathEffect;

	public GameObject impactEffect;

	//public int pointsForKill;

	public float rotationSpeed;

	public int damageToGive;

	private Rigidbody2D myrigidbody2D;

	// Use this for initialization
	void Start () {
		myrigidbody2D = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<PlayerMove> ();
		if (player.transform.position.x < transform.position.x) {
			rotationSpeed = -rotationSpeed;
			speed = -speed;
		}
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);

		GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.name == "Player") {
			HealthManager.HurtPlayer (damageToGive);
		}

		Instantiate (impactEffect, transform.position, transform.rotation);
		Debug.Log ("Destroying Ninja Star");
		Destroy (gameObject);
	}
}
