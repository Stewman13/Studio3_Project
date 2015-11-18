using UnityEngine;
using System.Collections;

public class FalseGravity : MonoBehaviour {

    public float gravity;
	public float setGrav;
    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
		setGrav = gravity;
    }
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(Vector3.up * -gravity);
    }
}
