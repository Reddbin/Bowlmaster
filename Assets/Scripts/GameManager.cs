using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<int> pins = new List<int>();
	//private List<int> scores = new List<int>();
	private PinSetter pinSetter;

	private ScoreDisplay scoreDisplay;
	private Ball ball;

	// Use this for initialization
	void Start () {
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
		ball = GameObject.FindObjectOfType<Ball>();
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdatePinCount(int pin){
		pins.Add(pin);
		ActionMaster.Action action = ActionMaster.NextAction(pins);
		pinSetter.PerformAction(action);
		ball.Reset();
		//List<int> scores = ScoreMaster.ScoreFrames(pins);
		//scoreDisplay.UpdateScore(scores);
		// TODO update Display
	}
}
