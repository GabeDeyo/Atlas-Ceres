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

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.layer == 11) {
			Destroy(this.gameObject);
			Destroy(other.gameObject);
		}
	}
}
