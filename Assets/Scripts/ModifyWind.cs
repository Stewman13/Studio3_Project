using UnityEngine;
using System.Collections;

public class ModifyWind : MonoBehaviour {

    public float gravity;
    public Rigidbody rb;

    public float setWind = 0.5f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(Vector3.right * gravity);

        if (Input.GetButton("WindRight"))
        {
            gravity = setWind;
        }
        if (Input.GetButton("WindOff"))
        {
            gravity = 0.0f;
        }
        if (Input.GetButton("WindLeft"))
        {
            gravity = -setWind;
        }
    }
}
