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

		GameObject Hybrid2Object = new GameObject();
		Hybrid2Object.name = "Hybrid2";

		float z = 0;

		GameObject mainEngine = Instantiate(engine, new Vector3(5, 5, z), Quaternion.identity) as GameObject;
		float posX = mainEngine.transform.position.x;
		float posY = mainEngine.transform.position.y;

		mainEngine.transform.parent = Hybrid2Object.transform;
		mainEngine.tag = "Enemy";
		mainEngine.layer = 11;

		//First Iteration
		GameObject armor1 = Instantiate(armor, new Vector3(posX - sizeOffset, posY, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor1 = armor1.AddComponent<FixedJoint>();
		fj_armor1.connectedBody = mainEngine.GetComponent<Rigidbody>();
		armor1.transform.parent = Hybrid2Object.transform;
		armor1.tag = "Enemy";
		armor1.layer = 11;

		GameObject booster1 = Instantiate(booster, new Vector3(posX - sizeOffset, posY + sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_boost1 = booster1.AddComponent<FixedJoint>();
		fj_boost1.connectedBody = armor1.GetComponent<Rigidbody>();
		booster1.transform.parent = Hybrid2Object.transform;
		booster1.tag = "Enemy";
		booster1.layer = 11;

		GameObject armor2 = Instantiate(armor, new Vector3(posX + sizeOffset, posY, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor2 = armor2.AddComponent<FixedJoint>();
		fj_armor2.connectedBody = mainEngine.GetComponent<Rigidbody>();
		armor2.transform.parent = Hybrid2Object.transform;
		armor2.tag = "Enemy";
		armor2.layer = 11;

		GameObject booster2 = Instantiate(booster, new Vector3(posX + sizeOffset, posY + sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_boost2 = booster2.AddComponent<FixedJoint>();
		fj_boost2.connectedBody = armor2.GetComponent<Rigidbody>();
		booster2.transform.parent = Hybrid2Object.transform;
		booster2.tag = "Enemy";
		booster2.layer = 11;

		GameObject gun1 = Instantiate(gun, new Vector3(posX, posY - sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_gun1 = gun1.AddComponent<FixedJoint>();
		fj_gun1.connectedBody = mainEngine.GetComponent<Rigidbody>();
		gun1.transform.parent = Hybrid2Object.transform;
		gun1.tag = "Enemy";
		gun1.layer = 11;

		GameObject armor3 = Instantiate(armor, new Vector3(posX, posY - sizeOffset * 2, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor3 = armor3.AddComponent<FixedJoint>();
		fj_armor3.connectedBody = gun1.GetComponent<Rigidbody>();
		armor3.transform.parent = Hybrid2Object.transform;
		armor3.tag = "Enemy";
		armor3.layer = 11;
	}
}
