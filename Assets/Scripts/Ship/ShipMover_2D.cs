using UnityEngine;

public class ShipMover_2D : MonoBehaviour {

	public float speed;
	public float tilt;

	private Rigidbody rb;

	private void Awake() {
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);

		rb.velocity = movement * speed;
		rb.rotation = Quaternion.Euler(rb.velocity.y * tilt, rb.velocity.x * -tilt, 0f);
	}
}
