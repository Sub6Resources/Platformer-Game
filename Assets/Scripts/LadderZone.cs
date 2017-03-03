using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

	private PlayerMove thePlayer;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerMove> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			thePlayer.onLadder = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "Player") {
			thePlayer.onLadder = false;
		}
	}
}
