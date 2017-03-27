using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	private GameObject shot;

	public Transform shotSpawn;
	public float fireRate;
	public float nextFire;
	public bool isAttached = false;

	void Awake() {
		shot = (GameObject)Resources.Load("Block/Bolt", typeof(GameObject));
		shot.layer = 8;
	}

	void Update() {
		if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire && isAttached && GameController.instance.shipControl) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

}
