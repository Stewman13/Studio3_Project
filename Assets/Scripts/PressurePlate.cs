using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

    public float gravity;
    public GameObject plate;
    public Rigidbody rb;
    public float dist;
    public bool active;

    public float setGravity = 0.5f;
    public int timesToPlay = 1;

    public AudioSource tick;
    public AudioSource tock;

    // Use this for initialization
    void Start () {
        rb = plate.GetComponent<Rigidbody>();
        active = false;
    }
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(plate.transform.position, transform.position);

        if(dist < 1)
        {
            rb.AddForce(Vector3.up * gravity);
        }

        if (dist > 1 && dist < 1.1)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (dist > 1.1)
        {
            rb.AddForce(Vector3.up * -gravity);
        }
        if (dist > 2)
        {
            rb.AddForce(Vector3.up * -gravity * 6);
        }

        if (dist < 0.35)
        {
            active = true;
            if(timesToPlay == 1)
            {
                tick.Play();
                timesToPlay = 0;
            }
        }
        else
        {
            active = false;
            if(timesToPlay == 0)
            {
                tock.Play();
                timesToPlay = 1;
            }
        }
    }
}
