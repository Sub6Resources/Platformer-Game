using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public bool playerInZone;

	public string levelToLoad;

	public string levelTag;

	// Use this for initialization
	void Start () {
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Vertical") > 0 && playerInZone) {
			LoadLevel ();
		}
	}

	public void LoadLevel() {
		PlayerPrefs.SetInt (levelTag, 1);
		SceneManager.LoadScene (levelToLoad);
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Entered TheZone");
		if (other.name == "Player") {
			playerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("Exited TheZone");
		if (other.name == "Player") {
			playerInZone = false;
		}
	}

}
