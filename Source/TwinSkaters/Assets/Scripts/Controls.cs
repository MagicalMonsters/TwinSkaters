using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	
	public float speed = 1.0f;
		
	private GameObject leftSkate;
	private GameObject rightSkate;
	private float initialY;
	
	void Start () 
	{
		leftSkate = GameObject.FindWithTag ("LeftSkate");
		rightSkate = GameObject.FindWithTag ("RightSkate");
		initialY = leftSkate.transform.position.y;
	}
	
	void Update () {
		leftSkate.transform.rotation = Quaternion.identity;
		rightSkate.transform.rotation = Quaternion.identity;
		leftSkate.transform.position = new Vector3(leftSkate.transform.position.x, 
				initialY, leftSkate.transform.position.z);
				
		rightSkate.transform.position = new Vector3(rightSkate.transform.position.x, 
				initialY, rightSkate.transform.position.z);
				
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
}
