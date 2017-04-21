using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public GameObject pinsPrefab;
    public int lastStandingCount = -1;
    public Text pinDisplay;

    private Ball ball;
    private float lastChangeTime;
    private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}

    void Update()
    {
        pinDisplay.text = CountStanding().ToString();
        if (ballEnteredBox)
        {
            UpdateStandingCountAndSettle();
        }
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
        }
        
        

    }

    void PinsHaveSettled()
    {
        ball.Reset();
        lastStandingCount = -1;  // Indicates new frame
        pinDisplay.color = Color.green;
        ballEnteredBox = false;
    }


    //loops through all pins in the scene, returns current number of standing pins
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
        
        return counter;
    }

    public void RaisePins()
    {
        Debug.Log("Raising pins");
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Raise();
        }
    }

    public void LowerPinss()
    {
        Debug.Log("Lowering pins");
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Debug.Log("Renewing pins");
        Instantiate(pinsPrefab);
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Raise();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //check for a ball and do stuff
        Ball ball = other.GetComponent<Ball>();
        if (ball)
        {
            pinDisplay.color = Color.red;
            ballEnteredBox = true;
        }
    }
}
