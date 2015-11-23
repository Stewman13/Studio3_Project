using UnityEngine;
using System.Collections;

public class RainToggle : MonoBehaviour {

    public bool onoff;
    public Color AlphaOn;
    public Color AlphaOff;

    public float currentTime = 0f;
    public float currentLightningTime = 0f;
    public float timeToMove = 2f;
    public float LightningReset = 15f;
    public Color color;

    public bool fading = false;
    public bool Lightinging = false;

    public GameObject LightningHolder;
    public AudioSource LightningSound;

    public AudioSource audio;

    public bool isRaining = false;

	public Light mainLight;

	public GameObject Player;

	//this is the rising water
	public GameObject Water;
	public GameObject Water2;

    // Use this for initialization
    void Start () {
        AlphaOn = new Color32(128,128,128,77);
        AlphaOff = new Color32(128,128,128,0);

        LightningSound = LightningHolder.GetComponent<AudioSource>();
        audio = GetComponent<AudioSource>();
        audio.Play();
        audio.volume = 0;
		GetComponent<Renderer>().material.SetColor("_TintColor", color);
    }

    // Update is called once per frame
    void Update()
    {
//        if (Input.GetButtonDown("StartRain") && fading == false)
//        {
//            onoff = !onoff;
//            fading = true;
//        }

        if (onoff == true && fading == true)
        {
            if (currentTime <= timeToMove)
            {
                currentTime += Time.deltaTime;
                color = Color.Lerp(AlphaOn, AlphaOff, currentTime / timeToMove);
                audio.volume = Mathf.Lerp(1, 0, currentTime / timeToMove);
                LightningSound.volume = Mathf.Lerp(0.4f, 0, currentTime / timeToMove);
                GetComponent<Renderer>().material.SetColor("_TintColor", color);
                isRaining = false;
				Water.SendMessage("Off");
				Water2.SendMessage("Off");
            }
            else
            {
                currentTime = 0f;
                fading = false;
            }
        }
        if(onoff == false && fading == true)
        {
            if (currentTime <= timeToMove)
            {
                currentTime += Time.deltaTime;
                color = Color.Lerp(AlphaOff, AlphaOn, currentTime / timeToMove);
                audio.volume = Mathf.Lerp(0, 1, currentTime / timeToMove);
                LightningSound.volume = Mathf.Lerp(0, 0.4f, currentTime / timeToMove);
                GetComponent<Renderer>().material.SetColor("_TintColor", color);
                isRaining = true;
				Water.SendMessage("On");
				Water2.SendMessage("On");
            }
            else
            {
                currentTime = 0f;
                fading = false;
            }
        }

        if (Lightinging == true)
        {
            if (currentLightningTime <= LightningReset)
            {
                currentLightningTime += Time.deltaTime;
            }
            else
            {
                currentLightningTime = 0f;
                Lightinging = false;
            }
        }
    }

	IEnumerator Wait(float waitTime) 
	{
		waitTime = 0.1f;
		yield return new WaitForSeconds(waitTime);
		mainLight.intensity = 3;
		waitTime = 0.05f;
		yield return new WaitForSeconds(waitTime);
		mainLight.intensity = 1;
		waitTime = 0.1f;
		yield return new WaitForSeconds(waitTime);
		mainLight.intensity = 4;
		waitTime = 0.15f;
		yield return new WaitForSeconds(waitTime);
		mainLight.intensity = 1;
		waitTime = 0.06f;
		yield return new WaitForSeconds(waitTime);
		mainLight.intensity = 2;
		waitTime = 0.01f;
		yield return new WaitForSeconds(waitTime);
		mainLight.intensity = 1;
	}

	public void rain(){
		if (fading == false) {
			print ("rain");
			onoff = !onoff;
			fading = true;
		}
	}

	public void flash(){
		if (Lightinging == false && isRaining == true)
		{
			Lightinging = true;
			LightningSound.Play();
			StartCoroutine(Wait(1.0f));
			Player.SendMessage ("sizeOn");
		}
	}
}
