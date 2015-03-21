using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {


	public BodyPart bodypart;
	private int totalParts = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Deadly") {
			OnExplode();
		}
	}

	void OnExplode(){
		Destroy(gameObject);
		var t = transform; //get current position of player
		for (int i = 0; i < totalParts; i++) {
			//close instances of body parts and throw them
			t.TransformPoint(0, -100, 0);
			//create a new instace of bodypart
			BodyPart clone = Instantiate(bodypart, t.position, Quaternion.identity) as BodyPart; 
			//trows around
			clone.rigidbody2D.AddForce(Vector3.right * Random.Range(-50, 50)); //trow on x (-50, 50)
			clone.rigidbody2D.AddForce(Vector3.up * Random.Range(100, 400)); //trow on y (100, 400)
		}
	
	}

}
