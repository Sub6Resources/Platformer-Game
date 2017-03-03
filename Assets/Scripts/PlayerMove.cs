using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public float moveSpeed = 5.0f;
	public float jumpForce = 6.5f;
	public float gravity = 20.0f;
	private bool doubleJumping = false;
	public bool jumping = false;
	private float moveVelocity;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;

	private Animator anim;

	public Transform firePoint;
	public GameObject ninjaStar;

	public float shotDelay;
	private float shotDelayCounter;

	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;

	public Rigidbody2D myrigidbody2D;

	public bool onLadder;
    public bool climbingUp;
    public bool climbingDown;
	public float climbSpeed;
	private float climbVelocity;

	private float gravityStore;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		myrigidbody2D = GetComponent<Rigidbody2D> ();

		gravityStore = myrigidbody2D.gravityScale;
		}

	void FixedUpdate() {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {

		if (grounded) {
			doubleJumped = false;

		}
		anim.SetBool ("Grounded", grounded);

		#if UNITY_STANDALONE || UNITY_WEBPLAYER
		if(Input.GetButtonDown("Jump")) {
			//jump
			Jump ();
			//GetComponent<Rigidbody2D> ().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x,jumpForce);   
		}



		//set movevelocity to input.
		//moveVelocity = moveSpeed * Input.GetAxisRaw ("Horizontal");
		Move(Input.GetAxisRaw("Horizontal"));

		#endif

		if (knockbackCount <= 0) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			Debug.Log ("Knocking back, "+knockFromRight+"; Velocity is "+knockback);
			if (knockFromRight)
				myrigidbody2D.velocity = new Vector2 (-knockback, knockback/5);
			if (!knockFromRight)
				myrigidbody2D.velocity = new Vector2 (knockback, knockback/5);
			knockbackCount -= Time.deltaTime;

		}

		anim.SetFloat ("Speed", Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x));

		if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} else if (GetComponent<Rigidbody2D> ().velocity.x < 0) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}

		#if UNITY_STANDALONE || UNITY_WEBPLAYER

		if (Input.GetButtonDown("Fire1")) {
			FireStar ();
			shotDelayCounter = shotDelay;
		}

		if(Input.GetButton("Fire1")) {
			shotDelayCounter -= Time.deltaTime;

			if (shotDelayCounter <= 0) {
				shotDelayCounter = shotDelay;
				FireStar ();
			}
		}
		if (anim.GetBool("sword")) {
			//anim.SetBool("sword", false);
			ResetSword();
		}
		if (Input.GetButtonDown("Fire2")) {
			//anim.SetBool ("sword", true);
			Sword();
		}

		#endif

		if (onLadder) {
			myrigidbody2D.gravityScale = 0f;

            #if UNITY_STANDALONE || UNITY_WEBPLAYER
            climbVelocity = climbSpeed * Input.GetAxisRaw ("Vertical");
            #else
            if(climbingUp) {
                climbVelocity = climbSpeed;
            } else if(climbingDown) {
                climbVelocity = -climbSpeed;
            } else {
                climbVelocity = 0;
            }
            #endif

            myrigidbody2D.velocity = new Vector2 (myrigidbody2D.velocity.x, climbVelocity);
		}

		if (!onLadder) {
			myrigidbody2D.gravityScale = gravityStore;
		}



	}

	public void Move(float moveInput) {
		moveVelocity = moveSpeed * moveInput;
	}

	public void FireStar() {
		Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
	}

	public void Sword() {
		anim.SetBool ("sword", true);
	}

	public void ResetSword() {
		anim.SetBool("sword", false);
	}

	public void Jump() {
		

		if(grounded) {
			//jump
			GetComponent<Rigidbody2D> ().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x,jumpForce);
			//GetComponent<Rigidbody2D> ().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x,jumpForce);   
		}
		else if (!doubleJumped && !grounded) {
			doubleJumped = true;
			GetComponent<Rigidbody2D> ().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x,jumpForce);
			//GetComponent<Rigidbody2D> ().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x,jumpForce); 
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log ("Entered moving platform.");
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		Debug.Log ("Entered moving platform.");
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}

}
