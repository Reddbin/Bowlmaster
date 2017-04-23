using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public Text pinDisplay;

	private int lastStandingCount = -1;
	private float lastChangeTime;
	private int lastSettledCount = 10;
	private bool ballLeftBox = false;

	private GameManager gameManger;

	void Start(){
		gameManger = GameObject.FindObjectOfType<GameManager>();
	}

	// Update is called once per frame
	void Update () {
		pinDisplay.text = CountStanding().ToString();
		if (ballLeftBox)
		{
			UpdateStandingCountAndSettle();
		}
	}

	public void Reset(){
		lastSettledCount = 10;
	}

	private void OnTriggerExit(Collider other){
		Ball ball = other.GetComponent<Ball>();
		if (ball)
		{
			pinDisplay.color = Color.red;
			ballLeftBox = true;
		}
	}

	void PinsHaveSettled()
	{
		int pinFall = lastSettledCount - CountStanding();
		lastSettledCount = CountStanding();
		gameManger.UpdatePinCount(pinFall);

		pinDisplay.color = Color.green;
		lastStandingCount = -1;  // Indicates new frame
		ballLeftBox = false;
	}

	void UpdateStandingCountAndSettle()
	{
		float timeThreshold = 5f;
		//Update the lastStandingCount
		int currentstanding = CountStanding();
		// don't give green signal until no pin is wobbling
		if(currentstanding != lastStandingCount)
		{
			lastChangeTime = Time.time;
			lastStandingCount = currentstanding;
			return;
		}else if( Time.time - lastChangeTime >= timeThreshold )
		{
			//TODO make this actually dependend on whether no pin is undecided
			// Call PinsHaveSettled() when they have
			PinsHaveSettled();
			//Debug.Log("PinsHaveSettled called");
		}
	}

	//loops through all pins in the scene, returns number of standing pins
	int CountStanding()
	{
		int counter = 0;
		Pin[] pinsInScene = GameObject.FindObjectsOfType<Pin>();
		foreach(Pin pin in pinsInScene)
		{
			if (pin.IsStanding())
			{
				counter++;
			}
		}
		//number of fallen pins
		return counter;
	}

}
