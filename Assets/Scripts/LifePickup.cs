using UnityEngine;
using System.Collections;

public class LifePickup : MonoBehaviour {

	private LifeManager lifeSystem;

	public GameObject pickupParticle;


	// Use this for initialization
	void Start () {
		lifeSystem = FindObjectOfType<LifeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			lifeSystem.GiveLIfe ();
			Instantiate (pickupParticle, gameObject.transform.position, gameObject.transform.rotation);
			Destroy (gameObject);
		}
	}
}
