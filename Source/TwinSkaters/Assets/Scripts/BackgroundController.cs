using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeY;
	private GameObject[] cones;
	public float obsResetTime;
	private float timer;

    private Vector3 startPosition;

    void Start ()
    {
        startPosition = transform.position;
		timer = obsResetTime;
		if(cones == null)
			cones = GameObject.FindGameObjectsWithTag ("cone");
    }

    void Update ()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector3.up * newPosition;
		timer -= Time.deltaTime;
		if (timer <= 0.0f) {
			timer = obsResetTime;
			foreach(GameObject cone in cones){
				cone.SetActive(true);
				float ny = transform.position.y;
				cone.transform.position = new Vector3( (Random.value-0.5f)*7.0f, ny, 0.0f);
			}
		}
    }
}