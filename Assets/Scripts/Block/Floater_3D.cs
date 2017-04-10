using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater_3D : MonoBehaviour {

	public float slideSpeed = 10f;
	public float speed = 0.5f;
	public float rotate = 10;
	public GameObject magnet;

	private MeshRenderer meshRenderer;
	private Rigidbody rb;

	private void Awake() {
		meshRenderer = GetComponent<MeshRenderer>();
		rb = GetComponent<Rigidbody>();
	}

	private void Start() {
		rb.velocity = new Vector3(Random.Range(-speed, speed), Random.Range(-speed, speed), 0);
	}

	private void Update() {
		transform.Rotate(0, 0, rotate * Time.deltaTime);

		if(magnet != null) {
			transform.position = Vector3.Lerp(transform.position, magnet.transform.position, slideSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, slideSpeed * Time.deltaTime);
		}

		if (!meshRenderer.isVisible) {
			Destroy(2f);
		}
	}

	private void OnTriggerEnter(Collider other) {
		//Debug.Log(other.gameObject.name);
		if (other.gameObject.name == "TouchableArea") {
			magnet = other.gameObject;
			GetComponent<Meld_3D>().StartConnect(magnet);
		}
	}

	void Destroy(float timeLeft) {
		Destroy(gameObject, timeLeft);
	}

}
