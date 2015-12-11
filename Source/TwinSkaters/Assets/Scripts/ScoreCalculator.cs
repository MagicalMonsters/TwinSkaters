using UnityEngine;
using System.Collections;

public class ScoreCalculator : MonoBehaviour {

	public UnityEngine.UI.Text ScoreText;
	public GameObject Skates;

	// Use this for initialization
	void Start () {
		ScoreText.text = "0";
	}

	void OnTriggerExit2D (Collider2D other) {
		Debug.Log("hi");
		GameObject collider = other.gameObject;
		if (collider.tag == "Cone") {
			Skates.GetComponent<Controls>().score++;
			ScoreText.text = ""+Skates.GetComponent<Controls>().score;
		}
	}
}
