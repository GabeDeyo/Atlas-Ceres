using UnityEngine;

public class BuildHybrid1 : MonoBehaviour {

	private GameObject engine;
	private GameObject armor;
	private GameObject gun;
	private GameObject booster;

	public float sizeOffset;

	void Awake() {
		engine = (GameObject)Resources.Load("Block/Engine", typeof(GameObject));
		armor = (GameObject)Resources.Load("Block/Armor", typeof(GameObject));
		gun = (GameObject)Resources.Load("Block/Gun", typeof(GameObject));
		booster = (GameObject)Resources.Load("Block/Booster", typeof(GameObject));
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			GenerateHybrid1();
		}
	}

	void GenerateHybrid1() {

		sizeOffset = GameController.instance.blockSize;

		GameObject main = Instantiate(engine, new Vector3(-5, 5, 1), Quaternion.identity) as GameObject;
		float posX = main.transform.position.x;
		float posY = main.transform.position.y;

		main.name = "Hybrid1";


		//First Iteration
		GameObject gun1 = Instantiate(gun, new Vector3(posX - sizeOffset, posY, 1), Quaternion.identity) as GameObject;
		gun1.transform.parent = main.transform;

		GameObject booster1 = Instantiate(booster, new Vector3(posX - sizeOffset, posY + sizeOffset, 1), Quaternion.identity) as GameObject;
		booster1.transform.parent = gun1.transform;

		GameObject gun2 = Instantiate(gun, new Vector3(posX + sizeOffset, posY, 1), Quaternion.identity) as GameObject;
		gun2.transform.parent = main.transform;

		GameObject booster2 = Instantiate(booster, new Vector3(posX + sizeOffset, posY + sizeOffset, 1), Quaternion.identity) as GameObject;
		booster2.transform.parent = gun2.transform;

		GameObject armor1 = Instantiate(armor, new Vector3(posX, posY - sizeOffset, 1), Quaternion.identity) as GameObject;
		armor1.transform.parent = main.transform;

		GameObject gun3 = Instantiate(gun, new Vector3(posX, posY - sizeOffset, 1), Quaternion.identity) as GameObject;
		gun3.transform.parent = armor1.transform;
	}
}
