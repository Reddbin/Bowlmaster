using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PinSetter : MonoBehaviour {

    public GameObject pinsPrefab;

	private PinCounter pinCounter;

	private Animator animator;

	// Use this for initialization
	void Start () {
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
		animator = GetComponent<Animator>();
	}
		
	public void PerformAction(ActionMaster.Action action){
		if( action == ActionMaster.Action.Tidy ){
			animator.SetTrigger("tidyTrigger");
		}
		if(action == ActionMaster.Action.Reset ){
			animator.SetTrigger("resetTrigger");
			//maybe move this ?
			pinCounter.Reset();
		}
		if(action == ActionMaster.Action.EndTurn ){
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();
		}

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



}
