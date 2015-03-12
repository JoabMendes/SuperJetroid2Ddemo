using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	//These speed variable will be the change that will happen in x and y 
	//for each frame when the position of the player change
	public float speed = 10f; //current speed of player
	public Vector2 maxVelocity = new Vector2(3 , 5); //Maximum velocity that the player can reach

	public bool standing; //Verify if the player is flying
	public float jetSpeed = 15f; //Velocity with jetpack of Y 

	//When the player is flying, the speed for x must be slower that when he is walking
	public float airSpeedMultiplier = .3f;

	//Class that reconizes the basic movements from the keyboard
	private PlayerController controller;

	private Animator animator;

	void Start () {
		controller = GetComponent<PlayerController>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//Forces that act over x and y of the player;
		//Any change of this value will act as a force pushing o pulling it to the a direction
		var forceX = 0f; 
		var forceY = 0f; 
		/*
			Since the rigid body velocity x can actually be a positive number if
			the player is moving to the right or a negative number is the player
			is moving to left we're going to use the absolute value which will
			just return the number itself. In order to do this let's set up a
			new variable here called ABS velocity X and we're going to use the
			math F library and it's ABS method to get the rigid bodies 2D velocity X value.
		*/
		var absVelX = Mathf.Abs(rigidbody2D.velocity.x);
		//If the player is flying we have to check the y position
		var absVelY = Mathf.Abs(rigidbody2D.velocity.y);

		//If velocity y if greater that .2f change the standing flags
		if (absVelY < .2f) {
			standing = true; //standing
		} else {
			standing = false; //flying
		}

		/*
		if (Input.GetKey ("right")) { //Verify if the button right in pressed
			if(absVelX < maxVelocity.x){
				if(standing){
					forceX = speed;
				}else{
					forceX = speed * airSpeedMultiplier;
				}
				 //
			}
			//transform's local scale, to allow us to flip the player from left to right
			transform.localScale = new Vector3(1,1,1);

		}else if(Input.GetKey("left")){ //Verify if the button left in pressed
			if(absVelX < maxVelocity.x){
				if(standing){
					forceX = -speed; //A negative value will act over x
				}else{
					forceX = -speed * airSpeedMultiplier;
				}

			}
			//transform's local scale, to allow us to flip the player from left to right
			transform.localScale = new Vector3(-1, 1, 1); //X being negative will turn the sprite to left
			//Like a mirror effect horizontally
		}*/

		//If x is not 0 the player is moving in favor of x
		if (controller.moving.x != 0) {
			if (absVelX < maxVelocity.x) {
					forceX = standing ? (speed * controller.moving.x) : (speed * controller.moving.x * airSpeedMultiplier);
					transform.localScale = new Vector3 ((forceX > 0 ? 1 : -1), 1, 1);
			}
			//Here I change the variable that changes the animation for the x movement
			animator.SetInteger ("AnimState", 1);
		} else {
			//if the player isn't moving, set it for the idle animation with 0
			animator.SetInteger ("AnimState", 0);
		}


		//Verify if up is presed to update the y position (fly with jetpack)
		/*if (Input.GetKey ("up")) {
			if(absVelY < maxVelocity.y){
				forceY = jetSpeed;
			}
		}*/
		if (controller.moving.y > 0){
			if(absVelY < maxVelocity.y){
				forceY = jetSpeed;
			}
			//Set Jetpack animation
			animator.SetInteger ("AnimState", 2);
		}else if(absVelY > 0){ //The player will be falling
			animator.SetInteger ("AnimState", 3);
		}

		//rigidbody2D.fixedAngle = false; make it roll

		//Now we update the player with the forces that act over it
		//It's like update the player position
		rigidbody2D.AddForce (new Vector3 (forceX, forceY));
	}
}
