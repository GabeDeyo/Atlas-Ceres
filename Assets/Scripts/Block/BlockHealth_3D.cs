using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHealth_3D : MonoBehaviour {

	[SerializeField]private int health;

	private void Start() {
		if (gameObject.name.Contains("Engine")) {
			health = 5;
		} else if(gameObject.name.Contains("Armor")) {
			health = 3;
		} else {
			health = 1;
		}
	}

	public void TakeDamage(int damage) {
		if(health > 1) {
			health -= damage;
		} else if(health <= 1) {
			Death();
		}
	}

	private void Death() {
		Destroy(gameObject);
	}
}
