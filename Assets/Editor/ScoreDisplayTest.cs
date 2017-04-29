using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest{

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01Bowl1 (){
		int[] rolls = {1};
		string rollsString = "1";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T02Bowl18 (){
		int[] rolls = {1,8};
		string rollsString = "18";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T03BowlStrike(){
		int[] rolls = {10};
		string rollsString = "X ";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T04BowlSpare(){
		int[] rolls = {1,9};
		string rollsString = "1/";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
}
