using UnityEngine;
using System.Collections;

public class FuelSaver : Engine {
	#region implemented abstract members of Engine

	public override string getName ()
	{
		return "Fuel Saver";
	}

	public override float thrustForce {
		get {
			return 200f;
		}
	}

	public override float coneAngle {
		get {
			return 25f;
		}
	}

	public override float particleSpeed {
		get {
			return 4f;
		}
	}

	public override float burnRate {
		get {
			return 0.4f;
		}
	}

	#endregion


}
