using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float startingTime;
	private float countingTime;

	private Text theText;

	private PauseMenu thePauseMenu;

	private HealthManager theHealth;

	// Use this for initialization
	void Start () {

		countingTime = startingTime;

		theText = GetComponent<Text> ();

		thePauseMenu = FindObjectOfType<PauseMenu> ();

		theHealth = FindObjectOfType<HealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (thePauseMenu.isPaused) {
			return;
		}

		countingTime -= Time.deltaTime;

		if (countingTime <= 0) {
			theHealth.KillPlayer ();
		}

		theText.text = "" + Mathf.Round(countingTime);
	}

	public void ResetTime() {
		countingTime = startingTime;
	}
}
