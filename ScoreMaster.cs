//using System.Collections;
using System.Collections.Generic;
//using System.
using UnityEngine;
using System;


public class ScoreMaster {

	//returns a list of cumulative scores, like a normal score card.
	public static List <int> ScoreCumulative (List <int> rolls){

		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;
		int frameCount = 0;// should be no more than 10 frames

		foreach(int frameScore in ScoreFrames (rolls)){
			frameCount++;
			if(frameCount <= 10){
				runningTotal += frameScore;
				cumulativeScores.Add (runningTotal);
			}
		}

		return cumulativeScores;
	}

	// Return a list of individual frame scores, NOT cumulative.
	public static List<int> ScoreFrames (List<int> rolls) {
		List<int> frameList = new List<int> ();

		//your code here

//		int total = 0,Count = 0;
//		bool onSecondFrameCurrently = false;
//		bool wasASpare = false;
//
//		int bowlsAfterSpare = 0;
//		int bowlsAfterStrike = 0;
//
//		Stack StrikeStack = new Stack();
//		StrikeStack.Push ("$");
//
//		foreach(int roll in rolls){
//			Count++;
//			onSecondFrameCurrently = false;
//			if(Count % 2 == 0){ onSecondFrameCurrently = true;}
//
//			total += roll;
//
//
//			if((total % 10) == 0){	// spare
//				if(onSecondFrameCurrently){	//spare
//					wasASpare = true;
//					continue;
//				}
//			}
//
//
//
//
//			if(wasASpare)
//				bowlsAfterSpare++;
//
//			if (StrikeStack.Peek ().ToString().Equals("S")) {
//				bowlsAfterStrike++;
//			}
//
//
//			if(bowlsAfterSpare == 1){
//				wasASpare = false; bowlsAfterSpare = 0;
//				frameList.Add (total);
//				total = roll;
//
//			}else if((bowlsAfterStrike % 2) == 0 && bowlsAfterStrike != 0){
//				bowlsAfterStrike = 0;
//				StrikeStack.Pop ();
//				frameList.Add (total);
//				total = total - 10;
//
//			} if (onSecondFrameCurrently && total <10) {
//				frameList.Add (total);
//				total = 0;
//			}
//
//			if( roll == 10){	//a strike!!
//				StrikeStack.Push ("S");
//				Count--;
//				//				continue;
//			}
//
//
//		} 


			int total = 0;//stores the total points for each frame(sum of 1st & 2nd bowl)
			int count = 0;//to keep track of every bowl
		try{
			for(int i=0;i<rolls.Count;i++){
				count++;
				total += rolls [i];
				if (rolls [i] == 10 && count % 2 == 1) {	//strike conditions
					total += rolls [i + 1] + rolls [i + 2];
					frameList.Add(total);
					total = 0;				//reset the total
					count++;
				}
				else if(total == 10 && (count % 2) == 0){	//spare conditions
					total += rolls[i + 1];
					frameList.Add(total);
					total = 0;
				}
				else if(rolls[i] < 10 && (count % 2) == 0){		//every frame has 2 attempts where pin(s) are left standing
					frameList.Add(total);
					total = 0;				//reset the total
				}
			}
		}catch(ArgumentOutOfRangeException){
			return frameList;
		}
		return frameList;
	}
}