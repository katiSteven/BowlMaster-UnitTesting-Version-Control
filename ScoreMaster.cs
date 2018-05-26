﻿//using System.Collections;
using System.Collections.Generic;
//using System.
using UnityEngine;
using System;


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
			int total = 0;//stores the total points for each frame(sum of 1st & 2nd bowl)
			int count = 0;//to keep track of every bowl
		try{
			for(int i=0;i<rolls.Count;i++){
				if(frameList.Count == 10){break;}
				count++;					//to consider every frame
				total += rolls [i];			//adding every frame score
				if (rolls [i] == 10 && count % 2 == 1) {	//strike conditions
					frameList.Add(total + rolls [i + 1] + rolls [i + 2]);
					total = 0;				//reset the total
					count++;				//to take into consideration the skipped 2nd attempt during a strike
				}
				else if(total == 10 && (count % 2) == 0){	//spare conditions
					frameList.Add(total + rolls[i + 1]);
					total = 0;				//reset the total
				}
				else if(rolls[i] < 10 && (count % 2) == 0){		//Normal "OPEN" frame
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