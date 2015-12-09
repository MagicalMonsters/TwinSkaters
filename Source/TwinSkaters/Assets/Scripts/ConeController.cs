using UnityEngine;
using System.Collections;

public class ConeController : MonoBehaviour {


	public float scrollSpeed;
	private System.Action onCollision;
	private Vector3 startPosition;

	void Start ()
	{
		startPosition = transform.position;
	}

	void Update ()
	{
		float newPosition = Time.deltaTime * scrollSpeed;
		if (transform.position.y < -5.0f) {
			transform.position = new Vector3( (Random.value-0.5f)*11.0f, startPosition.y, transform.position.z);
		}
		transform.position -= Vector3.up * newPosition;
	}
		
	public void SetOnCollision (System.Action onCollision) 
	{
		this.onCollision = onCollision;
	}
	
	void OnCollisionEnter2D (Collision2D collision) 
	{
		if (collision.gameObject.tag == "RightSkate" || collision.gameObject.tag == "LeftSkate" ) 
		{
			if (onCollision != null)
			{
				onCollision();
				onCollision = null;
			}		
		}		
	}
}
