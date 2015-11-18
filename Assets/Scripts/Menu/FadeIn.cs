using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
	
	public Image black;
	public Color lerpedColor;
	public Color endColor;
	public bool fading = false;
	
	public AudioSource audio;
	
	public float currentTime = 0f;
	public float timeToMove = 2f;
	
	// Use this for initialization
	void Start () {
		lerpedColor = black.color;
		endColor = new Color(0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (currentTime < timeToMove) {
			currentTime += Time.deltaTime;
			black.color = Color32.Lerp (lerpedColor, endColor, currentTime / timeToMove);
		} else if (currentTime >= timeToMove) {
			Destroy(this.gameObject);
		}
	}
}
