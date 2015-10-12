using UnityEngine;
using System.Collections;

public class ToggleLight : MonoBehaviour {
    public bool lightOn = false;

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
            }
            if (lightOn == false)
            {
                GetComponent<Light>().enabled = false;
            }
        }
    }
}
