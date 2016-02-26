using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {
	

	private Vector3 startPosition;
	private GameController gameController;
	private System.Action onCollision;
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		gameController = GameObject.FindWithTag("GameScript").GetComponent<GameController>();
		sound = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate( new Vector3(0.0f,0.0f,-90.0f) * Time.deltaTime);

		float newPosition = Time.deltaTime * gameController.scrollSpeed;

		if (transform.position.y < -6.0f) {

			transform.position = new Vector3( (Random.value-0.5f) * 11.0f, startPosition.y, transform.position.z);

		}

		transform.position -= Vector3.up * newPosition;
	}

	public void SetOnCollision (System.Action onCollision) 
	{
		this.onCollision = onCollision;
	}

	void OnTriggerEnter2D (Collider2D other) {
		GameObject collider = other.gameObject;
		if (collider.gameObject.tag == "RightSkate" || collider.gameObject.tag == "LeftSkate" ) 
		{
			if (onCollision != null)
			{
				sound.Play();
				onCollision();
				transform.position = new Vector3( (Random.value-0.5f) * 11.0f, startPosition.y, transform.position.z);
			}		
		}	
	}
}
