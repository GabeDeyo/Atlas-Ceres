using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTesting : MonoBehaviour {

	public float lerpTime = 1f;
	public float currentLerpTime;

	public float moveDistance = 10f;

	private Vector3 startPos;
	private Vector3 endPos;

	protected void Start() {
		startPos = transform.position;
		endPos = transform.position + transform.right * moveDistance;
	}

	protected void Update() {
		//Reset
		if (Input.GetKeyDown(KeyCode.Space)) {
			currentLerpTime = 0f;
		}

		//Increment timer
		currentLerpTime += Time.deltaTime;
		if (currentLerpTime > lerpTime)
			currentLerpTime = lerpTime;

		//Set Lerp
		float percent = currentLerpTime / lerpTime;

		//Sinerp (ease out)
		//percent = Mathf.Sin(percent * Mathf.PI * 0.5f);

		//Coserp (ease in)
		//percent = 1f - Mathf.Cos(percent * Mathf.PI * 0.5f);

		//Exponential (quadratic)
		//percent = percent * percent;

		//Smoothstep
		//percent = percent * percent * (3f - 2f * percent);

		//Smootherstep
		//percent = percent * percent * percent * (percent * (6f * percent - 15f) + 10f);
		transform.position = Vector3.Lerp(startPos, endPos, percent);
	}
}
