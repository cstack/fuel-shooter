using UnityEngine;
using System.Collections;

public class BigEngine : Engine {
	#region implemented abstract members of Engine
	public override string getName ()
	{
		return "Big Engine";
	}
	public override float thrustForce {
		get {
			return 500f;
		}
	}
	public override float coneAngle {
		get {
			return 45f;
		}
	}
	public override float particleSpeed {
		get {
			return 15f;
		}
	}
	public override float burnRate {
		get {
			return 1.5f;
		}
	}
	#endregion
}
