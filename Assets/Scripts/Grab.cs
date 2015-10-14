using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {

    public GameObject cube;
    public float dist;
    public bool grabbed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        cube = GameObject.FindGameObjectWithTag("Cube");

        if(cube != null)
        {
            dist = Vector3.Distance(cube.transform.position, transform.position);
            if (Input.GetButtonDown("Fire1"))
            {

                if(dist < 1.2 && grabbed == false)
                {
                    grabbed = true;
                    cube.transform.parent = this.transform;
                    cube.GetComponent<Rigidbody>().isKinematic = true;
                }
                else
                {
                    cube.transform.parent = null;   
                    if(grabbed == true)
                    {
                        cube.GetComponent<Rigidbody>().isKinematic = false;
                    }
                    grabbed = false;
                }
            }
        }
	}
}
