using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
    public float scrollSpeed;
    private Vector3 startPosition;

    

    void Start ()
    {
        startPosition = transform.position;
        GameObject[] cones = GameObject.FindGameObjectsWithTag ("Cone");        
        foreach (GameObject cone in cones)
        {
            Debug.Log("" + cone);
            ConeController c = cone.GetComponent<ConeController> ();
            Debug.Log("" + c);
            c.SetOnCollision (() => {
               Time.timeScale = 0; 
            });
        }
    }

	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, GetComponent<Renderer>().bounds.size.y - 3f*Camera.main.orthographicSize);
		transform.position = startPosition - Vector3.up * newPosition;
	}
}