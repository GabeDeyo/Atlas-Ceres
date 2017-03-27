using UnityEngine;

public class BuildGunner : MonoBehaviour {

	private GameObject engine;
	private GameObject gun;
	private GameObject booster;

	public float sizeOffset;

	void Awake() {
		engine = (GameObject)Resources.Load("Block/Engine", typeof(GameObject));
		gun = (GameObject)Resources.Load("Block/Gun", typeof(GameObject));
		booster = (GameObject)Resources.Load("Block/Booster", typeof(GameObject));
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			GenerateGunner();
		}
	}

	void GenerateGunner() {

		sizeOffset = GameController.instance.blockSize;

		GameObject main = Instantiate(engine, new Vector3(5, 0, 1), Quaternion.identity) as GameObject;
		float posX = main.transform.position.x;
		float posY = main.transform.position.y;

		main.name = "Gunner";


		//First Iteration
		GameObject booster1 = Instantiate(booster, new Vector3(posX, posY + sizeOffset, 1), Quaternion.identity) as GameObject;
		booster1.transform.parent = main.transform;

		GameObject gun1 = Instantiate(gun, new Vector3(posX - sizeOffset, posY, 1), Quaternion.identity) as GameObject;
		gun1.transform.parent = main.transform;

		GameObject gun2 = Instantiate(gun, new Vector3(posX - sizeOffset * 2, posY, 1), Quaternion.identity) as GameObject;
		gun2.transform.parent = gun1.transform;

		GameObject gun3 = Instantiate(gun, new Vector3(posX + sizeOffset, posY, 1), Quaternion.identity) as GameObject;
		gun3.transform.parent = main.transform;

		GameObject gun4 = Instantiate(gun, new Vector3(posX + sizeOffset * 2, posY, 1), Quaternion.identity) as GameObject;
		gun4.transform.parent = gun3.transform;

		GameObject gun5 = Instantiate(gun, new Vector3(posX, posY - sizeOffset, 1), Quaternion.identity) as GameObject;
		gun5.transform.parent = main.transform;
	}
}
