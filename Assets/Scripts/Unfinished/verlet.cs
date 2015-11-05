using UnityEngine;
using System.Collections;

public class verlet : MonoBehaviour {
    public GameObject[] objects;
	public float restlength;
	public int iterations;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int j=0; j<iterations; ++j) {
			for (int i = 0; i < objects.Length-1; ++i) {
				Vector3 delta = objects [i + 1].transform.position - objects [i].transform.position;
				float deltalength = delta.magnitude;
				float diff = (deltalength - restlength) / deltalength;
				objects [i].transform.position = objects [i].transform.position + delta * 0.5f * diff;
				objects [i + 1].transform.position = objects [i + 1].transform.position - delta * 0.5f * diff;
			}
		}

	}
}
