using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity;

    private Vector3 startPosition;
    private bool inPlay = false;
    private Rigidbody ballRigidBody;
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        
        ballRigidBody = GetComponent<Rigidbody>();
        ballRigidBody.useGravity = false;
        startPosition = transform.position;
        //Launch(launchVelocity);
    }

    public void Launch(Vector3 velocity)
    {
		// move the if to BallDragLauch part of the code?
		if(!inPlay){
			inPlay = true;
			ballRigidBody.useGravity = true;
			ballRigidBody.velocity = velocity;

			audioSource = GetComponent<AudioSource>();
			audioSource.Play();
		}
        
    }

    public bool IsInPlay()
    {
        return inPlay;
    }

    public void Reset()
    {
        ballRigidBody.angularVelocity = Vector3.zero;
        ballRigidBody.velocity = Vector3.zero;
        ballRigidBody.useGravity = false;
        inPlay = false;
        transform.position = startPosition;
		transform.rotation = Quaternion.identity;
        //Debug.Log("Reset requested");
    }
}
