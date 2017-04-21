﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster actionMaster;

	[SetUp]
	public void Setup (){
		actionMaster = new ActionMaster();
	}

	[Test]
	public void T00PassingTest(){
		Assert.AreEqual (1,1);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn(){
		Assert.AreEqual(endTurn, actionMaster.Bowl(10));
	}

	[Test]
	public void T02Bowl8ReturnsTidy (){
		Assert.AreEqual(tidy, actionMaster.Bowl(8));
	}

	[Test]
	public void T03Bowl82SpareReturnsEndTurn(){
		actionMaster.Bowl(8);
		Assert.AreEqual(endTurn, actionMaster.Bowl(2));
	}

	[Test]
	public void T04FinaloundsNoStrike (){
		for(int i=0;i<9;i++){
			actionMaster.Bowl(8);
			actionMaster.Bowl(2);
		}
		actionMaster.Bowl(8);
		Assert.AreEqual(endGame, actionMaster.Bowl(2));
	}

	[Test]
	public void T05FinalRoundsScoreStrike(){
		for(int i=0;i<9;i++){
			actionMaster.Bowl(8);
			actionMaster.Bowl(2);
		}
		Assert.AreEqual(reset, actionMaster.Bowl(10));
	}

	[Test]
	public void T06FinalRoundsScore3Strikes(){
		for(int i=0;i<9;i++){
			actionMaster.Bowl(8);
			actionMaster.Bowl(2);
		}
		actionMaster.Bowl(10);
		actionMaster.Bowl(10);
		Assert.AreEqual(endGame, actionMaster.Bowl(10));
	}

	[Test]
	public void T07FinalRoundScore2Strikes8(){
		for(int i=0;i<9;i++){
			actionMaster.Bowl(8);
			actionMaster.Bowl(2);
		}
		actionMaster.Bowl(10);
		actionMaster.Bowl(10);
		Assert.AreEqual(endGame, actionMaster.Bowl(8));
	}
}
