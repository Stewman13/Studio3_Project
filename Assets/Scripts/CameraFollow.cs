using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject Player;
    public Vector3 camPos;
    public Vector3 playerPos;
    public float speed = 1.0F;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        camPos = new Vector3(transform.position.x, transform.position.y, -10);
        playerPos = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
        transform.position = Vector3.Lerp(camPos, playerPos, Time.time * speed);
    }
}
