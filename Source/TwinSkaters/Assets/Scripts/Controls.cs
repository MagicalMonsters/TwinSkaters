using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	
	public float speed = 1.0f;
		
	private GameObject leftSkate;
	private GameObject rightSkate;
	private float initialY;
	private int leftSkaterotate;
	private int rightSkaterotate;
	
	void Start () 
	{
		leftSkate = GameObject.FindWithTag ("LeftSkate");
		rightSkate = GameObject.FindWithTag ("RightSkate");
		initialY = leftSkate.transform.position.y;
	}
	
	void Update () {
		Quaternion leftRotation = Quaternion.identity;
		Quaternion rightRotation = Quaternion.identity;
		leftRotation.eulerAngles = new Vector3(0.0f, 0.0f, -12.5f*leftSkaterotate);
		rightRotation.eulerAngles = new Vector3(0.0f, 0.0f, -12.5f*rightSkaterotate);
		leftSkate.transform.rotation = leftRotation;
		rightSkate.transform.rotation = rightRotation;
		leftSkate.transform.position = new Vector3(leftSkate.transform.position.x, 
				initialY, leftSkate.transform.position.z);
				
		rightSkate.transform.position = new Vector3(rightSkate.transform.position.x, 
				initialY, rightSkate.transform.position.z);
				
	}
	
	void FixedUpdate ()
	{
		leftSkaterotate = 0;
		rightSkaterotate = 0;
		Vector3 leftSkateMove = Vector3.zero;
		Vector3 rightSkateMove = Vector3.zero;
		if (Input.GetKey ("right")) {										
			leftSkateMove = new Vector3(1,0,0) * speed * Time.deltaTime;
			rightSkateMove = leftSkateMove;
			leftSkaterotate += 1;
			rightSkaterotate += 1;
		} 
		if (Input.GetKey ("left")) {
			leftSkateMove = new Vector3(-1,0,0) * speed * Time.deltaTime;
			rightSkateMove = leftSkateMove;			
			leftSkaterotate -= 1;
			rightSkaterotate -= 1;
		}
		 
		if (Input.GetKey ("up")) {
			leftSkateMove += new Vector3(-1,0,0) * speed * Time.deltaTime;
			rightSkateMove += new Vector3(1,0,0) * speed * Time.deltaTime;
			leftSkaterotate -= 1;
			rightSkaterotate += 1;
		} 
		if (Input.GetKey ("down")) {
			leftSkateMove += new Vector3(1,0,0) * speed * Time.deltaTime;
			rightSkateMove += new Vector3(-1,0,0) * speed * Time.deltaTime;
			leftSkaterotate += 1;
			rightSkaterotate -= 1;			
		}
		
		if (leftSkateMove != Vector3.zero) {
			leftSkate.transform.Translate(leftSkateMove);	
		}
		if (rightSkateMove != Vector3.zero) {
			rightSkate.transform.Translate(rightSkateMove);
		}	
	}
}
