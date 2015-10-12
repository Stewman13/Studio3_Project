using UnityEngine;
using System.Collections;

public class ModifyWind : MonoBehaviour {

    public float gravity;
    public Rigidbody rb;

    public AudioSource wind1;
    public AudioSource wind2;
    public AudioSource wind3;

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
            wind1.Play();
        }
        if (Input.GetButton("WindOff"))
        {
            gravity = 0.0f;
            wind3.Play();
        }
        if (Input.GetButton("WindLeft"))
        {
            gravity = -setWind;
            wind2.Play();
        }
    }
}
