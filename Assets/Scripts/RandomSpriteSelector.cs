using UnityEngine;
using System.Collections;

public class RandomSpriteSelector : MonoBehaviour {

	public Sprite[] sprites;
	public string resourceName;
	public int currentSprite = -1;

	//This script can be integrated to the collectable.cs directly
	// Use this for initialization
	void Start () {
		//This code will allow we chose the sprite manually or randomically if it set -1
		//Also controls the currentSprite value
		if (!resourceName.Equals("")) {

			sprites = Resources.LoadAll<Sprite>(resourceName);
			if(currentSprite == -1 || currentSprite > sprites.Length){
				currentSprite = Random.Range(0, sprites.Length);
			}

			GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
