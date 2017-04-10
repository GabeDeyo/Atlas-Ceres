using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_3D : MonoBehaviour {

	private GameObject shot;

	public Transform shotSpawn;
	public float fireRate;
	public float nextFire;
	public bool isAttached = false;

	void Awake() {
		shot = (GameObject)Resources.Load("Block/Bolt_3D", typeof(GameObject));
	}

	private void Start() {
		if(transform.tag == "Player") {
			shot.tag = "Player";
			shot.layer = 8;
		}else {
			shot.tag = "Enemy";
			shot.layer = 11;
		}
	}

	void Update() {
		if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire && isAttached && GameController_3D.instance.shipControl) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

}
