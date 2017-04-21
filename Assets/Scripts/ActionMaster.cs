using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {
	public enum Action {Tidy, Reset, EndTurn, EndGame};

	// private int[] bowls = new int[21];
	private int bowl = 1;

	public Action Bowl (int pins){

		if(pins <0 || pins >10) {throw new UnityException("Invalid pin count");}

		//other Behaviour here, e.g. last frame
		if(bowl == 20 ){
			bowl = 1;
			return Action.EndGame;
		}

		if(pins == 10){
			bowl += 2;
			if(bowl < 19){
				return Action.EndTurn;
			}else if(bowl < 23){
				return Action.Reset;
			}else{
				//bowl = 1;
				return Action.EndGame;
			}
		}
			
		if(bowl % 2 != 0) { // Mid frame (or last frame)
			bowl += 1;
			if(bowl == 24){
				return Action.EndGame;
			}else{
				return Action.Tidy;
			}


		} else if (bowl % 2 == 0){ // End of frame
			bowl += 1;
			return Action.EndTurn;
		}



		throw new UnityException("Not sure what action to return!");
	}
}
