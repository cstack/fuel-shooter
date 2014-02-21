using UnityEngine;
using System.Collections;

public class Sniper : Engine {
	#region implemented abstract members of Engine
	public override string getName ()
	{
		return "Sniper";
	}
	public override float thrustForce {
		get {
			return 120f;
		}
	}
	public override float coneAngle {
		get {
			return 1f;
		}
	}
	public override float particleSpeed {
		get {
			return 20f;
		}
	}
	public override float burnRate {
		get {
			return 1f;
		}
	}
	#endregion
}
