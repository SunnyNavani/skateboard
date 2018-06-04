using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour {

//	bool move = false;
	public Rigidbody2D rb;
	public float speed =20f, jumpVelocity=10f,rotationSpeed=2f; 
	float hinput=0;
	public bool isGrounded=false;
	private float turnDirection = 0.0f; 
	Transform tagGround , myTrans;
	public LayerMask playerMask;

	public Button mybutton;
	void Start()
	{	rb = GetComponent<Rigidbody2D> ();
		myTrans = this.transform;
		tagGround = GameObject.Find (this.name + "/grounded").transform;
	}


	// Update is called once per frame
//	public void Update () {
//		if (Input.GetButtonDown ()) {
//			move = true;
//		}
//		if (Input.GetButtonDown ()) {
//			move = false;
//		}
		
//	}
	void Update()
	{
		//mybutton.onClick.AddListener (Flip);
		if (!isGrounded ) {
			Debug.Log ("rotateeeee");
			//turnDirection = Input.GetAxis("Horizontal")*rotationSpeed;

			rb.AddTorque (-rotationSpeed * Time.fixedDeltaTime * 10f, ForceMode2D.Force);
		}
	}
	void FixedUpdate()
	{
//		if (move == true) {
//			rb.AddForce (transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
//		}

		isGrounded=Physics2D.Linecast(myTrans.position,tagGround.position,playerMask);

		Move (hinput);


			
			

	}
	void Flip()
	{
			if (isGrounded ) {
				Debug.Log ("rotateeeee");
				//turnDirection = Input.GetAxis("Horizontal")*rotationSpeed;
			transform.localScale+=new Vector3(-1,-1,-1);
				//rb.AddTorque (-rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
			}
	}
	void Move(float horizontalInput)
	{
		Vector2 moveVal = rb.velocity;
		moveVal.x = horizontalInput * speed;
		rb.velocity = moveVal;
	}
	public void startMoving(float horizontalInput)
	{
		hinput = horizontalInput;
		Debug.Log ("im here");

	}
	public void slowDownMoving(float horizontalInput)
	{// Debug.Log ("hinput" + hinput);
//		while (hinput >= 0) {
//			Debug.Log ("hinputs = " + hinput);
//			hinput = hinput - 1f;
//		}
////		hinput = 0;
//		if (hinput <= 0)
//		{
			hinput = 2.2f;
	//	rb.AddTorque (turnDirection * 0f * Time.fixedDeltaTime * 0f);
		//	Debug.Log ("slowdown");
		//}
	}

	public void jump()
	{
		if (isGrounded)
			rb.velocity += jumpVelocity * Vector2.up;
	}
}
