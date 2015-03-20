using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	public bool ignoreTrigger; //This will make the player to be ignored by the door trigger to open/close

	public Door door;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Open door if player is colliding
	void OnTriggerEnter2D(Collider2D target){
		if (ignoreTrigger) { return; }
		if (target.gameObject.tag == "Player") {
			door.Open();
		}
	}

	void OnTriggerExit2D(Collider2D target){
		if (ignoreTrigger) { return; }
		if (target.gameObject.tag == "Player") {
			door.Close();
		}
	}

	//Closes or open the the door associated with the trigger
	public void Toggle(bool value){
		if (value) {
			door.Open();
		} else {
			door.Close();
		}
	}

}
