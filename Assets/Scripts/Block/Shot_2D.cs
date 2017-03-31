using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_2D : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Start () {
		rb.velocity = transform.up * speed;

		Destroy(gameObject, 2f);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.layer == 11) {
			Destroy(this.gameObject);
			Destroy(other.gameObject);
		}
	}
}
