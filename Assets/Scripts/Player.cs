using UnityEngine;
using System.Collections;

public class Player : DirectionalEntity {
	public float thrustForce = 10f;
	public float turnSpeed = 10f;

	public ExhaustParticle exhaustPrefab;

	// Use this for initialization
	void Start () {
		direction = 90;
	}
	
	// Update is called once per frame
	void Update () {
		float thrust = Input.GetAxis ("Vertical");
		if (thrust > 0) {
			rigidbody.AddForce (thrust * DirectionVector() * Time.deltaTime * thrustForce);
			ExhaustParticle particle = Instantiate (exhaustPrefab) as ExhaustParticle;
			particle.transform.position = transform.position;
			particle.direction = direction + 180 + (15 * (Random.value * 2 - 1));
			particle.speed = 10f;
		}

		float turn = Input.GetAxis ("Horizontal");
		direction += turn * Time.deltaTime * turnSpeed;
	}

	public void TakeHit() {
		
	}
}
