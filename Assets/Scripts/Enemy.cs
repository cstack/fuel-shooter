using UnityEngine;
using System.Collections;

public class Enemy : DirectionalEntity {
	public float maxSpeed = 2f;
	public float health = 10f;

	public Bullet bulletPrefab;

	private Player player;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find ("Player");
		player = go.GetComponent<Player> ();
		StartCoroutine (ShootAtPlayer ());
	}

	public IEnumerator ShootAtPlayer() {
		while (true) {
			Vector3 displacement = player.transform.position - transform.position;
			if (displacement.magnitude < 10f) {
				Bullet bullet = Instantiate(bulletPrefab) as Bullet;
				bullet.transform.position = transform.position;
				bullet.direction = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
				bullet.speed = 6f;
			}
			yield return new WaitForSeconds(3f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 displacement = player.transform.position - transform.position;
		direction = Mathf.Atan2 (displacement.y, displacement.x) * Mathf.Rad2Deg;
		speed = maxSpeed;
	}

	public void TakeHit() {
		health -= 1;
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
