using UnityEngine;
using System.Collections;

public class EntityBase : MonoBehaviour {
	public IEnumerator DieAfterTime(float seconds) {
		yield return new WaitForSeconds(seconds);
		Destroy (gameObject);
	}
}
