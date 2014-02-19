using UnityEngine;
using System.Collections;

public class FuelIndicator : MonoBehaviour {
	private float _fuel = 1;

	public float percentFull {
		set {
			_fuel = Mathf.Min(value, 1f);
			_fuel = Mathf.Max(_fuel, 0f);
			Vector3 scale = transform.localScale;
			scale.x = _fuel * 20f;
			transform.localScale = scale;
		}
	}
}
