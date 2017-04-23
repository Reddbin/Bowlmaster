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

		int strikeFrame =0;
		int frame = 0;
		int counter = 0;
		foreach(int roll in rolls){
			if(roll == 10){
				strikeFrame += 10;
			}else{
				frame += roll;
				counter++;
			}

			if(counter == 2){
				frameList.Add(frame);
				frame = 0;
				counter = 0;
			}
		}


		return frameList;
	}

}
