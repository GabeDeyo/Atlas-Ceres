using UnityEngine;

public class Enter_2D : MonoBehaviour {

	public float initialTime;
	public float slowTime;
	private float timer;

	private Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Start() {
		timer = initialTime;
	}
	
	void Update () {
		if(timer >= 0) {
			timer -= Time.deltaTime;

			if(timer <= slowTime) {
				rb.AddForce(new Vector2(0, -1), ForceMode2D.Force);
			}else {
				rb.AddForce(new Vector2(0, 2), ForceMode2D.Force);
			}
			
			GameController_2D.instance.shipControl = false;
		} else {
			GameController_2D.instance.shipControl = true;
		}

	}
}
