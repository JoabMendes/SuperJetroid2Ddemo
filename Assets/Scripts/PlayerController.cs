using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//This class was created to simplify the player motion of x and y
	// Use this for initialization
	public Vector2 moving = new Vector2();


	//This class only indentifies the keyboard input and change the variables in moving
	//moving has the flags to change the speed and the animation on the main class (Player)
	//
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//Each new update, clear x and y
		moving.x = moving.y = 0;

		if (Input.GetKey ("right")) {
			moving.x = 1;
		}else if(Input.GetKey("left")){
			moving.x = -1;
		}

		if (Input.GetKey ("up")) {
			moving.y = 1;
		}else if(Input.GetKey("down")){
			moving.y = -1;
		}
	}
}
