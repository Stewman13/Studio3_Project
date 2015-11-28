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
	public int messages = 0;
	public int messagesTwo = 0;

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
		Screen.orientation = ScreenOrientation.LandscapeLeft;
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
						gravDisplay.SendMessage ("gravDown");
					} else if (gravNorm == true) {
						gravNorm = !gravNorm;
						gravity = -setGravity;
						this.GetComponent<ModifyWind> ().flip = true;
						grav2.Play ();
						flipping = true;
						gravDisplay.SendMessage ("gravUp");
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
						gravDisplay.SendMessage ("gravOn");
					}
				} else if (gravityOn == true) {
					grav3.Play ();
					gravityOn = !gravityOn;
					gravDisplay.SendMessage ("gravOff");
				}
			}
		}

		//Tablet Controls
		if (TabletBuild == true) {
			//flips gravity when tablet is flipped
			if ((Input.deviceOrientation == DeviceOrientation.LandscapeRight)) {
//				if(Screen.orientation != ScreenOrientation.LandscapeRight){
//					Screen.orientation = ScreenOrientation.LandscapeRight;
//				}
					gravNorm = false;
					grav2.Play ();
				if(messagesTwo == 1){
					messagesTwo--;
					gravDisplay.SendMessage ("gravUp");
				}
			}

			if ((Input.deviceOrientation == DeviceOrientation.LandscapeLeft)) {
//				if(Screen.orientation != ScreenOrientation.LandscapeRight){
//					Screen.orientation = ScreenOrientation.LandscapeRight;
//				}
				gravNorm = true;
				grav2.Play ();
				if(messagesTwo == 0){
					messagesTwo++;
					gravDisplay.SendMessage ("gravDown");
				}
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
				if(messages == 0){
					Debug.Log("gravOn");
					gravDisplay.SendMessage ("gravOn");
					messages++;
				}
			}

			if (turnGravOn == false) {
				gravityOn = false;
				if(messages == 1){
					Debug.Log("gravOff");
					gravDisplay.SendMessage ("gravOff");
					messages--;
				}
			}
		}
	}
}
