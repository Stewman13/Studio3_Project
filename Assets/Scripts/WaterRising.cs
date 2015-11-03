using UnityEngine;
using System.Collections;

public class WaterRising : MonoBehaviour {

	public Vector3 myPos;
	public bool isFilling = false;
	public bool powerOn = false;

	public GameObject electricTrigger;

	public GameObject poweredObject;

	// Use this for initialization
	void Start () {
		myPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	this.transform.position = myPos;
	if (isFilling == true && myPos.y < 8.7f) {
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
		if (Col.gameObject.tag == "electricTrigger" && myPos.y > 8.665f) {
			powerOn = true;
			poweredObject.GetComponent<PressurePlate>().Powered = true;
		}
		else if(Col == null){
			powerOn = false;
			poweredObject.GetComponent<PressurePlate>().Powered = false;
		}
	}
}
