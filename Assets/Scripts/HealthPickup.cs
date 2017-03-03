using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public int healthToGive;

	public GameObject healthParticle;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<PlayerMove> () == null)
			return;

		HealthManager.HurtPlayer (-healthToGive);
		Instantiate (healthParticle, gameObject.transform.position, gameObject.transform.rotation);
		Destroy (gameObject);
	}
}
