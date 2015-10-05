using UnityEngine;
using System.Collections;

public class ModifyColor : MonoBehaviour {

    public Color newColor;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("ChangeColor"))
        {
            newColor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 1);
            GetComponent<Renderer>().material.color = newColor;
        }
        
        //  GetComponent<Renderer>().material.color = Color(Random.Range(0.0, 1.0), Random.Range(0.0, 1.0), Random.Range(0.0, 1.0));
        // Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 1
    }
}
