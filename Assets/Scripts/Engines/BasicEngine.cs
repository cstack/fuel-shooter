using UnityEngine;
using System.Collections;

public class BasicEngine : Engine {
	#region implemented abstract members of Engine

	public override float thrustForce {
		get {
			return 300f;
		}
	}

	public override float coneAngle {
		get {
			return 15;
		}
	}

	public override float particleSpeed {
		get {
			return 10f;
		}
	}

	public override string getName ()
	{
		return "Basic Engine";
	}

	public override float burnRate {
		get {
			return 1f;
		}
	}
	#endregion
}
