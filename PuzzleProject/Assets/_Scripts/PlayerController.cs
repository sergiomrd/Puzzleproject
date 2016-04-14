using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {



	// Public variables (Can be modified from the Inspector)

	// Speed variable that modifies the base player speed
	public float speed = 0;
	public GameObject actionObject;

	//Private variables

	Vector2 movementVector;
	Rigidbody2D rb;
	BoxCollider2D actionCollider2D;

	void Start () {

		// Get the Rigidbody2D component from the player GameObject
		rb = gameObject.GetComponent<Rigidbody2D>();
		actionCollider2D = actionObject.GetComponent<BoxCollider2D>();

	}
	
	void Update()
	{
		PlayerMove();
	}
		
	private void PlayerMove()
	{
		// Creates a new Vector2 that in his X axis gets the Axis Horizontal, and in his Y axis gets the Axis Vertical when the arrow keys are pressed
		float horizontalMove = Input.GetAxisRaw("Horizontal");
		float verticalMove = Input.GetAxisRaw("Vertical");

		// If horizontalMove + verticalMove are greater than 0, then the player is moving
		bool isWalking = (Mathf.Abs(horizontalMove) + Mathf.Abs(verticalMove)) > 0;


		if(isWalking)
		{
			// If that fixes the movement to 4 way direction
			/*
			if(horizontalMove != 0)
			{
				verticalMove = 0;
			}

			else if(verticalMove != 0)
			{
				horizontalMove = 0;
			}
			*/

			movementVector = new Vector2 (horizontalMove,verticalMove);

			// Compares where is the player moving to know where is facing
			if(movementVector.x == 1f && movementVector.y == 0f)
			{

			}
			else if (movementVector.x == -1f && movementVector.y == 0f)
			{

			}
			else if (movementVector.x == 0f && movementVector.y == 1f)
			{
		
			}
			else if (movementVector.x == 0f && movementVector.y == -1f)
			{
				
			}
				

			// Creates a new Vector that multiplies the movementVector, the speed and the delta time
			Vector2 movement = movementVector * speed * Time.deltaTime;

			// With MovePosition, we move our player to the a new position by adding the player rigidbody position to our new movement vector
			rb.MovePosition(movement + rb.position);
		}
			

	}

	private void isFacing(string face)
	{
		switch(face.ToLower())
		{
		case "up":

			Debug.Log("Up");
			actionCollider2D.offset = new Vector2(0f,0.06f);
			actionCollider2D.size = new Vector2(0.07f, 0.22f);

			break;
		case "down":

			Debug.Log("Down");
			actionCollider2D.offset = new Vector2(0f,-0.06f);
			actionCollider2D.size = new Vector2(0.07f, 0.22f);

			break;
		case "left":

			Debug.Log("Left");
			actionCollider2D.offset = new Vector2(-0.06f,0f);
			actionCollider2D.size = new Vector2(0.22f, 0.07f);

			break;
		case "right":

			Debug.Log("Right");
			actionCollider2D.offset = new Vector2(0.06f,0f);
			actionCollider2D.size = new Vector2(0.22f, 0.07f);

			break;
		}
	}
}
