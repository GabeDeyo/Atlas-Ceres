using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	private Rigidbody2D rb;

	void Awake () {
		rb = GetComponent<Rigidbody2D>();
	}

	void Start() {
		rb.velocity = new Vector2(0, GameController.instance.scrollSpeed);
	}
	
	void Update () {
		if (GameController.instance.gameOver) {
			rb.velocity = Vector2.zero;
		}
	}
}
