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

    // Use this for initialization
    void Start () {
        AlphaOn = new Color32(128,128,128,77);
        AlphaOff = new Color32(128,128,128,0);

        LightningSound = LightningHolder.GetComponent<AudioSource>();
        audio = GetComponent<AudioSource>();
        audio.Play();
        audio.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("StartRain") && fading == false)
        {
            onoff = !onoff;
            fading = true;
        }

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
            }
            else
            {
                currentTime = 0f;
                fading = false;
            }
        }

        if (Input.GetButtonDown("PlayLightning") && Lightinging == false && isRaining == true)
        {
            Lightinging = true;
            LightningSound.Play();
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
}
