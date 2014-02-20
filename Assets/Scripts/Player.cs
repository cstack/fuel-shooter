using UnityEngine;
using System.Collections;

public class Player : DirectionalEntity {
	public float thrustForce = 10f;
	public float turnSpeed = 10f;
	public float maxFuel = 20f;

	private float _fuel;
	public float fuel { // Seconds of fuel left
		set {
			_fuel = Mathf.Min(value, maxFuel);
			_fuel = Mathf.Max(_fuel, 0f);
			fuelIndicator.percentFull = _fuel / maxFuel;
		}
		get {
			return _fuel;
		}
	}

	public ExhaustParticle exhaustPrefab;
	public FuelIndicator fuelIndicator;

	// Use this for initialization
	void Start () {
		fuel = maxFuel;
		direction = 90;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float thrust = Input.GetAxis ("Vertical");
		if (thrust > 0) {
			rigidbody.AddForce (thrust * DirectionVector() * Time.deltaTime * thrustForce);
			ExhaustParticle particle = Instantiate (exhaustPrefab) as ExhaustParticle;
			particle.transform.position = transform.position;
			particle.direction = direction + 180 + (15 * (Random.value * 2 - 1));
			particle.speed = 10f;

			fuel -= Time.deltaTime;
			if (fuel <= 0) {
				Application.LoadLevel(0);
			}
		}

		float turn = Input.GetAxis ("Horizontal");
		direction += turn * Time.deltaTime * turnSpeed;
	}

	public void TakeHit() {
		fuel -= 1;
	}

	public void RecieveFuel(float amount) {
		fuel += amount;
	}
}
