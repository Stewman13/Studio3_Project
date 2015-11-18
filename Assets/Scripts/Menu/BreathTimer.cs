using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BreathTimer : MonoBehaviour {
	private Text txtRef;
	public Image black;
	public Color lerpedColor;
	public Color endColor;
	public bool fading = false;

	public AudioSource audio;

	public float currentTime = 0f;
	public float timeToMove = 2f;

	// Use this for initialization
	void Start () {
		StartCoroutine(WaitAndPrint());
		lerpedColor = black.color;
		endColor = new Color(0, 0, 0, 254);
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if (currentTime <= timeToMove && fading) {
			currentTime += Time.deltaTime;
			black.color  = Color32.Lerp (lerpedColor, endColor, currentTime / timeToMove);
			audio.volume = Mathf.Lerp(0.21f, 0, currentTime / timeToMove);
		}
	}

	IEnumerator WaitAndPrint() {
		txtRef = GetComponent<Text>();
		yield return new WaitForSeconds(5.0f);
		txtRef.text = "Ready";
		yield return new WaitForSeconds(4.5f);
		txtRef.text = "1";
		yield return new WaitForSeconds(11.5f);
		txtRef.text = "2";
		yield return new WaitForSeconds(11.0f);
		txtRef.text = "3";
		yield return new WaitForSeconds(11.0f);
		txtRef.text = "4";
		yield return new WaitForSeconds(11.0f);
		txtRef.text = "5";
		yield return new WaitForSeconds(11.0f);
		fading = true;
		yield return new WaitForSeconds(3.0f);
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
