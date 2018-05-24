using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

	//returns a list of cumulative scores, like a normal score card.
	public static List <int> ScoreCumulative (List <int> rolls){

		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;

		foreach(int frameScore in ScoreFrames (rolls)){
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}

		return cumulativeScores;
	}

	// Return a list of individual frame scores, NOT cumulative.
	public static List<int> ScoreFrames (List<int> rolls) {
		List<int> frameList = new List<int> ();
		int total = 0,Count = 0;

		//your code here

		int rollCount = rolls.Count;	//length of the rolls list
		if (rollCount % 2 != 0) {
			rolls.RemoveAt (rollCount-1);
		}

		foreach(int roll in rolls){
			Count++;
			total += roll;
			if (Count % 2 == 0) {
				frameList.Add (total);
				total = 0;
			}
		}


		return frameList;
	}
}