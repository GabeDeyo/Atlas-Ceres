using UnityEngine;

public class RepeatingBackground_3D : MonoBehaviour {

	private BoxCollider boxCollider;
	private float neededLength;

	void Awake () {
		boxCollider = GetComponent<BoxCollider>();
	}

	void Start() {
		neededLength = boxCollider.size.x * transform.localScale.x;
	}
	
	void Update () {
		if(transform.position.y < -neededLength) {
			RepositionBackground();
		}
	}

	void RepositionBackground() {
		Vector2 offset = new Vector2(0, neededLength * 2f);
		transform.position = (Vector2)transform.position + offset;
	}
}
