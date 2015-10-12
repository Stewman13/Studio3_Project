using UnityEngine;
using System.Collections;

public class ToggleLight : MonoBehaviour {
    public bool lightOn = false;
    public AudioSource click;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("LightOnOff"))
        {
            lightOn = !lightOn;

            if (lightOn == true)
            {
                GetComponent<Light>().enabled = true;
                click.Play();
            }
            if (lightOn == false)
            {
                GetComponent<Light>().enabled = false;
                click.Play();
            }
        }
    }
}
