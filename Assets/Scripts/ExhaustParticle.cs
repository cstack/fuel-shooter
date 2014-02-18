using UnityEngine;
using System.Collections;

public class ExhaustParticle : DirectionalEntity {
	public void Start() {
		StartCoroutine (DieAfterTime (2f));
	}

	public IEnumerator DieAfterTime(float seconds) {
		yield return new WaitForSeconds(seconds);
		Destroy (gameObject);
	}
}
