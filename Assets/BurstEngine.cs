using UnityEngine;
using System.Collections;

public class BurstEngine : Engine {
	#region implemented abstract members of Engine
	public override string getName ()
	{
		return "Burst Engine";
	}
	public override float thrustForce {
		get {
			return 80f;
		}
	}
	public override float coneAngle {
		get {
			return 140f;
		}
	}
	public override float particleSpeed {
		get {
			return 5f;
		}
	}

	public override float burnRate {
		get {
			return 0.5f;
		}
	}
	#endregion
}
