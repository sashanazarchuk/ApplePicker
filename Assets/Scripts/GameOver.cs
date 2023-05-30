using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

	// Start is called before the first frame update
	void Start()
	{
		Text text = GameObject.Find("Score").GetComponent<Text>();
		int score = PlayerPrefs.GetInt("LastScore");
		text.GetComponent<Text>().text = "Your score is: "+score;

	}

}
