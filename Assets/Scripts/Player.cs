using UnityEngine;
using System.Collections;

public class Player : DirectionalEntity {
	public float turnSpeed = 10f;
	public float maxFuel = 20f;
	public Engine startEngine;

	private Engine _engine;
	public Engine engine {
		set {
			if (_engine != null) {
				Destroy(_engine.gameObject);
			}
			_engine = Instantiate(value) as Engine;
			_engine.direction = direction;
			_engine.transform.position = transform.position - DirectionVector() * 0.5f;
			_engine.transform.parent = transform;
			hud.currentEngine = _engine;
		}
		get {
			return _engine;
		}
	}

	private float _fuel;
	public float fuel { // Seconds of fuel left
		set {
			_fuel = Mathf.Min(value, maxFuel);
			_fuel = Mathf.Max(_fuel, 0f);
			hud.percentFuel = _fuel / maxFuel;
			if (_fuel <= 0) {
				OnOutOfFuel();
			}
		}
		get {
			return _fuel;
		}
	}

	public ExhaustParticle exhaustPrefab;
	public HUD hud;

	// Use this for initialization
	void Start () {
		fuel = maxFuel;
		direction = 90;
		engine = startEngine;
		hud.currentEngine = engine;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float thrust = Input.GetAxis ("Vertical");
		if (thrust > 0) {
			rigidbody.AddForce (thrust * DirectionVector() * Time.deltaTime * engine.thrustForce);
			ExhaustParticle particle = Instantiate (exhaustPrefab) as ExhaustParticle;
			particle.transform.position = transform.position - DirectionVector();
			particle.direction = direction + 180 + (engine.coneAngle * (Random.value * 2 - 1));
			particle.speed = engine.particleSpeed;

			fuel -= Time.deltaTime * engine.burnRate;
		}

		float turn = Input.GetAxis ("Horizontal");
		direction += turn * Time.deltaTime * turnSpeed;

		hud.score += Time.deltaTime;
	}

	public void OnOutOfFuel() {
		Application.LoadLevel(0);
	}

	public void TakeHit() {
		fuel -= 1;
	}

	public void RecieveFuel(float amount) {
		fuel += amount;
	}

	public void RecieveEngine(Engine newEngine) {
		engine = newEngine;
	}
}
