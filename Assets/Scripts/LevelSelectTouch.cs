using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectTouch : MonoBehaviour {

	public LevelSelectManager theLevelSelectManager;


	// Use this for initialization
	void Start () {
		theLevelSelectManager = FindObjectOfType<LevelSelectManager> ();

		#if UNITY_ANDROID || UNITY_IOS
		theLevelSelectManager.touchMode = true;
		gameObject.SetActive(true);
		#else
		theLevelSelectManager.touchMode = false;
		gameObject.SetActive(false);
		#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveLeft() {
		theLevelSelectManager.positionSelector -= 1;
		if (theLevelSelectManager.positionSelector < 0)
			theLevelSelectManager.positionSelector = 0;
	}

	public void MoveRight() {
		theLevelSelectManager.positionSelector += 1;
		if (theLevelSelectManager.positionSelector > theLevelSelectManager.levelTags.Length)
			theLevelSelectManager.positionSelector = theLevelSelectManager.levelTags.Length - 1;
	}

	public void LoadLevel() {
		theLevelSelectManager.LoadLevelIfUnlockedTouchMode ();
	}

}
