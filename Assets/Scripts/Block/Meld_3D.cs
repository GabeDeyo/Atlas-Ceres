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
			Debug.Log(colliders[i]);
			FixedJoint fj = gameObject.AddComponent<FixedJoint>();
			fj.connectedBody = colliders[i].GetComponent<Rigidbody>();
		}

		transform.parent = player.transform;
		gameObject.tag = "Player";
		gameObject.layer = 8;

		//StartCoroutine(stopScript());
		stopScript();
	}

	private void stopScript() {
		//yield return new WaitForSeconds(1);
		transform.rotation = Quaternion.identity;
		GetComponent<Floater_3D>().enabled = false;
		GetComponent<Meld_3D>().enabled = false;
	}
}
