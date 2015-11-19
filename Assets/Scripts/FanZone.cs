using UnityEngine;
using System.Collections;

public class FanZone : MonoBehaviour {

	public GameObject player;
	public int windForce = 5;
	public bool windOn = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			player.GetComponent<Rigidbody>().AddForce(Vector3.right * -windForce);
			if(windOn == false){
				windForce = 1;
			}
			if(windOn == true){
				windForce = 5;
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
