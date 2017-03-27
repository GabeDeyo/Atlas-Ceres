using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Ship))]
public class ShipController : MonoBehaviour {

	private Ship ship;
	private bool boost;

	private void Awake () {
		ship = GetComponent<Ship>();

	}

	private void Update () {
		if (!boost) {
			//boost = CrossPlatformInputManager.GetButtonDown ("Boost");
			boost = Input.GetKey (KeyCode.Space);
		}
	}

	private void FixedUpdate(){
		//float horizontal = CrossPlatformInputManager.GetAxis ("Horizontal");
		//float vertical = CrossPlatformInputManager.GetAxis ("Vertical");

		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		ship.Move (horizontal, vertical, boost);
		boost = false;
	}
}
