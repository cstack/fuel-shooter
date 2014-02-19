using UnityEngine;
using System.Collections;

public class Bullet : DirectionalEntity {

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("Bullet collided with " + collision.gameObject.tag);
		collision.gameObject.SendMessage ("TakeHit");
		Destroy(gameObject);
	}
}
