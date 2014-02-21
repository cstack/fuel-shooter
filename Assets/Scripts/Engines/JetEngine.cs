using UnityEngine;
using System.Collections;

public class JetEngine : Engine {

	#region implemented abstract members of Engine

	public override float thrustForce {
		get {
			return 650f;
		}
	}

	public override float coneAngle {
		get {
			return 8f;
		}
	}

	public override float particleSpeed {
		get {
			return 15f;
		}
	}

	public override string getName ()
	{
		return "Jet Engine";
	}

	public override float burnRate {
		get {
			return 2f;
		}
	}

	#endregion
}
