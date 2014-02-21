using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform poi;
	public float u = 0.4f;
	public HUD hud;

	public Enemy enemyPrefab;
	public Engine[] enginePrefabs;
	public EnginePickup enginePickupPrefab;

	//private Enemy closestEnemy;

	public void Start() {
		StartCoroutine (SpawnEnemies ());
		StartCoroutine (SpawnPowerups ());
	}

	private Enemy ClosestEnemy() {
		Enemy closest = null;
		float closestDistance = 0f;
		foreach (Enemy enemy in GameObject.FindObjectsOfType<Enemy> ()) {
			float distance = (poi.position - enemy.transform.position).magnitude;
			if (closest == null || distance < closestDistance) {
				closest = enemy;
				closestDistance = distance;
			}
		}
		return closest;
	}

	public IEnumerator SpawnEnemies() {
		while (true) {
			float spawnTime = 5f - 0.5f * Mathf.Log10(hud.score + 1);
			yield return new WaitForSeconds (spawnTime);
			Enemy enemy = Instantiate (enemyPrefab) as Enemy;
			enemy.transform.position = new Vector3 (poi.position.x + 50 * (Random.value*2 - 1), poi.position.y + 50 * (Random.value*2 - 1), 0);
		}
	}

	public IEnumerator SpawnPowerups() {
		while (true) {
			float powerupTime = 20f - Mathf.Log10(hud.score + 1);
			yield return new WaitForSeconds (powerupTime);
			EnginePickup enginePickup = Instantiate (enginePickupPrefab) as EnginePickup;
			enginePickup.transform.position = new Vector3 (poi.position.x + 30 * (Random.value*2 - 1), poi.position.y + 30 * (Random.value*2 - 1), 0);
			int engineType = Random.Range(0,enginePrefabs.Length);
			Engine engine = Instantiate(enginePrefabs[engineType]) as Engine;
			enginePickup.engine = engine;
			engine.transform.position = enginePickup.transform.position;
			engine.transform.parent = enginePickup.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float currentX = transform.position.x;
		float currentY = transform.position.y;
		float newX = (1 - u) * currentX + u * poi.position.x;
		float newY = (1 - u) * currentY + u * poi.position.y;
		transform.position = new Vector3 (newX, newY, transform.position.z);
	}


}
