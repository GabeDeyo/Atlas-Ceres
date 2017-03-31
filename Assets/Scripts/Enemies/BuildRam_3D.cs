using UnityEngine;

public class BuildRam_3D : MonoBehaviour {

	private GameObject engine;
	private GameObject armor;
	private GameObject booster;

	public float sizeOffset;

	void Awake() {
		engine = (GameObject)Resources.Load("Block/Engine_3D", typeof(GameObject));
		armor = (GameObject)Resources.Load("Block/Armor_3D", typeof(GameObject));
		booster = (GameObject)Resources.Load("Block/Booster_3D", typeof(GameObject));
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			GenerateRam();
		}
	}

	void GenerateRam() {

		sizeOffset = GameController_3D.instance.blockSize;

		GameObject main = Instantiate(engine, new Vector3(-5, 0, 1), Quaternion.identity) as GameObject;
		float posX = main.transform.position.x;
		float posY = main.transform.position.y;

		main.name = "Ram";
		main.layer = 11;

		//First Iteration
		GameObject booster1 = Instantiate(booster, new Vector3(posX, posY + sizeOffset, 1), Quaternion.identity) as GameObject;
		booster1.transform.parent = main.transform;
		booster1.layer = 11;

		GameObject armor1 = Instantiate(armor, new Vector3(posX - sizeOffset, posY, 1), Quaternion.identity) as GameObject;
		armor1.transform.parent = main.transform;
		armor1.layer = 11;

		GameObject armor2 = Instantiate(armor, new Vector3(posX + sizeOffset, posY, 1), Quaternion.identity) as GameObject;
		armor2.transform.parent = main.transform;
		armor2.layer = 11;

		GameObject armor3 = Instantiate(armor, new Vector3(posX, posY - sizeOffset, 1), Quaternion.identity) as GameObject;
		armor3.transform.parent = main.transform;
		armor3.layer = 11;

		GameObject armor4 = Instantiate(armor, new Vector3(posX - sizeOffset, posY - sizeOffset, 1), Quaternion.identity) as GameObject;
		armor4.transform.parent = armor3.transform;
		armor4.layer = 11;

		GameObject armor5 = Instantiate(armor, new Vector3(posX + sizeOffset, posY - sizeOffset, 1), Quaternion.identity) as GameObject;
		armor5.transform.parent = armor3.transform;
		armor5.layer = 11;
	}
}
