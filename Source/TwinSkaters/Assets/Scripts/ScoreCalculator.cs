using UnityEngine;
using System.Collections;

public class ScoreCalculator : MonoBehaviour {

	public UnityEngine.UI.Text ScoreText;
	private GameObject LeftSkate,RightSkate;
	private int score;

	// Use this for initialization
	void Start () {
		LeftSkate = GameObject.FindWithTag ("LeftSkate");
		RightSkate = GameObject.FindWithTag ("RightSkate");
		score = 0;
		ScoreText.text = "0";
	}

	void OnTriggerExit2D (Collider2D other) {
		GameObject collider = other.gameObject;
		if (collider.tag == "Cone" && collider.transform.position.x < RightSkate.transform.position.x &&
		    collider.transform.position.x > LeftSkate.transform.position.x ) {
			score++;
			ScoreText.text = ""+score;
		}
	}
}
