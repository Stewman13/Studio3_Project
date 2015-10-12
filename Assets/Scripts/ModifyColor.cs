using UnityEngine;
using System.Collections;

public class ModifyColor : MonoBehaviour {

    public Color32 newColor;
    public Color32 currentColor;

    public float currentTime = 0f;
    public float timeToMove = 2f;

    public bool moving = false;

    public TrailRenderer trailRend;
    public Light glow;

    // Use this for initialization
    void Start () {
        trailRend = gameObject.GetComponent<TrailRenderer>();
        trailRend.material.color = GetComponent<Renderer>().material.color;
        glow = GetComponent<Light>();
        currentColor = GetComponent<Renderer>().material.color;
        trailRend.material.color = GetComponent<Renderer>().material.color;
        glow.color = GetComponent<Renderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("ChangeColor") && moving == false)
        {
            newColor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
            currentColor = GetComponent<Renderer>().material.color;
            moving = true;
        }
        if (moving == true)
        {
            if (currentTime <= timeToMove)
            {
                currentTime += Time.deltaTime;
                GetComponent<Renderer>().material.color = Color32.Lerp(currentColor, newColor, currentTime / timeToMove);
                trailRend.material.color = GetComponent<Renderer>().material.color;
                glow.color = GetComponent<Renderer>().material.color;
            }
            else
            {
                currentTime = 0f;
                moving = false;
            }
        }
        //  GetComponent<Renderer>().material.color = Color(Random.Range(0.0, 1.0), Random.Range(0.0, 1.0), Random.Range(0.0, 1.0));
        // Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 1
    }
}
