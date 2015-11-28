using UnityEngine;
using System.Collections;

public class GravityDisplayCube : MonoBehaviour {
		
	public GameObject Player;
	public GameObject Display;
	public Vector3 cubePos;
	public Vector3 displayPos;

	public float speed = 1.0F;
	public float dist;
	public float gravity;
	public float setGravity = 2.0f;
	float currentOffset=0.0f;
	float targetOffset=0.0f;
	float angle=0.0f;

	public bool gravityIsOn = true;
	public bool gravityIsDown = true;
		
	// Use this for initialization
	void Start () {
		if (Player.GetComponent<ModifyGravity> ().TabletBuild == true) {
			gravityIsOn = false;
		}
	}
		
	// Update is called once per frame
	void Update () {
		angle += Time.deltaTime;
		cubePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		displayPos = new Vector3(Display.transform.position.x, Display.transform.position.y, Display.transform.position.z);
		if (gravityIsOn == true && gravityIsDown == true) {
			targetOffset = -0.3f;
		}
		if (gravityIsOn == true && gravityIsDown == false) {
			targetOffset = 0.3f;
		}
		if(gravityIsOn == false){
			targetOffset = 0.0f;
			displayPos+=new Vector3(Mathf.Cos(angle),Mathf.Sin(angle*3.1f),0.0f)*0.05f;
			transform.Rotate(Vector3.right * Random.Range(0,3));
			transform.Rotate(Vector3.up * Random.Range(0,3));
		}
		currentOffset = Mathf.MoveTowards (currentOffset, targetOffset, Time.deltaTime * speed);
		transform.position = displayPos+new Vector3(0.0f,currentOffset,0.0f);
	}

	void gravOn(){
		gravityIsOn = true;
	}
	void gravOff(){
		gravityIsOn = false;
	}
	void gravUpDown(){
		gravityIsDown = !gravityIsDown;
	}
}
