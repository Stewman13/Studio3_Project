using UnityEngine;
using System.Collections;

public class ModifySize : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown ("IncreaseSize") && transform.localScale.x < 2.0f) {
			transform.localScale += new Vector3 (0.25f, 0.25f, 0.25f);   
			this.GetComponent<ModifyGravity> ().gravMultiplier += 1.25f;
		}
        if (Input.GetButtonDown ("DecreaseSize") && transform.localScale.x > 1.0f) {
			transform.localScale -= new Vector3 (0.25f, 0.25f, 0.25f);
			this.GetComponent<ModifyGravity> ().gravMultiplier -= 1.25f;
		}
    }
}
