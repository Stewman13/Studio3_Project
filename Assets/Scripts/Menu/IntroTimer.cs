using UnityEngine;
using System.Collections;

public class IntroTimer : MonoBehaviour {

	AsyncOperation async;

	// Use this for initialization
	void Start () {
		StartCoroutine(WaitAndPrint(3.0F));

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator WaitAndPrint(float waitTime) {
		Debug.LogWarning("ASYNC LOAD STARTED - " +
		                 "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
		async = Application.LoadLevelAsync(Application.loadedLevel+1);
		async.allowSceneActivation = false;
		yield return new WaitForSeconds(waitTime);
		async.allowSceneActivation = true;
	}
}
