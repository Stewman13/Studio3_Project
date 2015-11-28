using UnityEngine;
using System.Collections;

public class SwipeTest : MonoBehaviour {

	public bool couldBeSwipe;
	public bool couldStartGravity;
	public Vector3 startPos;
	public float swipeStartTime;
	public float maxSwipeTime;
	public float minSwipeDist;

	public Vector2 direction;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.touches[0].phase == TouchPhase.Moved)//Check if Touch has moved.
//		{
//			direction = Input.touches[0].deltaPosition.normalized;  //Unit Vector of change in position
//			speed = Input.touches[0].deltaPosition.magnitude / Input.touches[0].deltaTime; //distance traveled divided by time elapsed
//		}
	}

	IEnumerator checkHorizontalSwipes () //Coroutine, wich gets Started in "Start()" and runs over the whole game to check for swipes
	{
		while (true) { //Loop. Otherwise we wouldnt check continoulsy ;-)
			foreach (Touch touch in Input.touches) { //For every touch in the Input.touches - array...
				
				switch (touch.phase) {
				case TouchPhase.Began: //The finger first touched the screen --> It could be(come) a swipe
					couldBeSwipe = true;
					
					startPos = touch.position;  //Position where the touch started
					swipeStartTime = Time.time; //The time it started
					break;
					
				case TouchPhase.Stationary: //Is the touch stationary? --> No swipe then!
					couldBeSwipe = false;
					//couldStartGravity = true; //will turn grav on for duration of hold.
					break;
				}
				float swipeTime = Time.time - swipeStartTime; //Time the touch stayed at the screen till now.
				float swipeDist = Mathf.Abs (touch.position.x - startPos.x); //Swipedistance
				
				
				if (couldBeSwipe && swipeTime < maxSwipeTime && swipeDist > minSwipeDist) {
					// It's a swiiiiiiiiiiiipe!
					couldBeSwipe = false; //<-- Otherwise this part would be called over and over again.
					
					if (Mathf.Sign (touch.position.x - startPos.x) == 1f) { //Swipe-direction, either 1 or -1.
						
						//Right-swipe
						Debug.Log ("right");
						
					} else {
						
						//Left-swipe
						Debug.Log ("left");
					}
				} 
			}
			yield return null;
		}
	}
}
