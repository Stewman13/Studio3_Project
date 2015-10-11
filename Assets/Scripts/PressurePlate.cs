using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

    public float gravity;
    public GameObject plate;
    public Rigidbody rb;

    public float setGravity = 0.5f;

    // Use this for initialization
    void Start () {
        rb = plate.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(plate.transform.position, transform.position);

        if(dist < 1)
        {
            rb.AddForce(Vector3.up * gravity);
        }
        if (dist > 1)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
