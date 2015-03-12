using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//When this @gameObject collides with another 2d body, call this method
	void OnTriggerEnter2D(Collider2D target){ 
		if (target.gameObject.tag == "Player") {
			Destroy(gameObject); //This game object it's the 
		}
	}


}
