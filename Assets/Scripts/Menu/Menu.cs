﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Play()
    {
		StartCoroutine (Loading());
    }

	IEnumerator Loading() {
		AsyncOperation async = Application.LoadLevelAsync(Application.loadedLevel+1);
		yield return async;
		Debug.Log("Loading complete");
	}

	void Exit()
	{
		Application.Quit();
	}
}
