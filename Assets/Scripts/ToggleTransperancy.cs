using UnityEngine;
using System.Collections;

public class ToggleTransperancy : MonoBehaviour {

    public bool onoff;
    public Color color;

    // Use this for initialization
    void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
        color = GetComponent<Renderer>().material.color;

        if (Input.GetButtonDown("GoClear"))
        {
            onoff = !onoff;
            if (onoff == true)
            {
                GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0);
            }
            else
            {
                GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 1);
                
            }
        }
    }
}
