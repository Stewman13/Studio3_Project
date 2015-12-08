using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeOfDay : MonoBehaviour {

	Image myImageComponent;
	public Sprite sun;
	public Sprite moon;
	public bool isDay = true;

	// Use this for initialization
	void Start () {
		myImageComponent = GetComponent<Image>();
		isDay = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click(){
		if (myImageComponent.sprite == moon) {
			myImageComponent.sprite = sun;
			isDay = true;
		}
		else if (myImageComponent.sprite == sun) {
			myImageComponent.sprite = moon;
			isDay = false;
		}
	}
}
