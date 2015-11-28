using UnityEngine;
using System.Collections;

public class ModifyGravity : MonoBehaviour {

    public float gravity;
    public Rigidbody rb;
    public GameObject cameraMain;
	public GameObject gravDisplay;

    public float setGravity = 2.0f;
	public float gravMultiplier = 0.0f;

    public Transform from;
    public Transform to;

    public float currentTime = 0f;
    public float timeToMove = 0f;

	public bool turnGravOn = false;
    public bool gravityOn = true;
    public bool flipping = false;
	public bool gravNorm = true;

    public AudioSource grav1;
    public AudioSource grav2;
    public AudioSource grav3;

	public bool TabletBuild = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

		if (TabletBuild) {
			gravityOn = false;
			setGravity = 4.0f;
			rb.angularDrag = 1;
			rb.drag = 1;
		}
    }

    // Update is called once per frame
	void Update()
	{
		if (Timescale.Paused)
			return;

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

		//PC Controls
		if (TabletBuild == false) {
			//flips gravity
			if (Input.GetButton ("GravityUp")) {
				if (flipping == false) {
					if (gravNorm == false) {
						gravNorm = !gravNorm;
						gravity = setGravity;
						this.GetComponent<ModifyWind> ().flip = false;
						grav2.Play ();
						flipping = true;
						gravDisplay.SendMessage ("gravUpDown");
					} else if (gravNorm == true) {
						gravNorm = !gravNorm;
						gravity = -setGravity;
						this.GetComponent<ModifyWind> ().flip = true;
						grav2.Play ();
						flipping = true;
						gravDisplay.SendMessage ("gravUpDown");
					}
				}
			}

			//adds grav down
			if (Input.GetButtonDown ("GravityDown")) {
				if (gravityOn == false) {
					if (flipping == false && gravityOn == false) {
						if (gravNorm == false) {
							gravity = -setGravity;
						}
						if (gravNorm == true) {
							gravity = setGravity;
						}
						grav1.Play ();
						gravityOn = !gravityOn;
						gravDisplay.SendMessage ("gravOnOff");
					}
				} else if (gravityOn == true) {
					grav3.Play ();
					gravityOn = !gravityOn;
					gravDisplay.SendMessage ("gravOnOff");
				}
			}
		}

		//Tablet Controls
		if (TabletBuild == true) {
			//flips gravity when tablet is flipped
			if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft) {
					gravity = setGravity;
					grav2.Play ();
					gravDisplay.SendMessage ("gravUpDown");
			}

			if (Input.deviceOrientation == DeviceOrientation.LandscapeRight) {
					gravity = -setGravity;
					grav2.Play ();
					gravDisplay.SendMessage ("gravUpDown");
			}
			
			//adds grav down when button/finger held down
			if (turnGravOn == true) {
				if (gravNorm == false) {
					gravity = -setGravity;
				}
				if (gravNorm == true) {
					gravity = setGravity;
				}
				grav1.Play ();
				gravityOn = true;
				gravDisplay.SendMessage ("gravOn");
			}

			if (turnGravOn == false) {
				gravityOn = false;
				gravDisplay.SendMessage ("gravOff");
			}
		}
	}
}
