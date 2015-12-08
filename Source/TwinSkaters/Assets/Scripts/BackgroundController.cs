using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeY;
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
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
		if (transform.position.y < (startPosition + Vector3.up * newPosition).y) {
			foreach(GameObject cone in cones){
				cone.SetActive(true);
				float ny = transform.position.y;
				cone.transform.position = new Vector3( (Random.value-0.5f)*7.0f, ny, 0.0f);
			}
		}
		transform.position = startPosition + Vector3.up * newPosition;
	}
}