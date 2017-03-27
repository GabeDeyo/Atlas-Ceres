using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public float maxSpeed = 10f;
	public float boostForce = 10f;

	private Rigidbody2D rb;

	private void Awake(){
		rb = GetComponent<Rigidbody2D> ();
	}

	public void Move(float horizontal, float vertical, bool boost){
		if (GameController.instance.shipControl == true) {
			rb.velocity = new Vector2 (horizontal * maxSpeed, vertical * maxSpeed);

			if (boost) {
				rb.AddForce (new Vector2 (horizontal * boostForce, vertical * boostForce), ForceMode2D.Impulse);
			}
		}
	}
}
