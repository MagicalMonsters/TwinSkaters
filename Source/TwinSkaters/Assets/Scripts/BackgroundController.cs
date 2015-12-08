using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
    public float scrollSpeed;
	private GameObject[] cones;
    private Vector3 startPosition;

    void Start ()
    {
        startPosition = transform.position;
		if(cones == null)
			cones = GameObject.FindGameObjectsWithTag ("cone");
    }

	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, GetComponent<Renderer>().bounds.size.y - 3f*Camera.main.orthographicSize);
		if (transform.position.y < (startPosition - Vector3.up * newPosition).y) {
			foreach(GameObject cone in cones){
				float ny = cone.transform.position.y;
				cone.transform.position = new Vector3( (Random.value-0.5f)*7.0f, ny, 0.0f);
			}
		}
		transform.position = startPosition - Vector3.up * newPosition;
	}
}