using UnityEngine;
using System.Collections;

public abstract class Engine : DirectionalEntity {
	abstract public float thrustForce { get; }
	abstract public float coneAngle { get; }
	abstract public float particleSpeed { get; }
	abstract public float burnRate { get; }

	public abstract string getName();
}
