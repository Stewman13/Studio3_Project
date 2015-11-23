using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public int speed;
	public bool Open = false;
	public Vector3 myPos;
	public float maxMovDist;

	// Use this for initialization
	void Start () {
		myPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = myPos;
		if (Open == true && myPos.x <= maxMovDist) {
			myPos.x += 0.1f;
		}
	}
	
	void open(){
		Open = true;
	}
}
