using UnityEngine;
using System.Collections;

public class Ship_3D : MonoBehaviour {

	public float maxSpeed = 10f;
	public float boostForce = 10f;

	private Rigidbody rb;

	private void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	public void Move(float horizontal, float vertical, bool boost){
		if (GameController_3D.instance.shipControl == true) {
			rb.velocity = new Vector2 (horizontal * maxSpeed, vertical * maxSpeed);

			if (boost) {
				rb.AddForce (new Vector3 (horizontal * boostForce, vertical * boostForce, 0f), ForceMode.Impulse);
				//rb.MovePosition(new Vector3(horizontal * boostForce, vertical * boostForce, 0f));
			}
		}
	}
}
