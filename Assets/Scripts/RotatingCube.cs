using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RotatingCube : MonoBehaviour {

	public int speed = 300;
	public GameObject PauseCanvas;
	public GameObject EndGameCanvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.right * Time.deltaTime * speed);
	}

	void OnTriggerEnter(Collider other) {
		Camera.main.GetComponent<Timescale>().Paused = true;
		Time.timeScale = 0.0F;
		PauseCanvas.SetActive(true);
		EndGameCanvas.SetActive(true);
	}
}
