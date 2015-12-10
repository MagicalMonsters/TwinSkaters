using UnityEngine;
using System.Collections;

public class ConeController : MonoBehaviour {

	public Sprite orangeCone;
	public Sprite redCone;
	
	public float spriteSwitchDuration = 0.3f;

	private System.Action onCollision;
	private Vector3 startPosition;
	private GameController gameController;
	private SpriteRenderer spriteRenderer;
	
	private bool shouldRemove = false;
	private bool isRotated = false;
	private bool isUnstable = false;
	private float spriteSwitchTime = 0f;
	private bool spriteSwitchState = false;

	void Start ()
	{
		startPosition = transform.position;
		gameController = GameObject.FindWithTag("GameScript").GetComponent<GameController>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update ()
	{		
		if (isUnstable) 
		{
			SpriteAnimation();	
		}		
		float newPosition = Time.deltaTime * gameController.scrollSpeed;
		if (transform.position.y < -6.0f) {
			if (shouldRemove) {
				gameController = null;
				Destroy(gameObject);
				return;
			}
			if (isRotated) {
				transform.Rotate(0,0,Random.Range(0,360));
			} else if (isUnstable) {
				
			}
			
			transform.position = new Vector3( (Random.value-0.5f) * 11.0f, startPosition.y, transform.position.z);
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
	
	public void Remove () 
	{
			shouldRemove = true;
	}
	
	public void MakeRotated ()
	{
		isRotated = true;
	}
	
	public void MakeUnstable ()
	{
		isUnstable = true;
	}
	
	private void SpriteAnimation () {
		spriteSwitchTime += Time.deltaTime;
		if (spriteSwitchTime > spriteSwitchDuration) {
			spriteSwitchTime = 0;
			spriteRenderer.sprite = (spriteSwitchState) ? redCone : orangeCone;
			spriteSwitchState = !spriteSwitchState;
		}
	}
}
