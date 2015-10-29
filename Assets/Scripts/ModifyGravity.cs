using UnityEngine;
using System.Collections;

public class ModifyGravity : MonoBehaviour {

    public float gravity;
    public Rigidbody rb;
    public GameObject cameraMain;

    public float setGravity = 2.0f;
	public float gravMultiplier = 0.0f;

    public Transform from;
    public Transform to;

    public float currentTime = 0f;
    public float timeToMove = 0f;

    public bool gravityOn = true;
    public bool flipping = false;
	public bool gravNorm = true;

    public AudioSource grav1;
    public AudioSource grav2;
    public AudioSource grav3;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
	void Update()
	{
		if (gravityOn == true && gravNorm == true) {
			rb.AddForce (Vector3.up * (-gravity + -gravMultiplier));
		}
		if (gravityOn == true && gravNorm == false) {
			rb.AddForce (Vector3.up * (-gravity + gravMultiplier));
		}

		if (gravNorm == false && flipping == true) {
			if (currentTime <= timeToMove) {
				currentTime += Time.deltaTime;
				cameraMain.transform.rotation = Quaternion.Lerp (from.rotation, to.rotation, currentTime / timeToMove);
			} else {
				currentTime = 0f;
				flipping = false;
			}
		}
			
		if (gravNorm == true && flipping == true) {
			if (currentTime <= timeToMove) {
				currentTime += Time.deltaTime;
				cameraMain.transform.rotation = Quaternion.Lerp (new Quaternion (0, 0, 1, 0), new Quaternion (0, 0, 0, 1), currentTime / timeToMove);
			} else {
				currentTime = 0f;
				flipping = false;
			}
		}


		//flips gravity
		if (Input.GetButton ("GravityUp")) {
			if (flipping == false) {
				if (gravNorm == false) {
					gravNorm = !gravNorm;
					gravity = setGravity;
					this.GetComponent<ModifyWind> ().flip = false;
					grav2.Play ();
					gravityOn = true;
					flipping = true;
				}
				else if (gravNorm == true) {
					gravNorm = !gravNorm;
					gravity = -setGravity;
					this.GetComponent<ModifyWind> ().flip = true;
					grav2.Play ();
					gravityOn = true;
					flipping = true;
				}
			}
		}

		//adds grav down
		if (Input.GetButton ("GravityDown")) {
			if (flipping == false && gravityOn == false) {
				if (gravNorm == false) {
					gravity = -setGravity;
				}
				if (gravNorm == true) {
					gravity = setGravity;
				}
				grav1.Play ();
				gravityOn = true;
			}
		}

		//turns off gravity
		if (Input.GetButton ("GravityOff")) {
			grav3.Play ();
			gravityOn = false;
		}
	}
}
