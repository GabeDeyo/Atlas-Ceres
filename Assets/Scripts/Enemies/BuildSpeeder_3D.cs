using UnityEngine;

public class BuildSpeeder_3D : MonoBehaviour {

	private GameObject engine;
	private GameObject armor;
	private GameObject gun;
	private GameObject booster;

	private float sizeOffset;

	void Awake() {
		engine = (GameObject)Resources.Load("Block/Engine_3D", typeof(GameObject));
		armor = (GameObject)Resources.Load("Block/Armor_3D", typeof(GameObject));
		gun = (GameObject)Resources.Load("Block/Gun_3D", typeof(GameObject));
		booster = (GameObject)Resources.Load("Block/Booster_3D", typeof(GameObject));
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			GenerateSpeeder();
		}
	}

	void GenerateSpeeder() {

		sizeOffset = GameController_3D.instance.blockSize;

		GameObject SpeederObject = new GameObject();
		SpeederObject.name = "Speeder";

		float z = 0;

		GameObject mainEngine = Instantiate(engine, new Vector3(0, 5, z), Quaternion.identity) as GameObject;
		float posX = mainEngine.transform.position.x;
		float posY = mainEngine.transform.position.y;

		mainEngine.transform.parent = SpeederObject.transform;
		mainEngine.tag = "Enemy";
		mainEngine.layer = 11;

		//First Iteration
		GameObject booster1 = Instantiate(booster, new Vector3(posX, posY + sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_boost1 = booster1.AddComponent<FixedJoint>();
		fj_boost1.connectedBody = mainEngine.GetComponent<Rigidbody>();
		booster1.transform.parent = SpeederObject.transform;
		booster1.tag = "Enemy";
		booster1.layer = 11;

		GameObject armor1 = Instantiate(armor, new Vector3(posX - sizeOffset, posY, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor1 = armor1.AddComponent<FixedJoint>();
		fj_armor1.connectedBody = mainEngine.GetComponent<Rigidbody>();
		armor1.transform.parent = SpeederObject.transform;
		armor1.tag = "Enemy";
		armor1.layer = 11;

		GameObject booster2 = Instantiate(booster, new Vector3(posX - sizeOffset, posY + sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_boost2_a = booster2.AddComponent<FixedJoint>();
		fj_boost2_a.connectedBody = armor1.GetComponent<Rigidbody>();
		FixedJoint fj_boost2_b = booster2.AddComponent<FixedJoint>();
		fj_boost2_b.connectedBody = booster1.GetComponent<Rigidbody>();
		booster2.transform.parent = SpeederObject.transform;
		booster2.tag = "Enemy";
		booster2.layer = 11;

		GameObject armor2 = Instantiate(armor, new Vector3(posX + sizeOffset, posY, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor2 = armor2.AddComponent<FixedJoint>();
		fj_armor2.connectedBody = mainEngine.GetComponent<Rigidbody>();
		armor2.transform.parent = SpeederObject.transform;
		armor2.tag = "Enemy";
		armor2.layer = 11;

		GameObject booster3 = Instantiate(booster, new Vector3(posX + sizeOffset, posY + sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_boost3_a = booster3.AddComponent<FixedJoint>();
		fj_boost3_a.connectedBody = booster1.GetComponent<Rigidbody>();
		FixedJoint fj_boost3_b = booster3.AddComponent<FixedJoint>();
		fj_boost3_b.connectedBody = armor2.GetComponent<Rigidbody>();
		booster3.transform.parent = SpeederObject.transform;
		booster3.tag = "Enemy";
		booster3.layer = 11;

		GameObject gun1 = Instantiate(gun, new Vector3(posX, posY - sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_gun1 = gun1.AddComponent<FixedJoint>();
		fj_gun1.connectedBody = mainEngine.GetComponent<Rigidbody>();
		gun1.transform.parent = SpeederObject.transform;
		gun1.tag = "Enemy";
		gun1.layer = 11;
	}
}
