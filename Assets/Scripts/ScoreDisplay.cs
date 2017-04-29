﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	// TODO rename these
	public Text[] bowlCounts;
	public Text[] scores;


	public void FillRolls(List<int> rolls){
		string outputString = FormatRolls(rolls);
		for(int i=0; i< outputString.Length; i++){
			bowlCounts[i].text = outputString[i].ToString();
		}
	}

	public void FillFrames(List<int> frames){
		for(int i=0;i<frames.Count; i++){
			scores[i].text = frames[i].ToString();
		}
	}

	public static string FormatRolls (List<int> rolls){
		string output = "";
		for(int i = 0; i < rolls.Count; i++){
			output += rolls[i].ToString();
		}
		return output;
	}
}
