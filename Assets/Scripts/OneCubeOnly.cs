using UnityEngine;
using System.Collections;

public class OneCubeOnly : MonoBehaviour {

    public GameObject[] Cube;

	// Use this for initialization
	void Start () {
        Cube = GameObject.FindGameObjectsWithTag("Cube");
        if(Cube.Length > 1)
        {
            Destroy(Cube[0]);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
