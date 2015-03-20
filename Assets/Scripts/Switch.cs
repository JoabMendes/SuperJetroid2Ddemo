using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	//All doors connected to this switch goes here
	//Doors are added on the panel
	public DoorTrigger[] doorTriggers; 
	private Animator animator;
	private bool down;
	public bool sticky; //Controls if the switch will be sticky or not

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		animator.SetInteger("AnimState", 1);
		down = true; //The switch is down;

		//For each door connected to this switch it will be open
		foreach(DoorTrigger trigger in doorTriggers){
			if(trigger != null){
				trigger.Toggle(true); //Open the the door associated with the trigger
			}
		}
	}

	void OnTriggerExit2D(Collider2D target){
		if (sticky && down) {
			return; //if the switch is down and sticky, it will no come up again.
		}

		animator.SetInteger("AnimState", 2);
		down = false; //The switch is up.
		//For each door connected to this switch it will be closed
		foreach(DoorTrigger trigger in doorTriggers){
			if(trigger != null){
				trigger.Toggle(false); //Closes the door associated with the trigger
			}
		}
	}

}
