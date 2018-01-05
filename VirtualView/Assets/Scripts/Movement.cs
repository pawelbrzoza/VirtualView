using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public bool zooming;
	public float zoomSpeed;
	public Camera camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (zooming) {
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			float zoomDistance = zoomSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
			camera.transform.Translate(ray.direction * zoomDistance, Space.World);
		}
	}
}
