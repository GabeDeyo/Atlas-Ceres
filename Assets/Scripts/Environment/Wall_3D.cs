using System.Collections;
using UnityEngine;

public class Wall_3D : MonoBehaviour {

	private GameObject wall;
	private IEnumerator coroutine;

	private GameObject LeftWall;
	private GameObject RightWall;
	private GameObject TopWall;
	private GameObject BottomWall;

	private float widthHalf;
	private float heightHalf;

	private float thickness = 0.1f;

	public float backWidth;
	public float backHeight;

	private GameObject Scenery;

	void Awake(){
		wall = (GameObject)Resources.Load("Environment/Wall_3D", typeof(GameObject));
		Scenery = GameObject.Find("Scenery");
	}

	void Start(){

		GetBoundaries();

		widthHalf = backWidth / 2;
		heightHalf = backHeight / 2;

		// Left Wall
		LeftWall = Instantiate (wall, new Vector3 (0 - widthHalf, 0, 0), Quaternion.identity) as GameObject;
		LeftWall.transform.localScale = new Vector3 (thickness, backHeight, 1);
		LeftWall.transform.name = "Left Wall";

		// Right Wall
		RightWall = Instantiate (wall, new Vector3 (0 + widthHalf, 0, 0), Quaternion.identity) as GameObject;
		RightWall.transform.localScale = new Vector3 (thickness, backHeight, 1);
		RightWall.transform.name = "Right Wall";

		// Top Wall
		TopWall = Instantiate (wall, new Vector3 (0, 0 + heightHalf, 0), Quaternion.identity) as GameObject;
		TopWall.transform.localScale = new Vector3 (backWidth, thickness, 1);
		TopWall.transform.name = "Top Wall";

		coroutine = MakeFloor(5f);
		StartCoroutine(coroutine);

		if(Scenery != null) {
			LeftWall.transform.parent = Scenery.transform;
			RightWall.transform.parent = Scenery.transform;
			TopWall.transform.parent = Scenery.transform;
		}
	}

	void Update() {
		if (backHeight != (Camera.main.orthographicSize * 2)) {
			SetWalls();
		}
	}

	void GetBoundaries(){
		backHeight = Camera.main.orthographicSize * 2;
		backWidth = backHeight * Screen.width / Screen.height;
	}

	public void SetWalls() {
		GetBoundaries();

		widthHalf = backWidth / 2;
		heightHalf = backHeight / 2;

		LeftWall.transform.localPosition = new Vector3(0 - widthHalf, 0, 0);
		LeftWall.transform.localScale = new Vector3(thickness, backHeight, 1);

		RightWall.transform.localPosition = new Vector3(0 + widthHalf, 0, 0);
		RightWall.transform.localScale = new Vector3(thickness, backHeight, 1);

		TopWall.transform.localPosition = new Vector3(0, 0 + heightHalf, 0);
		TopWall.transform.localScale = new Vector3(backWidth, thickness, 1);

		BottomWall.transform.localPosition = new Vector3(0, 0 - heightHalf, 0);
		BottomWall.transform.localScale = new Vector3(backWidth, thickness, 1);
	}

	private IEnumerator MakeFloor(float waitTime ) {
		yield return new WaitForSeconds(waitTime);

		// Bottom Wall
		BottomWall = Instantiate(wall, new Vector3(0, 0 - heightHalf, 0), Quaternion.identity) as GameObject;
		BottomWall.transform.localScale = new Vector3(backWidth, thickness, 1);
		BottomWall.transform.name = "Bottom Wall";

		if (Scenery != null) {
			BottomWall.transform.parent = Scenery.transform;
		}
	}
}
