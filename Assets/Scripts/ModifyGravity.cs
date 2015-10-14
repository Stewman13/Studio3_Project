using UnityEngine;
using System.Collections;

public class ModifyGravity : MonoBehaviour {

    public float gravity;
    public Rigidbody rb;
    public GameObject cameraMain;

    public float setGravity = 2.0f;

    public Transform from;
    public Transform to;

    public float currentTime = 0f;
    public float timeToMove = 0f;

    public bool gravityOn = true;
    public bool flipping = false;
    public bool noGrav = false;

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
        rb.AddForce(Vector3.up * -gravity);

        if (gravityOn == false && flipping == true)
        {
            if (currentTime <= timeToMove)
            {
                currentTime += Time.deltaTime;
                cameraMain.transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, currentTime / timeToMove);
            }
            else
            {
                currentTime = 0f;
                flipping = false;
            }
        }

        if (gravityOn == true && flipping == true)
        {
            if (currentTime <= timeToMove)
            {
                currentTime += Time.deltaTime;
                cameraMain.transform.rotation = Quaternion.Lerp(new Quaternion(0, 0, 1, 0), new Quaternion(0, 0, 0, 1), currentTime / timeToMove);
            }
            else
            {
                currentTime = 0f;
                flipping = false;
            }
        }

        if (Input.GetButton("GravityDown"))
        {
            if (flipping == false && gravityOn == false)
            {
                gravity = setGravity;
                grav1.Play();
                flipping = true;
                gravityOn = true;
            }
            if(noGrav == true && flipping == false && gravityOn == true)
            {
                gravity = setGravity;
            }
        }


        if (Input.GetButton("GravityOff"))
        {
            gravity = 0.0f;
            grav3.Play();
            noGrav = true;
        }

        if (Input.GetButton("GravityUp"))
        {
            if (flipping == false && gravityOn == true)
            {
                gravity = -setGravity;
                grav2.Play();
                gravityOn = false;
                flipping = true;
            }
            if (noGrav == true && flipping == false && gravityOn == false)
            {
                gravity = -setGravity;
            }
        }
    }
}
