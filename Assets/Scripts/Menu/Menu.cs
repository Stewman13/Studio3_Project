using UnityEngine;
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
        Application.LoadLevel(Application.loadedLevel + 1);
    }

	void Exit()
	{
		Application.Quit();
	}
}
