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

    public GameObject LightBulb;
    public Light lightI;

	public bool hasTimer = false;
	public bool powerDown = false;
	public bool Powered = true;
    public bool spawner = false;
    public Transform spawnPoint;
    public GameObject cube;

	public string message;
	public string upMessage;
	public GameObject receiver;

	public bool continuous = false;
	public bool hasUpMessage = false;

    // Use this for initialization
    void Start () {
        rb = plate.GetComponent<Rigidbody>();
        active = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (Powered == false && powerDown == true) 
		{
			LightBulb.GetComponent<Renderer>().material.color = new Color32(0,0,0,60);
			lightI.color = Color.black;
			powerDown = false;
		}
		if (Powered == true && powerDown == false) 
		{
			LightBulb.GetComponent<Renderer>().material.color = new Color32(255,0,0,60);
			lightI.color = Color.red;
			powerDown = true;
		}
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

        if (dist < 0.35 && Powered == true)
        {
            active = true;
            if(timesToPlay == 1)
            {
                tick.Play();
				if(continuous == false){
                	timesToPlay = 0;
				}
                LightBulb.GetComponent<Renderer>().material.color = new Color32(0,255,0,60);
				if(hasTimer == true){
	                lightI.color = Color.green;
					if(receiver != null){
						receiver.SendMessage(message);
					}
	                if(spawner == true)
	                {
	                    Instantiate(cube, spawnPoint.position, spawnPoint.rotation);
	                }
				}
				else if(hasTimer == false){
					lightI.color = Color.green;
					if(receiver != null){
						receiver.SendMessage(message);
					}
					if(spawner == true)
					{
						Instantiate(cube, spawnPoint.position, spawnPoint.rotation);
					}
				}
            }
        }
        else
        {
            active = false;
            if(timesToPlay == 0)
            {
				if(receiver != null && hasUpMessage == true){
					receiver.SendMessage(upMessage);
				}
                tock.Play();
                timesToPlay = 1;
                LightBulb.GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 60);
                lightI.color = Color.red;
            }
        }
    }
}
