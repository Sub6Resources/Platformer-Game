using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxPlayerHealth;

	public static int playerHealth;

	//Text text;

	public Slider healthBar;

	private LevelManager levelManager;

	public bool isDead;

	private LifeManager lifeSystem;

	private TimeManager timeSystem;

	// Use this for initialization
	void Start () {
		//text = GetComponent<Text> ();
		healthBar = GetComponent<Slider>();

		healthBar.maxValue = maxPlayerHealth;

		PlayerPrefs.SetInt ("PlayerMaxHealth", maxPlayerHealth);

		//playerHealth = maxPlayerHealth;
		playerHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");

		levelManager = FindObjectOfType<LevelManager> ();

		lifeSystem = FindObjectOfType<LifeManager> ();

		timeSystem = FindObjectOfType<TimeManager> ();

		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0 && !isDead) {
			playerHealth = 0;
			levelManager.RespawnPlayer ();
			lifeSystem.TakeLife ();
			isDead = true;
			timeSystem.ResetTime ();
		}

		if (playerHealth > maxPlayerHealth)
			playerHealth = maxPlayerHealth;

		//text.text = "" + playerHealth;
		healthBar.value = playerHealth;

	}

	public static void HurtPlayer(int damageToGive) {
		playerHealth -= damageToGive;
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
	}

	public void FullHealth() {
		playerHealth = PlayerPrefs.GetInt ("PlayerMaxHealth");
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
	}

	public void KillPlayer() {
		playerHealth = 0;
	}
}
