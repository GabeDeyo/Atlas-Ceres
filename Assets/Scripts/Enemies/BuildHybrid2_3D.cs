using UnityEngine;

public class BuildHybrid2_3D : MonoBehaviour {

	private GameObject engine;
	private GameObject armor;
	private GameObject gun;
	private GameObject booster;

	public float sizeOffset;

	void Awake() {
		engine = (GameObject)Resources.Load("Block/Engine_3D", typeof(GameObject));
		armor = (GameObject)Resources.Load("Block/Armor_3D", typeof(GameObject));
		gun = (GameObject)Resources.Load("Block/Gun_3D", typeof(GameObject));
		booster = (GameObject)Resources.Load("Block/Booster_3D", typeof(GameObject));
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha5)) {
			GenerateHybrid2();
		}
	}

	void GenerateHybrid2() {

		sizeOffset = GameController_3D.instance.blockSize;

		GameObject main = Instantiate(engine, new Vector3(5, 5, 1), Quaternion.identity) as GameObject;
		float posX = main.transform.position.x;
		float posY = main.transform.position.y;

		main.name = "Hybrid2";


		//First Iteration
		GameObject armor1 = Instantiate(armor, new Vector3(posX - sizeOffset, posY, 1), Quaternion.identity) as GameObject;
		armor1.transform.parent = main.transform;

		GameObject booster1 = Instantiate(booster, new Vector3(posX - sizeOffset, posY + sizeOffset, 1), Quaternion.identity) as GameObject;
		booster1.transform.parent = armor1.transform;


		GameObject armor2 = Instantiate(armor, new Vector3(posX + sizeOffset, posY, 1), Quaternion.identity) as GameObject;
		armor2.transform.parent = main.transform;

		GameObject booster2 = Instantiate(booster, new Vector3(posX + sizeOffset, posY + sizeOffset, 1), Quaternion.identity) as GameObject;
		booster2.transform.parent = armor2.transform;


		GameObject gun1 = Instantiate(gun, new Vector3(posX, posY - sizeOffset, 1), Quaternion.identity) as GameObject;
		gun1.transform.parent = main.transform;

		GameObject armor3 = Instantiate(armor, new Vector3(posX, posY - sizeOffset * 2, 1), Quaternion.identity) as GameObject;
		armor3.transform.parent = gun1.transform;
	}
}
