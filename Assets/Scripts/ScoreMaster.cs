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
		int strikeCounter = -1;
		int spareFrame = 0;
		int frame = 0;
		int counter = 0;
		foreach(int roll in rolls){
			if(strikeCounter != -1){
				strikeFrame += roll;
				strikeCounter--;
				if(strikeCounter ==0){
					frameList.Add(strikeFrame);
					strikeCounter--;
				}
			}
			if(spareFrame != 0){
				spareFrame += roll;
				frameList.Add(spareFrame);
				spareFrame = 0;
			}
			if(roll == 10){
				strikeFrame += 10;
				strikeCounter = 2;
			}else{
				frame += roll;
				if(frame == 10){
					spareFrame = 10;
					frame = 0;
					counter = 0;
				}else{
					counter++;
				}
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
