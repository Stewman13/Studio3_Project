using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BreathTimer : MonoBehaviour {
	public Text txtRef;
	public Image black;
	public Color lerpedColor;
	public Color endColor;
	public bool fading = false;

//	[System.Serializable]
//	public class TimedCard
//	{
//		public string str;
//		public float delay;
//	}

	public AudioSource audio;

	public float currentTime = 0f;
	public float timeToMove = 2f;

	// Use this for initialization
	void OnEnable () {
		Time.timeScale = 1;
		StartCoroutine(WaitAndPrint());
		lerpedColor = black.color;
		endColor = new Color(0, 0, 0, 254);
	//	audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if (currentTime <= timeToMove && fading) {
			currentTime += Time.deltaTime;
			black.color  = Color32.Lerp (lerpedColor, endColor, currentTime / timeToMove);
			audio.volume = Mathf.Lerp(0.21f, 0, currentTime / timeToMove);
		}
	}

//	IEnumerator WaitAndPrintShort() {
//		txtRef.text = "Ready";
//		yield return new WaitForSeconds(0.5f);
//		txtRef.text = "Stead";
//		yield return new WaitForSeconds(0.5f);
//		txtRef.text = "Go";
//		yield return new WaitForSeconds(0.5f);
//		Application.LoadLevel (Application.loadedLevel + 1);
//	}

	IEnumerator WaitAndPrint() {
		Debug.Log ("Is Running Coroutine");
		//txtRef = GetComponent<Text>();
		Debug.Log ("Is Running Coroutine2");
		yield return new WaitForSeconds(5.0f);
		Debug.Log ("Is Running Ready");
		txtRef.text = "Ready";
		yield return new WaitForSeconds(4.5f);
		Debug.Log ("Is Running 1");
		txtRef.text = "1";
		yield return new WaitForSeconds(11.5f);
		txtRef.text = "2";
		Debug.Log ("Is Running 2");
		yield return new WaitForSeconds(11.0f);
		txtRef.text = "3";
		Debug.Log ("Is Running 3");
		yield return new WaitForSeconds(11.0f);
		txtRef.text = "4";
		Debug.Log ("Is Running 4");
		yield return new WaitForSeconds(11.0f);
		txtRef.text = "5";
		Debug.Log ("Is Running 5");
		yield return new WaitForSeconds(11.0f);
		fading = true;
		yield return new WaitForSeconds(3.0f);
		AsyncOperation async = Application.LoadLevelAsync(Application.loadedLevel+1);
		yield return async;
		Debug.Log("Loading complete");
	}
}
