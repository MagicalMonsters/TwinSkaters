using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float scrollSpeed = 5.0f;
	public UnityEngine.UI.Text centerText;
	
	private bool waitForAnyKeyToRestart = false;

	void Start () {
		GameObject[] cones = GameObject.FindGameObjectsWithTag ("Cone");        
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
		if (waitForAnyKeyToRestart)
		{
			if (Input.anyKey) {
				waitForAnyKeyToRestart = false;
				Application.LoadLevel(0);
				Time.timeScale = 1;
				centerText.gameObject.SetActive(false);
			}
		}
	}
}
