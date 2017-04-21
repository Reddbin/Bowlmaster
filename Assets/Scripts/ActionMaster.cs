﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {
	public enum Action {Tidy, Reset, EndTurn, EndGame};

	// private int[] bowls = new int[21];
	private int bowl = 1;

	public Action Bowl (int pins){

		if(pins <0 || pins >10) {throw new UnityException("Invalid pin count");}

		//other Behaviour here, e.g. last frame
		if(bowl >= 19 ){ // Last frame
			if(bowl >= 23){
				bowl = 1;
				return Action.EndGame;
			}
			if(pins == 10){
				bowl += 2;
				return Action.Reset;
			}else{
				// jump to last throw
				bowl += 5;
				return Action.Tidy;
			}
		}

		if(pins == 10){
			bowl += 2;
			return Action.EndTurn;
		}
			
		if(bowl % 2 != 0) { // Mid frame (or last frame)
			bowl += 1;
			return Action.Tidy;
		} else if (bowl % 2 == 0){ // End of frame
			bowl += 1;
			return Action.EndTurn;
		}



		throw new UnityException("Not sure what action to return!");
	}
}
