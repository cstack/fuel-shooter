using UnityEngine;
using System.Collections;

public class ExhaustParticle : DirectionalEntity {
	public float lifespan = 1.5f;
	public void Start() {
		StartCoroutine (DieAfterTime (lifespan));
	}

	void OnCollisionEnter(Collision collision) {
		collision.gameObject.SendMessage ("TakeHit");
		Destroy(gameObject);
	}
}
