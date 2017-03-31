using UnityEngine;

public class ScrollingObject_3D : MonoBehaviour {

	private Rigidbody2D rb;

	void Awake () {
		rb = GetComponent<Rigidbody2D>();
	}

	void Start() {
		rb.velocity = new Vector2(0, GameController_3D.instance.scrollSpeed);
	}
	
	void Update () {
		if (GameController_3D.instance.gameOver) {
			rb.velocity = Vector2.zero;
		}
	}
}
