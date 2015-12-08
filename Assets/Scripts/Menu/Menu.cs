using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GameObject load;
	AsyncOperation async;
	public bool isLoading = false;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		isLoading = true;
		StartCoroutine (Loading());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Play()
    {
		if (isLoading == false) {
			async.allowSceneActivation = true;
		}
    }

	IEnumerator Loading() {
		Debug.LogWarning("ASYNC LOAD STARTED - " +
		                 "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
		async = Application.LoadLevelAsync(Application.loadedLevel+1);
		async.allowSceneActivation = false;
		isLoading = false;
		load.SetActive (false);
		yield return async;

//		AsyncOperation async = Application.LoadLevelAsync(Application.loadedLevel+1);
//		load.SetActive (true);
//		yield return async;
//		Debug.Log("Loading complete");
	}

	void Exit()
	{
		Application.Quit();
	}
}
