using System.Collections;
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

	// returns a string that fits the way scores in bowling a displayed
	public static string FormatRolls (List<int> rolls){
		string output = "";
		for(int i = 0; i < rolls.Count; i+=2){
			if(rolls[i] != 10){                                        // First handle no strike
				for(int j=i; (j<rolls.Count && j<=i+1) ;j++){          // look at next two entrys
					if(rolls[j] == 0){                                 // display handles zero differently then other integers
						output += "-";
					}else if( j == i+1 && rolls[j]+rolls[j-1] == 10){  // after second bowl in frame look for spare
						output += "/";
					}else{
						output += rolls[j].ToString();
					}
				}
			}else{                                                     // handle strike
				i--;
				if(output.Length <18){                                 // in frame 1-9 only one X per frame
					output +=" ";
				}
				output += "X";
			}
		}
		return output;
	}
}
