using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{    
    private Vector3 startPosition;
    private GameController gameController;
    
    void Start ()
    {
        startPosition = transform.position;
        gameController = GameObject.FindWithTag("GameScript").GetComponent<GameController>();        
    }

	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * gameController.scrollSpeed, GetComponent<Renderer>().bounds.size.y - 3f*Camera.main.orthographicSize);
		transform.position = startPosition - Vector3.up * newPosition;
	}
}