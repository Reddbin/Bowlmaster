using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster3 {
	public enum Action {Tidy, Reset, EndTurn, EndGame , NULL};

	private int[] bowls = new int[21];
	private int bowl = 1;

	public static Action NextAction (List<int> pinFalls){
		ActionMaster3 actionMaster = new ActionMaster3();
		Action action = new Action();
		foreach(int pins in pinFalls){
			action = actionMaster.Bowl(pins);
		}
		return action;
	}

	private Action Bowl (int pins){ // TODO make private

		if(pins <0 || pins >10) {throw new UnityException("Invalid pin count");}
		//insert pin count
		bowls[bowl-1] = pins;

		//other Behaviour here, e.g. last frame
		if(bowl >= 21){
			return Action.EndGame;
		}
		if(bowl >= 19 && Bowl21Awarded() ){ // Last frame
			if(Bowl20NeedsTidy()){
				bowl +=1;
				return Action.Tidy;
			}
			bowl +=1;
			return Action.Reset;
		}
		if(bowl >= 20){
			return Action.EndGame;
		}

		if(pins == 10 && bowl % 2 != 0){
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

	private bool Bowl21Awarded(){
		//Remember that arrays start counting at 0
		return (bowls[19-1] + bowls [20-1] >= 10);
	}

	// for the case 19 is strike and 20 is less then 10
	private bool Bowl20NeedsTidy(){
		return (bowl ==20 && bowls[20-1] != 10 && bowls[19-1] == 10);
	}
}
