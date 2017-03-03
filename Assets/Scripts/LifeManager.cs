using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {

	//public int startingLives;
	private int lifeCounter;

	private Text theText;

	public GameObject gameOverScreen;

	public PlayerMove player;

	public string mainMenu;

	public float waitAfterGameOver;

	// Use this for initialization
	void Start () {
		theText = GetComponent<Text> ();

		lifeCounter = PlayerPrefs.GetInt ("PlayerCurrentLives");

		player = FindObjectOfType<PlayerMove> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeCounter < 0) {
			gameOverScreen.SetActive (true);
			PlayerPrefs.SetInt ("CurrentScore", 0);
			player.gameObject.SetActive (false);
		}

		theText.text = "x " + lifeCounter;

		if (gameOverScreen.activeSelf) {
			waitAfterGameOver -= Time.deltaTime;
		}

		if (waitAfterGameOver < 0) {
			SceneManager.LoadScene (mainMenu);
		}
	}

	public void GiveLIfe() {
		lifeCounter++;
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	}

	public void TakeLife() {
		lifeCounter--;
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	}
}
