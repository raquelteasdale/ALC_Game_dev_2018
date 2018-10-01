using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
public static int Score;
Text ScoreText;
	// Use this for initialization
	void Start () {
		ScoreText = GetComponent<Text>();
		Score = -1;
	}

	// Update is called once per frame
	void Update () {

		ScoreText.text = " " + Score;
		if (Score < 0)
		{
			Score = 0;
		}
	}

	public static void AddPoints (int PointsToAdd)
	{
	Score += PointsToAdd;
	}
}
