using UnityEngine;
using System.Collections;
using System.Collections.Generic; //List like array, but with more options
public class HelloWorld : MonoBehaviour {

	public List<string> list = new List<string>();
	public float speed = 2f;
	// Use this for initialization
	void Start () {
		string name = "Joabe Mendes";
		int age = 22;
		float speed = 3.4f;
		bool likesGames = true;

		if (likesGames) {
			string output = name + ", "+ age+ " likes games at "+ speed; 
			print (output);
		}

		var myarray = new string[2];
		myarray[0] = "Hello";
		myarray[1] = "World";

		var phrase = myarray [0] + " " + myarray [1];
		//Debug.Log(phrase);
		//print(name);

		list.Add(name);
		list.Add (phrase);
		list.Add("Hey");
	}
	
	// Update is called once per frame
	void Update () {
		//transform: propriety of the object that has this script
		//transform.position.z keel obj the same z position
		//Time.deltaTime diference of time between frames
		transform.Translate(new Vector3 (speed, 0, transform.position.z) * Time.deltaTime);
	}
}
