using UnityEngine;
using System.Collections;

public class ConeController : MonoBehaviour {

	private System.Action onCollision;
	
		
	void SetOnCollision (System.Action onCollision) 
	{
		this.onCollision = onCollision;
	}
	
	void OnCollisionEnter (Collision collision) 
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
