using System.Collections;
using UnityEngine;

public class Meld_3D : MonoBehaviour {

	public float detectionRadius = 0.6f;

	private int playerMask = 8;
	private GameObject player;

	void Awake() {
		if(GameObject.Find("Player") != null) {
			player = GameObject.Find("Player");
		}
	}

	public void StartConnect(GameObject magnet) {
		StartCoroutine(Connect(magnet));
	}

	private IEnumerator Connect(GameObject magnet) {
		yield return new WaitForSeconds(0.5f);
		
		Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, 1 << playerMask);
		for(var i = 0; i < colliders.Length; i++) {
			FixedJoint fj = gameObject.AddComponent<FixedJoint>();
			fj.connectedBody = colliders[i].GetComponent<Rigidbody>();
		}

		if (transform.name.Contains("Gun")) {
			GetComponent<Gun_3D>().isAttached = true;
		}

		transform.parent = player.transform;
		gameObject.tag = "Player";
		gameObject.layer = 8;

		stopScript();
	}

	private void stopScript() {
		transform.rotation = Quaternion.identity;
		GetComponent<Floater_3D>().enabled = false;
		GetComponent<Meld_3D>().enabled = false;
	}
}
