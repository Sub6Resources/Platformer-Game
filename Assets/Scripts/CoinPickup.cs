using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public int pointsToAdd;

	public GameObject coinParticle;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<PlayerMove> () == null)
			return;

		ScoreManager.AddPoints (pointsToAdd);
		Instantiate (coinParticle, gameObject.transform.position, gameObject.transform.rotation);
		Destroy (gameObject);
	}
}
