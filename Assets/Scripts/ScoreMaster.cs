using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

	// Returns a list of cumulative scores, like a normal score card
	public static List<int> ScoreCumulative (List<int> rolls){
		List<int> cumulativeScore = new List<int>();
		List<int> tempScore = ScoreFrames(rolls);
		int runningTotal = 0;
		foreach(int frameScore in tempScore){
			runningTotal += frameScore;
			cumulativeScore.Add(runningTotal);
		}
		return cumulativeScore;
	}

	public static List<int> ScoreFrames (List<int> rolls){
		List<int> frameList = new List<int>();

		// MY code here

		return frameList;
	}

}
