using UnityEngine;
using System.Collections;

public class DirectionalEntity : MonoBehaviour {
	public float direction { // in degrees counterclockwise from Vector3(1,0,0)
		set {
			_direction = value;
			transform.localEulerAngles = new Vector3(0, 0, value - 90);
		}
		get {
			return _direction;
		}
	}

	public float speed {
		set {
			rigidbody.velocity = DirectionVector() * value;
		}
		get {
			return rigidbody.velocity.magnitude;
		}
	}

	private float _direction;

	public Vector3 DirectionVector() {
		float rad = direction * Mathf.Deg2Rad;
		return new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);
	}
}
