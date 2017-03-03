using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

	private PlayerMove player;

	private LevelLoader levelExit;

	private PauseMenu pauseMenu;

    public GameObject upButton;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerMove> ();

		levelExit = FindObjectOfType<LevelLoader> ();

		pauseMenu = FindObjectOfType<PauseMenu> ();

		#if UNITY_ANDROID || UNITY_IOS
		gameObject.SetActive(true);
		#else
		gameObject.SetActive(false);
		#endif
	}

    void Update()
    {
        if(player.onLadder)
        {
            upButton.SetActive(true);
        } else
        {
            upButton.SetActive(false);
        }
    }

	public void LeftArrow() {
		player.Move (-1);
	}
	public void RightArrow() {
		player.Move (1);
	}

	public void UnpressedArrow() {
		player.Move (0);
	}

	public void Sword() {
		player.Sword ();
	}

	public void ResetSword() {
		player.ResetSword ();
	}

	public void Star() {
		player.FireStar ();
	}

	public void Jump() {
		player.Jump ();

		if (levelExit.playerInZone)
			levelExit.LoadLevel ();
	}

	public void Pause() {
		pauseMenu.PauseUnpause ();
	}

    public void Up()
    {
        player.climbingUp = true;
    }

    public void stopUp()
    {
        player.climbingUp = false;
    }
}
