using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	
	public float speed = 1.0f;
		
	private GameObject leftSkate;
	private GameObject rightSkate;
	
	
	void Start () 
	{
		leftSkate = GameObject.FindWithTag ("LeftSkate");
		rightSkate = GameObject.FindWithTag ("RightSkate");
	}
	
	void FixedUpdate ()
	{
		Vector3 leftSkateMove = Vector3.zero;
		Vector3 rightSkateMove = Vector3.zero;
		if (Input.GetKey ("right")) {										
			leftSkateMove = new Vector3(1,0,0) * speed * Time.deltaTime;
			rightSkateMove = leftSkateMove;			
		} 
		if (Input.GetKey ("left")) {
			leftSkateMove = new Vector3(-1,0,0) * speed * Time.deltaTime;
			rightSkateMove = leftSkateMove;			
		}
		 
		if (Input.GetKey ("up")) {
			leftSkateMove += new Vector3(-1,0,0) * speed * Time.deltaTime;
			rightSkateMove += new Vector3(1,0,0) * speed * Time.deltaTime;			
		} 
		if (Input.GetKey ("down")) {
			leftSkateMove += new Vector3(1,0,0) * speed * Time.deltaTime;
			rightSkateMove += new Vector3(-1,0,0) * speed * Time.deltaTime;			
		}
		
		if (leftSkateMove != Vector3.zero) {
			leftSkate.transform.Translate(leftSkateMove);	
		}
		if (rightSkateMove != Vector3.zero) {
			rightSkate.transform.Translate(rightSkateMove);
		}
		
	}

	
	
	// Update is called once per frame
	void Update () {
	
	}
}
