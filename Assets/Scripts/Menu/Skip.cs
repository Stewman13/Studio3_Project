using UnityEngine;
using System.Collections;

public class Skip : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKey (KeyCode.P)) {
			StartCoroutine(Loading());
		}
	}
	IEnumerator Loading() {
		AsyncOperation async = Application.LoadLevelAsync(Application.loadedLevel+1);
		yield return async;
		Debug.Log("Loading complete");
	}
}
