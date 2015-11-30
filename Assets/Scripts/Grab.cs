using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {

    public GameObject cube;
    public float dist;
    public bool grabbed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		cube = GameObject.FindGameObjectWithTag ("Cube");

		if (cube != null) {
			dist = Vector3.Distance (cube.transform.position, transform.position);

			//for PC
			if (Input.GetButtonDown ("Grab")) {

				if (dist < 1.5 && grabbed == false) {
					grabbed = true;
					cube.transform.parent = this.transform;
//                    cube.GetComponent<Rigidbody>().isKinematic = true;
					gameObject.AddComponent<FixedJoint> ();
					gameObject.GetComponent<FixedJoint> ().connectedBody = cube.GetComponent<Rigidbody> ();
					cube.GetComponent<FalseGravity> ().gravity = 0;
				} else {
					cube.transform.parent = null;   
					if (grabbed == true) {
						// cube.GetComponent<Rigidbody>().isKinematic = false;
						Destroy (gameObject.GetComponent<FixedJoint> ());
						cube.GetComponent<FalseGravity> ().gravity = cube.GetComponent<FalseGravity> ().setGrav;
					}
					grabbed = false;
				}
			}
		}
	}
			//for tablet
	public void grab(){
		if(dist < 1.5 && grabbed == false)
		{
			grabbed = true;
			cube.transform.parent = this.transform;
			//                    cube.GetComponent<Rigidbody>().isKinematic = true;
			gameObject.AddComponent<FixedJoint>();
			gameObject.GetComponent<FixedJoint>().connectedBody = cube.GetComponent<Rigidbody>();
			cube.GetComponent<FalseGravity>().gravity = 0;
		}
		else
		{
			cube.transform.parent = null;   
			if(grabbed == true)
			{
				// cube.GetComponent<Rigidbody>().isKinematic = false;
				Destroy (gameObject.GetComponent<FixedJoint>());
				cube.GetComponent<FalseGravity>().gravity = cube.GetComponent<FalseGravity>().setGrav;
			}
			grabbed = false;
	
		}
	}
}
