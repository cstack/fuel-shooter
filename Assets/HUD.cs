using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	public GUIText engineName;
	public GUIText scoreLabel;

	private float _score;
	public float score {
		set {
			_score = value;
			scoreLabel.text = "Time Survived: " + Utils.RoundToPlaces(_score, 1);
		}
		get {
			return _score;
		}
	}
	
	private Engine _currentEngine;
	public Engine currentEngine {
		set {
			_currentEngine = value;
			engineName.text = _currentEngine.getName();
		}
		get {
			return _currentEngine;
		}
	}

	private float _fuel = 1;
	public float percentFuel {
		set {
			_fuel = Mathf.Min(value, 1f);
			_fuel = Mathf.Max(_fuel, 0f);
			Vector3 scale = transform.localScale;
			scale.x = _fuel * 20f;
			transform.localScale = scale;
		}
	}


}
