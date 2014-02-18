﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform poi;
	public float u = 0.4f;

	public Enemy enemyPrefab;

	//private Enemy closestEnemy;

	public void Start() {
		StartCoroutine (SpawnEnemies ());
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
			yield return new WaitForSeconds (4f);
			Enemy enemy = Instantiate (enemyPrefab) as Enemy;
			enemy.transform.position = new Vector3 (poi.position.x + 50 * (Random.value*2 - 1), poi.position.y + 50 * (Random.value*2 - 1), 0);
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
