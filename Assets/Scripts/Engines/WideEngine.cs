using UnityEngine;
using System.Collections;

public class WideEngine : Engine {

	#region implemented abstract members of Engine

	public override float thrustForce {
		get {
			return 250f;
		}
	}

	public override float coneAngle {
		get {
			return 90f;
		}
	}

	public override float particleSpeed {
		get {
			return 6f;
		}
	}

	public override string getName ()
	{
		return "Fan Engine";
	}

	public override float burnRate {
		get {
			return 0.8f;
		}
	}

	#endregion
}
