using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater_2D : MonoBehaviour {

	public float slideSpeed;
	public float overTime;

	private MeshRenderer meshRenderer;

	private void Awake() {
		meshRenderer = GetComponent<MeshRenderer>();
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Player") {

			ContactPoint contact = collision.contacts[0];

			transform.parent = collision.transform;

			StartCoroutine(MoveObject(contact, collision.transform, slideSpeed));

			transform.rotation = collision.transform.rotation;
		}
	}

	IEnumerator FadeOut(float overTime) {

		float startTime = Time.time;

		while(Time.time < startTime + overTime) {
			//Fade object to nothing


			yield return null;
		}
		yield return new WaitForSeconds(overTime);
		Destroy(2f);
	}

	IEnumerator MoveObject(ContactPoint contactPoint, Transform target, float overTime) {
		//transform.GetComponent<CapsuleCollider>().enabled = false;

		Vector3 desiredPos = new Vector3(target.transform.localPosition.x, target.transform.localPosition.y + 1, target.transform.localPosition.z);

		float startTime = Time.time;
		while (Time.time < startTime + overTime) {
			transform.position = Vector3.Lerp(transform.position, desiredPos, (Time.time - startTime) / overTime);
			yield return null;
		}
		transform.position = desiredPos;
	}

	void Destroy(float timeLeft) {
		Destroy(gameObject, timeLeft);
	}

}
