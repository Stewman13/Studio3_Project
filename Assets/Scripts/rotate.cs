using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	public int speed = 30; 
	public GameObject windForce;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.right * Time.deltaTime * speed);
	}

	public void speedUp(){
		speed += 270;
		windForce.SendMessage ("on");
	}

	public void speedDown(){
		speed -= 270;
		windForce.SendMessage ("off");
	}
}
