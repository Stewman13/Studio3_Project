using UnityEngine;
using System.Collections;

public class RainFollowCam : MonoBehaviour {

    public GameObject Camera;
    public Vector3 myPos;
    public Vector3 camPos;
    public float speed = 100.0F;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myPos = new Vector3(transform.position.x, transform.position.y, -3);
        camPos = new Vector3(Camera.transform.position.x, Camera.transform.position.y + 6, -3);
        transform.position = Vector3.Lerp(myPos, camPos, Time.time * speed);
    }
}
