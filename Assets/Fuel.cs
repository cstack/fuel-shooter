using UnityEngine;
using System.Collections;

public class Fuel : MonoBehaviour {
	public float initialAmount = 5f;
	public static float lifespan = 30f;
	public float timeLeft = lifespan;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		float percentLeft = timeLeft / lifespan;
		transform.localScale = new Vector3 (percentLeft, percentLeft, percentLeft);
		if (timeLeft <= 0) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		float percentLeft = timeLeft / lifespan;
		other.gameObject.SendMessage ("RecieveFuel", initialAmount * percentLeft);
		Destroy(gameObject);
	}
}
