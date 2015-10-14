using UnityEngine;
using System.Collections;

public class verlet : MonoBehaviour {
    public GameObject[] objects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
/*
        for (int i = 0; i < objects.length-1; ++i)
        {
            Vector2 delta = objects[i + 1].transform.position - objects[i].transform.position;
            float deltalength = delta.length;
            float diff = (deltalength - restlength) / deltalength;
            objects[i].transform.position = objects[i].transform.position - delta * 0.5 * diff;
            objects[i + 1].transform.position = objects[i + 1].transform.position + delta * 0.5 * diff;
        }
        */
	}
}
