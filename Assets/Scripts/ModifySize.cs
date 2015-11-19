using UnityEngine;
using System.Collections;

public class ModifySize : MonoBehaviour {

	public GameObject sizer;
	public int i = 0;
	public float maxMultiplier = 5.0f;
	public float maxSize = 2.0f;
	public float minSize = 1.0f;
	public GameObject small;
	public bool toGrow = true;
	public bool startBottom = false;
	public bool startTop = false;
	public GameObject top;
	public GameObject bottom;
	public bool changeSize;
	public bool inFeild = false;
	public bool powerOn = false;
	public float dist;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

	void OnTriggerStay(Collider col){
		if (powerOn == true) {
			if (col.gameObject == sizer) {
				dist = Vector3.Distance (small.transform.position, transform.position);
				inFeild = true;
				if (startBottom == true && toGrow == true) {
					changeSize = true;
				}
				if (startTop == true && toGrow == false) {
					changeSize = true;
				}
				if (changeSize == true) {
					this.GetComponent<ModifyGravity> ().gravMultiplier = dist;
					transform.localScale = new Vector3 (dist / 2, dist / 2, dist / 2);
				
					if (transform.localScale.x < minSize) {
						transform.localScale = new Vector3 (minSize, minSize, minSize);
						this.GetComponent<ModifyGravity> ().gravMultiplier = 0;
						toGrow = true;
					}
					if (transform.localScale.x > maxSize) {
						transform.localScale = new Vector3 (maxSize, maxSize, maxSize);
						toGrow = false;
					}
					if (this.GetComponent<ModifyGravity> ().gravMultiplier > maxMultiplier) {
						this.GetComponent<ModifyGravity> ().gravMultiplier = maxMultiplier;
					}
				}
			} else {
				inFeild = false;
			}
		}
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject == top && inFeild == false) {
			changeSize = false;
			startTop = true;
			startBottom = false;
		}
		if (coll.gameObject == bottom && inFeild == false) {
			changeSize = false;
			startTop = false;
			startBottom = true;
		}
	}

	void on(){
		powerOn = true;
	}
}
