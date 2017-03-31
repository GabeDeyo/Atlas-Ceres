using UnityEngine;

public class Expand_2D : MonoBehaviour {

	public float timer = 1f;
	public float timerMax = 1f;

	private GameObject ground1;
	private GameObject ground2;

	void Awake() {
		ground1 = GameObject.Find("Background");
		ground2 = GameObject.Find("Background2");
	}

	void Update() {
		timer += Time.deltaTime;

		if(timer >= timerMax) {
			timer = timerMax;
		}
		if(timer < timerMax) {
			Camera.main.orthographicSize += Time.deltaTime / 5;
			ground1.transform.localScale = new Vector3(3, ground1.transform.localScale.y + Time.deltaTime / 20, 1);
			ground2.transform.localScale = new Vector3(3, ground1.transform.localScale.y + Time.deltaTime / 20, 1);
		}
	}
}
