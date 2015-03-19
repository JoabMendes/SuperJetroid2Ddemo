using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public const int IDLE = 0, OPENING = 1, OPEN = 2, CLOSING = 3;

	private int state = IDLE;
	private Animator animator;
	private float closeDelay = .5f;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnOpenStart(){
		state = OPENING;
	}

	void OnOpenEnd(){
		state = OPEN;
	}

	void OnCloseStart(){
		state = CLOSING;
	}
	
	void OnCloseEnd(){
		state = IDLE;
	}

	//These methods will cause to the player go and don't go throught the doors
	void DissableCollider2D(){
		collider2D.enabled = false;
	}

	void EnableCollider2D(){
		collider2D.enabled = true;
	}

	public void Open(){
		animator.SetInteger ("AnimState", 1);
	}

	//Close door with a delay (Open, after a while the door closes)
	public void Close(){
		StartCoroutine (CloseNow ()); //Will call a sleep method
	}

	private IEnumerator CloseNow(){
		yield return new WaitForSeconds (closeDelay);
		animator.SetInteger ("AnimState", 2);
	}
}
