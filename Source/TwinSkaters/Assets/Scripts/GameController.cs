using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


	public float scrollSpeed = 5.0f;
	// public float scrollSpeedCoefficient = 0.000001f;
	
	public float threshold1 = 10f;
	public float threshold2 = 50f;
	
	public int level1NumberOfCones = 5;
	public int numberOfStars = 2;
	
	public UnityEngine.UI.Text centerText;
	public UnityEngine.UI.Text scoreText;
	public GameObject conePrefab;
	public GameObject starPrefeb;
	
	// private float initialScrollSpeed;
	private bool waitForAnyKeyToRestart = false;
	private GameObject[] cones;
	private GameObject[] stars;
	private int Score;
	private float Score2;

	void Start () {
		// initialScrollSpeed = scrollSpeed;

		Score = 0; 

		float randX, randY;

		stars = new GameObject[numberOfStars];

		for (int i = 0; i < numberOfStars; i++) {
			randX = (Random.value-0.5f) * 7.5f;
			randY =  Random.value * 5 + 5;

			stars [i] = (GameObject)Instantiate (starPrefeb, new Vector3 (randX, randY, 0), Quaternion.identity);
		}

		foreach (GameObject star in stars)
		{        
			StarController s = star.GetComponent<StarController> ();			         
			s.SetOnCollision (() => {
				Score++;
				Score2+=10.0f;
			});
		}
		
		cones = new GameObject[level1NumberOfCones];

		for (int i = 0; i < level1NumberOfCones; i++)
		{
			randX = (Random.value-0.5f) * 11.0f;
			randY =  Random.value * 5 + 5;
			cones[i] = (GameObject) Instantiate(conePrefab,new Vector3 (randX, randY, 0), Quaternion.identity);
		}
		        
        foreach (GameObject cone in cones)
        {        
            ConeController c = cone.GetComponent<ConeController> ();			         
            c.SetOnCollision (() => {
				waitForAnyKeyToRestart = true;
            	Time.timeScale = 0;
				centerText.gameObject.SetActive(true);
            });
        }	
	}
		
	void Update () {
				
		if (threshold1 != 0 && threshold1 < Time.timeSinceLevelLoad)
		{
			threshold1 = 0;
			cones[0].GetComponent<ConeController>().MakeRotated();
			cones[1].GetComponent<ConeController>().MakeRotated();
        } else if (threshold2 != 0 && threshold2 < Time.timeSinceLevelLoad) 
		{
			threshold2 = 0;
			cones[1].GetComponent<ConeController>().MakeUnstable();
		}	
		
		// handle gameover case
		if (waitForAnyKeyToRestart)
		{
			if (Input.GetKeyDown("return")) {
				waitForAnyKeyToRestart = false;
				Application.LoadLevel(0);
				Time.timeScale = 1;
				centerText.gameObject.SetActive(false);
			}
		}
		else{
			Score2+=Time.deltaTime;
			scoreText.text = "Score:\n"+(int)Score2;
		}

		
		scrollSpeed += 0.001f;
	}
}
