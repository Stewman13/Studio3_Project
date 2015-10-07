using UnityEngine;
using System.Collections;

public class ModifyGravity : MonoBehaviour {

    public float gravity;
    public Rigidbody rb;

    public float setGravity = 2.0f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.up * -gravity);

        if (Input.GetButton("GravityDown"))
        {
            gravity = setGravity;
        }
        if (Input.GetButton("GravityOff"))
        {
            gravity = 0.0f;
        }
        if (Input.GetButton("GravityUp"))
        {
            gravity = -setGravity;
        }
    }
}
