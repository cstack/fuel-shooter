﻿using UnityEngine;
using System.Collections;

public class Bullet : DirectionalEntity {
	public float lifespan = 3f;

	public void Start() {
		StartCoroutine (DieAfterTime(lifespan));
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("Bullet collided with " + collision.gameObject.tag);
		collision.gameObject.SendMessage ("TakeHit");
		Destroy(gameObject);
	}
}
