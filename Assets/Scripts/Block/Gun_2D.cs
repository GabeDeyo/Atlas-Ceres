using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_2D : MonoBehaviour {

	private GameObject shot;

	public Transform shotSpawn;
	public float fireRate;
	public float nextFire;
	public bool isAttached = false;

	void Awake() {
		shot = (GameObject)Resources.Load("Block/Bolt_2D", typeof(GameObject));
		shot.layer = 8;
	}

	void Update() {
		if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire && isAttached && GameController_2D.instance.shipControl) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

}
