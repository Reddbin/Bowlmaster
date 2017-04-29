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

	public static string FormatRolls (List<int> rolls){
		string output = "";
		for(int i = 0; i < rolls.Count; i+=2){
			if(rolls[i] != 10){ // First handle no strike
				if(rolls[i] == 0){ // display should handle zero differently then other integers
					output += "-";
				}else{
					output += rolls[i].ToString();
				}
				if(i+1<rolls.Count){ // check whether there is a next entry
					if( rolls[i]+rolls[i+1] == 10){
						output += "/";
					}else{
						if(rolls[i+1] == 0){
							output += "-";
						}else{
							output += rolls[i+1].ToString();
						}
					}
				}
			}else if(output.Length <18){ // handle strike in frame 1-9
				output += " X";
				i--;
			}else{// final frame and strike
				output += "X";
				i--;
			}
			

		}
		return output;
	}
}
