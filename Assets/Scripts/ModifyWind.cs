using UnityEngine;
using System.Collections;

public class ModifyWind : MonoBehaviour {

    public float gravity;
    public Rigidbody rb;

    public AudioSource wind1;
    public AudioSource wind2;
    public AudioSource wind3;

    public float setWind = 0.5f;

	public bool flip = false;

	public float standardWindNum = 0.5f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
		if (flip == true) {
			setWind = -standardWindNum;
		} else {
			setWind = standardWindNum;
		}

		if (Timescale.Paused)
			return;

        if (Input.GetButton("WindRight"))
        {
            gravity = setWind;
			rb.AddForce(Vector3.right * gravity);
        }
        if (Input.GetButton("WindLeft"))
        {
            gravity = -setWind;
			rb.AddForce(Vector3.right * gravity);
        }
		if (Input.GetButtonDown("WindLeft"))
		{
			wind3.Play();
		}
		if (Input.GetButtonDown("WindRight"))
		{
			wind1.Play();
		}
		else
		{
			gravity = 0.0f;	
		}
    }
}
