using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private List<int> pinFalls;

	[SetUp]
	public void Setup(){
		pinFalls = new List<int>();
	}

	[Test]
	public void T00PassingTest(){
		Assert.AreEqual (1,1);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn(){
		pinFalls.Add(10);
		Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T02Bowl8ReturnsTidy (){
		pinFalls.Add(8);
		Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T03Bowl82SpareReturnsEndTurn(){
		int[] rolls = {8,2};
		pinFalls = rolls.ToList();
		Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
	}
		
	[Test]
	public void T04FinalRound28SpareReturnReset(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 2,8};
		pinFalls = rolls.ToList();
		Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T05FinalRoundStrikeReturnReset(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
		pinFalls = rolls.ToList();
		Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T06FinalRound22splitReturnEndGame(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 2,2};
		pinFalls = rolls.ToList();
		Assert.AreEqual(endGame, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T07FinalRound2ReturnTidy(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 2};
		pinFalls = rolls.ToList();
		Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T09FinalRoundStrike2ReturnTidy(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,2};
		pinFalls = rolls.ToList();
		Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T08GameEndsAfterBowl21(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,10,10};
		pinFalls = rolls.ToList();
		Assert.AreEqual(endGame, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T10FinalRoundStrikeThen0(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,0};
		pinFalls = rolls.ToList();
		Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T11Score0Then10Then1ReturnTidy(){
		int[] rolls = {0,10,1};
		pinFalls = rolls.ToList();
		Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T12Dondi10ThFrameTurkey(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,10,10};
		pinFalls = rolls.ToList();
		Assert.AreEqual(endGame, ActionMaster.NextAction(pinFalls));
	}
}
