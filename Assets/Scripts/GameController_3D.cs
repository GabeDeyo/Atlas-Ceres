using UnityEngine;

public class GameController_3D : MonoBehaviour {

	public static GameController_3D instance;
	public bool gameOver = false;
	public float scrollSpeed = -3f;
	public bool shipControl;
	public float blockSize;
	public int shipSize;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
	}

	void Start () {
		
	}
	
	void Update () {
		
	}
}
