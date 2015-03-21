using UnityEngine;
using System.Collections;

public class BodyPart : MonoBehaviour {
	//Will load sprites to make the fadeout
	private SpriteRenderer spriteRenderer;
	private Color start, end;
	private float t = 0.0f;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		start = spriteRenderer.color;
		end = new Color (start.r, start.g, start.g, 0.0f); //transparent
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		renderer.material.color = Color.Lerp (start, end, t / 2); //interpelae two values on a fraction of time
		if (renderer.material.color.a <= 0.0) { //if fadeout is done, delete the object
			Destroy(gameObject);		
		}
	}
}
