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

	// Returns a list of scores for individual frames
	public static List<int> ScoreFrames (List<int> rolls){
		List<int> frameList = new List<int>();

		// We look at rolls in pairs, therefore j+=2
		for(int j=1;j<rolls.Count;j+=2){
			if(frameList.Count< 9){ // handle last frame seperatly, one entry == one frame
				if(rolls[j-1] == 10){
					// look at next two entrys if they exist to deal with the strike
					if(j < rolls.Count-1){
						frameList.Add(10+rolls[j]+rolls[j+1]);
					}
					// Strike just has one bowl
					j--;
				}else{
					//handling the split, i.e. adding next roll to the frame score
					if(rolls[j-1]+ rolls[j] == 10){
						if(j<rolls.Count-1){
							frameList.Add(10+rolls[j+1]);
						}
					}else{
						frameList.Add(rolls[j-1]+ rolls[j]);
					}
				}
			}else{
				// in the final frame only the sum of all bowls is important, strikes and spare simply reward a third ball, and a strike counts as one ball
				if(rolls[j-1]+rolls[j]<10){                           // no third bowl awarded
					frameList.Add(rolls[j-1]+rolls[j]);
				}else if(rolls[j-1]+rolls[j]>=10 && j<rolls.Count-1){ // third bowl awarded and thrown
					frameList.Add(rolls[j-1]+rolls[j]+rolls[j+1]);
				}
				// don't do anything if third bowl is awarded but not thrown
				break;
			}
		}
		return frameList;
	}

}
