using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 startPosition, endPosition;
    private float startTime, endTimeRelative;
	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}

    public void MoveStart(float xNudge)
    {
        //We don't want the player to move the ball after launch
        if (!ball.IsInPlay())
        {
            //only used for limiting ball position
            float newX = ball.GetComponent<Transform>().position.x + xNudge;
            if ((newX >=-50f) && (newX <= 50f))
            {
                //without Space.World argument -> weird movement of ball after reset
                ball.transform.Translate(xNudge * Vector3.right, Space.World);
            }
            
            
        }
        
    }

    public void DragStart()
    {
        // Capture time and position of drag start
        startTime = Time.time;
        startPosition = Input.mousePosition;
    }

    public void DragEnd()
    {
        // Launch the ball
        //TODO seperate speed from time, probly second input triggered by this method
        endTimeRelative = Time.time - startTime;
        endPosition = Input.mousePosition;
        float speed = 600 - 40*endTimeRelative;
        //modifiy x component of vector drawn by player, otherwise frustringly hard to get even slightly straigth line 
        //might need to balance this further
        Vector3 launchVelocity = speed * (new Vector3(0.3f*(endPosition.x-startPosition.x), 0f, endPosition.y - startPosition.y)).normalized;
        ball.Launch(launchVelocity);
    }

    
}
