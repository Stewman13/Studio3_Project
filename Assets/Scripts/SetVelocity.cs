using UnityEngine;
using System.Collections;

public class SetVelocity : MonoBehaviour {

	public float maxVel;
	public Rigidbody rb;
	public Vector3 rbV;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rbV = rb.velocity;
		rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVel);
	}
}
