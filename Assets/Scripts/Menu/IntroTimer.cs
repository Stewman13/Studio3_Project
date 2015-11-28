using UnityEngine;
using System.Collections;

public class IntroTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(WaitAndPrint(3.0F));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
