using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_3D : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	void Awake() {
		rb = GetComponent<Rigidbody>();
	}

	void Start () {
		rb.velocity = transform.up * speed;

		Destroy(gameObject, 2f);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			other.GetComponent<BlockHealth_3D>().TakeDamage(1);
			Destroy(gameObject);
		}
	}
}
