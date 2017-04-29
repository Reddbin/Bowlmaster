using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<int> rolls = new List<int>();
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

	public void Bowl(int pin){
		ball.Reset();
		rolls.Add(pin);
		pinSetter.PerformAction(ActionMaster.NextAction(rolls));
		try{
			scoreDisplay.FillRolls(rolls);
			scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
		}catch {
			Debug.LogWarning("Something went wrong");
		}


	}
}
