using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
    public float scrollSpeed;
    private Vector3 startPosition;

    void Start ()
    {
        startPosition = transform.position;
    }

	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, GetComponent<Renderer>().bounds.size.y - 3f*Camera.main.orthographicSize);
		transform.position = startPosition - Vector3.up * newPosition;
	}
}