using System.Collections;
using UnityEngine;

public class Magnet_3D : MonoBehaviour {

	public float lerpTime = 2f;
	public float currentLerpTime;

	public Color magnetColor = new Color(0f, 0.75f, 1f, 150f);
	public Color magnetClear = new Color(0f, 0.75f, 1f, 0f);

	private MeshRenderer meshRenderer;
	[SerializeField]private Magnet_3D magnet;

	private void Awake() {
		meshRenderer = GetComponent<MeshRenderer>();
		magnet = this;
	}

	private void Start() {
		StartCoroutine(checkTag());
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Floater") {
			StopAllCoroutines();
			StartCoroutine(Show());
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag == "Floater") {
			StopAllCoroutines();
			StartCoroutine(Hide());
		}
	}

	private IEnumerator Hide() {
		float startTime = 0f;
		currentLerpTime = 0f;

		while (startTime < lerpTime) {
			currentLerpTime += Time.deltaTime;
			startTime += Time.deltaTime;

			if (currentLerpTime > lerpTime)
				currentLerpTime = lerpTime;

			float percent = currentLerpTime / lerpTime;
			percent = percent * percent * (3f - 2f * percent);
			meshRenderer.material.color = meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, magnetClear, percent);

			yield return null;
		}
	}

	private IEnumerator Show() {
		float startTime = 0f;
		currentLerpTime = 0f;

		while(startTime < lerpTime) {
			currentLerpTime += Time.deltaTime;
			startTime += Time.deltaTime;

			if (currentLerpTime > lerpTime)
				currentLerpTime = lerpTime;

			float percent = currentLerpTime / lerpTime;
			percent = percent * percent * (3f - 2f * percent);
			meshRenderer.material.color = meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, magnetColor, percent);

			yield return null;
		}
	}

	private IEnumerator checkTag() {
		while (true) {
			if (magnet.transform.parent.tag == "Player") {
				magnet.gameObject.SetActive(true);
			} else {
				magnet.gameObject.SetActive(false);
			}
			yield return new WaitForSeconds(1);
		}
	}
}
