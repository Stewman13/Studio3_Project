using UnityEngine;
using System.Collections;

public class ClickGrab : MonoBehaviour {

	public GameObject Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Player.SendMessage ("grab");
	}
}
