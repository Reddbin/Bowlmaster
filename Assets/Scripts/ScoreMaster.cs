using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {

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
			if(frameList.Count < 10){                           // handle last frame seperatly, one entry == one frame
				if(rolls[j-1] == 10){	
					if(j + 1 < rolls.Count){                    // look at next two entrys if they exist to deal with the strike
						frameList.Add(10+rolls[j]+rolls[j+1]);
					}
					j--;                                        // Strike just has one bowl
				}else if(rolls[j-1]+ rolls[j] == 10){           // Handling the spare, i.e. adding next roll to the frame score     
					if(j + 1 < rolls.Count){                    // Only proceed if there is a next entry
						frameList.Add(10+rolls[j+1]);
					}
				}else{
					frameList.Add(rolls[j-1]+ rolls[j]);        // Handle Normal frame
				}
			}else{
				break;                                          // prevent 11th frame score
			}
		}
		return frameList;
	}

}
