using UnityEngine;
using System.Collections;

public class ReturnToMenu : MonoBehaviour {

	public GameObject PauseCanvas;
	public GameObject EndGameCanvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {

			//open Pause
			Timescale.Paused = true;
			Time.timeScale = 0.0F;
			PauseCanvas.SetActive(true);
		}
	}

	void Unpause(){
		Time.timeScale = 1.0F;
		Timescale.Paused = false;
		PauseCanvas.SetActive(false);
		EndGameCanvas.SetActive(false);
	}

	void Quit(){
		Application.LoadLevel (0);
	}
}
