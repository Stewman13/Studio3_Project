using UnityEngine;
using System.Collections;

public class TrailRendererOnOff : MonoBehaviour {

    public TrailRenderer trailRend;
    public bool onoff;

	// Use this for initialization
	void Start () {
        trailRend = gameObject.GetComponent<TrailRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("LineRenderer"))
        {
            onoff = !onoff;
            if (onoff)
            {
                trailRend.enabled = true;
            }
            else
            {
                trailRend.enabled = false;
            }
        }
    }
}
