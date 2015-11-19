using UnityEngine;
using System.Collections;

public class FanZone : MonoBehaviour {

	public GameObject player;
	public int windForce = 5;
	public bool windOn = false;

	public int max = -5;
	public int min = 5;

	public GameObject cube;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject == player) {
			player.GetComponent<Rigidbody>().AddForce(this.transform.up * -windForce);
			if(windOn == false){
				windForce = max;
			}
			if(windOn == true){
				windForce = min;
			}
		}
		if (other.gameObject.tag == "Cube") {
			cube = other.gameObject;
			cube.GetComponent<Rigidbody>().AddForce(this.transform.up * -windForce);
			if(windOn == false){
				windForce = max;
			}
			if(windOn == true){
				windForce = min;
			}
		}
	}

	void on(){
		windOn = true;
	}

	void off(){
		windOn = false;
	}
}
