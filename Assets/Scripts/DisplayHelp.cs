using UnityEngine;
using System.Collections;

public class DisplayHelp : MonoBehaviour {

	public float timer;
	public bool cubeSpawned;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (cubeSpawned == true) {
			timer += Time.deltaTime;
		}
	}
}
