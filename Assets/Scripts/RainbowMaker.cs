using UnityEngine;
using System.Collections;

public class RainbowMaker : MonoBehaviour {

	public bool isLight = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isLight == false) {
			GetComponent<Renderer> ().material.color = new Color32 ((byte)Random.Range (0, 255), (byte)Random.Range (0, 255), (byte)Random.Range (0, 255), 200);
		}
		if (isLight == true) {
			GetComponent<Light> ().color = new Color32 ((byte)Random.Range (0, 255), (byte)Random.Range (0, 255), (byte)Random.Range (0, 255), 200);
		}
	}
}
