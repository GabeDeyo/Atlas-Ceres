using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathe : MonoBehaviour {

	private Vector3 startPos;

	public float amplitude = 10f;
	public float period = 5f;

	void Start () {
		startPos = transform.position;
	}
	
	void Update () {
		float theta = Time.timeSinceLevelLoad / period;
		float distance = amplitude * Mathf.Sin(theta);
		transform.position = startPos + Vector3.up * distance * 2;
	}
}
