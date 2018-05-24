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

		//your code here

		int rollCount = rolls.Count;	//length of the rolls list
		if (rollCount % 2 != 0) {		//check if the last frame is completed or not
			rolls.RemoveAt (rollCount-1);	//removing the incomplete frame from the score calculation as the turn is not finished
		}

		int total = 0,Count = 0;
		bool onSecondFrame = false,aSpare = false,aStrike = false;

		foreach(int roll in rolls){
			Count++;
			onSecondFrame = false;
			if(Count % 2 == 0){ onSecondFrame = true;}

			total += roll;

			if(aStrike){
				aStrike = false;
				continue;
			}
			if(aSpare){
				aSpare = false;
				frameList.Add (total);
				total = 0;
			}

			if(total == 10){	//strike or spare
				if(onSecondFrame){	//spare
					//spare stuff
					aSpare = false;
					continue;
				}
				if( ! onSecondFrame){	//a strike!!
					aStrike = true;
					Count++;
					continue;
				}
			}
			if (onSecondFrame) {
				frameList.Add (total);
				total = 0;
			}
		}


		return frameList;
	}
}