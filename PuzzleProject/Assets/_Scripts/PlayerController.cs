using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Public variables (Can be modified from the Inspector)

	//Speed variable that modifies the base player speed
	public float speed = 0;

	//Private variables

	Vector2 movementVector;
	Rigidbody2D rb;


	void Start () {

		// Get the Rigidbody2D component from the player GameObject
		rb = gameObject.GetComponent<Rigidbody2D>();

	}
	
	void Update()
	{
		PlayerMove();
	}
		
	private void PlayerMove()
	{
		// Creates a new Vector2 that in his X axis gets the Axis Horizontal, and in his Y axis gets the Axis Vertical when the arrow keys are pressed
		movementVector = new Vector2 (Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

		// Creates a new Vector that multiplies the movementVector, the speed and the delta time
		Vector2 movement = movementVector * speed * Time.deltaTime;

		// With MovePosition, we move our player to the a new position by adding the player rigidbody position to our new movement vector
		rb.MovePosition(movement + rb.position);
	}
}
