﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Ball ball;
    public float pinPosition = 1829f;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset =   transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(ball.transform.position.z <= pinPosition)
        {
            transform.position = ball.transform.position + offset;
        }
        
	}
}
