using UnityEngine;
using System.Collections;

public class ModifySize : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("IncreaseSize") && transform.localScale.x <= 5.0f)
            transform.localScale += new Vector3(0.01F, 0.01f, 0.01f);     
        if (Input.GetButton("DecreaseSize") && transform.localScale.x >= 1.0f)
            transform.localScale -= new Vector3(0.01F, 0.01f, 0.01f);
    }
}
