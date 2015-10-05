using UnityEngine;
using System.Collections;

public class ModifyGravity : MonoBehaviour {

    public float gravity;
    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.up * -gravity);

        if (Input.GetButton("Fire1"))
        {
            gravity += 0.1f;
        }
        if (Input.GetButton("Fire2"))
        {
            gravity -= 0.1f;
        }
    }
}
