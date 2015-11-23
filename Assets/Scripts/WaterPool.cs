using UnityEngine;
using System.Collections;

public class WaterPool : MonoBehaviour {
	
	public Vector3 myPos;
	public GameObject gravCenter;

	//this is the maximum hight at which the water will rise
	public float maxFill;

	public bool isFilling = false;
	public bool powerOn = false;
	
	public GameObject electricTrigger;
	
	public GameObject poweredObject;

	public float totalForce;
	
	// Use this for initialization
	void Start () {
		myPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = myPos;
		if (isFilling == true && myPos.y < maxFill) {
			myPos.y += 0.0001f;
		}


	}
	
	public void On(){
		isFilling = true;
	}
	
	public void Off(){
		isFilling = false;
	}

	void OnTriggerStay(Collider Col) {
		if (Col.gameObject.tag == "Player" || Col.gameObject.tag == "Cube") {
			totalForce =  Vector3.Distance(Col.transform.position, gravCenter.transform.position);
			Col.GetComponent<Rigidbody>().AddForce(transform.up * (totalForce * 2));
		}
	}
}
