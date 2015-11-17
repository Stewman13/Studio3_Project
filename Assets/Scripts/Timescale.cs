using UnityEngine;
using System.Collections;

public class Timescale : MonoBehaviour {

	public float timeScale = 1.0f;
	public float StartHeartRate = 0.0f;
	public float CurrentHeartRate = 70.0f;
	public float MaxTimescale = 1.0f;
	public float MinTimescale = 0.5f;
	public float HeartRatetoTimeScale = 0.0f;

	// Use this for initialization
	void Start () {
		StartHeartRate = 80.0f;
		CurrentHeartRate = 80.0f;
	}
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = timeScale;
		//give a 5 beat leeway
		if (CurrentHeartRate >= (StartHeartRate + 5.0f)) {
			HeartRatetoTimeScale = ((CurrentHeartRate - (StartHeartRate + 5.0f))/100);
			timeScale = (1.0f - HeartRatetoTimeScale);
			if(timeScale <= 0.5f){
				timeScale = 0.5f;
				print("Breathing Test");
			}
		}
		if (CurrentHeartRate < (StartHeartRate + 5.0f)) {
			timeScale = 1.0f;
		}
	}
}
