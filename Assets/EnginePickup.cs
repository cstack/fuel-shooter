using UnityEngine;
using System.Collections;

public class EnginePickup : EntityBase {
	public Engine engine;

	public void Start() {
		DieAfterTime (30f);
	}

	void OnTriggerEnter(Collider other) {
		other.gameObject.SendMessage ("RecieveEngine", engine);
		Destroy(gameObject);
	}
}
