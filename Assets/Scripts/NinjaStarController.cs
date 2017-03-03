using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour {

	public float speed;

	public PlayerMove player;

	public GameObject enemyDeathEffect;

	public GameObject impactEffect;

	public int pointsForKill;

	public float rotationSpeed;

	public int damageToGive;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerMove> ();
		if (player.transform.localScale.x < 0) {
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

		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
		}
		if (other.tag == "Boss") {
			other.GetComponent<BossHealthManager> ().giveDamage (damageToGive);
		}

		Instantiate (impactEffect, transform.position, transform.rotation);
		Debug.Log ("Destroying Ninja Star");
		Destroy (gameObject);
	}
}
