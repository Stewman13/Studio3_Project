using UnityEngine;
using System.Collections;

public class MySwpieTest : MonoBehaviour {
	
	public Vector2 startPos;
	public Vector2 endPos;
	public Vector3 currentPos;
	public float force;
	public float distance;
	public bool beingTouched = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		beingTouched = true;
		startPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
	}

	void OnMouseUp(){
		endPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
	}
}
