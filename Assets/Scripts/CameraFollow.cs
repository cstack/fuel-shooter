using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform poi;
	public float u = 0.4f;

	// Update is called once per frame
	void Update () {

		float currentX = transform.position.x;
		float currentY = transform.position.y;
		float newX = (1 - u) * currentX + u * poi.position.x;
		float newY = (1 - u) * currentY + u * poi.position.y;
		transform.position = new Vector3 (newX, newY, transform.position.z);
	}
}
