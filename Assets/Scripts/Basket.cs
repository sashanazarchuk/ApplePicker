using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class Basket : MonoBehaviour
{
	[Header("Set Dynamcally")]
	public Text scoreGT;

	private void Start()
	{
		GameObject scoreGo = GameObject.Find("ScoreCounter");
		scoreGT = scoreGo.GetComponent<Text>();
		scoreGT.text = "100";
		PlayerPrefs.SetInt("LastScore", 100);
	}


	// Update is called once per frame
	void Update()
	{
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	private void OnCollisionEnter(Collision collision)
	{
		GameObject collidedWith = collision.gameObject;
		if(collidedWith.tag == "Apple")
		{
			Destroy(collidedWith);
			int score = int.Parse(scoreGT.text);
			score += 100;
			scoreGT.text = score.ToString();
			PlayerPrefs.SetInt("LastScore", score);
			if (score > HighScore.score)
			{
				HighScore.score = score;
			}

		}
	}
}
