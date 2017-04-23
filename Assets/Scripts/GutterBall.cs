using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterBall : MonoBehaviour {

	private PinSetter pinSetter;

	void Start(){
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
	}

	private void OnTriggerExit(Collider other){
		Ball ball = other.GetComponent<Ball>();
		if (ball)
		{
			pinSetter.UpdateBallStatus();
		}
	}
}
