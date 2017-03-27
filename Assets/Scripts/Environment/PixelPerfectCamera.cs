using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour {
	
	public static float pixelsToUnits = 1f;
	public static float scale = 1f;
	public float timer = 1.0f;
	public float timerMax = 1.0f;

	public Vector2 nativeResolution = new Vector2 (160, 240);

	private Camera cam;
	

	private SpriteRenderer sr;

	void Awake(){
		cam = GetComponent<Camera> ();
		if (cam.orthographic) {
			scale = Screen.height / nativeResolution.y;
			pixelsToUnits *= scale;
			cam.orthographicSize = (Screen.height / 2.0f) / pixelsToUnits;
		}
	}


	/*
	void Update(){

		timer += Time.deltaTime;

		if (timer >= timerMax) {
			timer = timerMax;
		}

		if (timer < timerMax) {
			Camera cam = Camera.main;

			float height = 2f * cam.orthographicSize;
			float width = height * cam.aspect;


			cam.orthographicSize = cam.orthographicSize + (Time.deltaTime / 2);

			leftWall.transform.position = new Vector3(leftWall.transform.position.x - (Time.deltaTime / 3), 0, 0);
			leftWall.transform.localScale = new Vector3 (0.1f, height, 1);

			rightWall.transform.position = new Vector3(rightWall.transform.position.x + (Time.deltaTime / 3), 0, 0);
			rightWall.transform.localScale = new Vector3 (0.1f, height, 1);

			topWall.transform.position = new Vector3(0, topWall.transform.position.y + (Time.deltaTime / 2), 0);
			topWall.transform.localScale = new Vector3 (width, 0.1f, 1);

			bottomWall.transform.position = new Vector3 (0, bottomWall.transform.position.y - (Time.deltaTime / 2), 0);
			bottomWall.transform.localScale = new Vector3 (width, 0.1f, 1);

			if (cam.orthographicSize > 100) {
				cam.orthographicSize = 100;
			}
		}
	}*/
}
