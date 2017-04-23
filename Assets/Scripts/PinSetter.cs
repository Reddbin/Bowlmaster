using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public GameObject pinsPrefab;
    public Text pinDisplay;

	private int lastStandingCount = -1;
    private float lastChangeTime;
	private int lastSettledCount = 10;
    private bool ballLeftBox = false;

	// has to be at this level, since we only want one instance
	private ActionMaster actionMaster = new ActionMaster();

	private Ball ball;
	private Animator animator;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
		animator = GetComponent<Animator>();
	}

    void Update()
    {
        pinDisplay.text = CountStanding().ToString();
        if (ballLeftBox)
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
			Debug.Log("PinsHaveSettled called");
        }
        
        

    }

    void PinsHaveSettled()
    {
		int pinFall = lastSettledCount - CountStanding();

		lastSettledCount = CountStanding();
		ActionMaster.Action action = actionMaster.Bowl(pinFall);
		if( action == ActionMaster.Action.Tidy ){
			animator.SetTrigger("tidyTrigger");
		}
		if(action == ActionMaster.Action.Reset ){
			animator.SetTrigger("resetTrigger");
			lastSettledCount = 10;
		}
		if(action == ActionMaster.Action.EndTurn ){
			animator.SetTrigger("resetTrigger");
			lastSettledCount = 10;
		}
        ball.Reset();
        lastStandingCount = -1;  // Indicates new frame
        pinDisplay.color = Color.green;
        ballLeftBox = false;
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

    public void RaisePins()
    {
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Raise();
        }
    }

    public void LowerPinss()
    {
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Instantiate(pinsPrefab);
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Raise();
        }
    }


	public void UpdateBallStatus(){
		pinDisplay.color = Color.red;
		ballLeftBox = true;
	}
}
