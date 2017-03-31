using UnityEngine;

public class Enter_3D : MonoBehaviour {

	public float initialTime;
	public float slowTime;
	private float timer;

	private Rigidbody rb;

	void Awake() {
		rb = GetComponent<Rigidbody>();
	}

	void Start() {
		timer = initialTime;
	}
	
	void Update () {
		if(timer >= 0) {
			timer -= Time.deltaTime;

			if(timer <= slowTime) {
				rb.AddForce(new Vector2(0, -1), ForceMode.Force);
			}else {
				rb.AddForce(new Vector2(0, 2), ForceMode.Force);
			}
			
			GameController_3D.instance.shipControl = false;
		} else {
			GameController_3D.instance.shipControl = true;
		}

	}
}
