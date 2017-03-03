using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	} 

	public string startLevel;

	public string levelSelect;

	public int playerLives;

	public int playerHealth;

	public string[] levelTags;

	public void NewGame() {
		

		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);

		PlayerPrefs.SetInt ("CurrentScore", 0);

		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);

		for (int i = 0; i < levelTags.Length; i++) {
			PlayerPrefs.SetInt (levelTags [i], 0);
		}
		PlayerPrefs.SetInt (levelTags[0], 1);
		PlayerPrefs.SetInt ("PlayerLevelSelectPosition", 0);
		SceneManager.LoadScene (startLevel);
	}

	public void LevelSelect() {
		if (PlayerPrefs.GetInt ("PlayerCurrentLives") < 0) {
			PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
			PlayerPrefs.SetInt ("PlayerLevelSelectPosition", 0);
			for (int i = 0; i < levelTags.Length; i++) {
				PlayerPrefs.SetInt (levelTags [i], 0);
			}
			PlayerPrefs.SetInt (levelTags[0], 1);
		} else {
			//do nothing to the value. User is continuing a saved game.
		}

		if (!PlayerPrefs.HasKey ("PlayerLevelSelectPosition")) {
			for (int i = 0; i < levelTags.Length; i++) {
				PlayerPrefs.SetInt (levelTags [i], 0);
			}
			PlayerPrefs.SetInt (levelTags[0], 1);
			PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
			PlayerPrefs.SetInt ("PlayerLevelSelectPosition", 0);
		}
		//PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		//PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);
		SceneManager.LoadScene (levelSelect);
	}

	public void QuitGame() {
		Debug.Log ("Game Exited");
		Application.Quit ();
	}
}
