using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{    
    private Vector3 startPosition;
    private GameController gameController;
	private float newPosition;
    
    void Start ()
    {
        startPosition = transform.position;
        gameController = GameObject.FindWithTag("GameScript").GetComponent<GameController>();        
    }

	void Update ()
	{
		newPosition = Mathf.Repeat(newPosition + Time.deltaTime * gameController.scrollSpeed, GetComponent<Renderer>().bounds.size.y - 3f*Camera.main.orthographicSize);
		transform.position = startPosition - Vector3.up * newPosition;
	}
}