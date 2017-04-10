using UnityEngine;

public class BuildHybrid1_3D : MonoBehaviour {

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
		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			GenerateHybrid1();
		}
	}

	void GenerateHybrid1() {

		sizeOffset = GameController_3D.instance.blockSize;

		GameObject Hybrid1Object = new GameObject();
		Hybrid1Object.name = "Hybrid1";

		float z = 0;

		GameObject mainEngine = Instantiate(engine, new Vector3(-5, 5, z), Quaternion.identity) as GameObject;
		float posX = mainEngine.transform.position.x;
		float posY = mainEngine.transform.position.y;

		mainEngine.transform.parent = Hybrid1Object.transform;
		mainEngine.tag = "Enemy";
		mainEngine.layer = 11;

		//First Iteration
		GameObject gun1 = Instantiate(gun, new Vector3(posX - sizeOffset, posY, z), Quaternion.identity) as GameObject;
		FixedJoint fj_gun1 = gun1.AddComponent<FixedJoint>();
		fj_gun1.connectedBody = mainEngine.GetComponent<Rigidbody>();
		gun1.transform.parent = Hybrid1Object.transform;
		gun1.tag = "Enemy";
		gun1.layer = 11;

		GameObject booster1 = Instantiate(booster, new Vector3(posX - sizeOffset, posY + sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_boost1 = booster1.AddComponent<FixedJoint>();
		fj_boost1.connectedBody = gun1.GetComponent<Rigidbody>();
		booster1.transform.parent = Hybrid1Object.transform;
		booster1.tag = "Enemy";
		booster1.layer = 11;

		GameObject gun2 = Instantiate(gun, new Vector3(posX + sizeOffset, posY, z), Quaternion.identity) as GameObject;
		FixedJoint fj_gun2 = gun2.AddComponent<FixedJoint>();
		fj_gun2.connectedBody = mainEngine.GetComponent<Rigidbody>();
		gun2.transform.parent = Hybrid1Object.transform;
		gun2.tag = "Enemy";
		gun2.layer = 11;

		GameObject booster2 = Instantiate(booster, new Vector3(posX + sizeOffset, posY + sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_boost2 = booster2.AddComponent<FixedJoint>();
		fj_boost2.connectedBody = gun2.GetComponent<Rigidbody>();
		booster2.transform.parent = Hybrid1Object.transform;
		booster2.tag = "Enemy";
		booster2.layer = 11;

		GameObject armor1 = Instantiate(armor, new Vector3(posX, posY - sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor1 = armor1.AddComponent<FixedJoint>();
		fj_armor1.connectedBody = mainEngine.GetComponent<Rigidbody>();
		armor1.transform.parent = Hybrid1Object.transform;
		armor1.tag = "Enemy";
		armor1.layer = 11;

		GameObject gun3 = Instantiate(gun, new Vector3(posX, posY - sizeOffset * 2, z), Quaternion.identity) as GameObject;
		FixedJoint fj_gun3 = gun3.AddComponent<FixedJoint>();
		fj_gun3.connectedBody = armor1.GetComponent<Rigidbody>();
		gun3.transform.parent = Hybrid1Object.transform;
		gun3.tag = "Enemy";
		gun3.layer = 11;
	}
}
