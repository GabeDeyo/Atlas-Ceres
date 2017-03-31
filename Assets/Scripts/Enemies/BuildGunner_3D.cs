using UnityEngine;

public class BuildGunner_3D : MonoBehaviour {

	private GameObject engine;
	private GameObject gun;
	private GameObject booster;

	private float sizeOffset;

	void Awake() {
		engine = (GameObject)Resources.Load("Block/Engine_3D", typeof(GameObject));
		gun = (GameObject)Resources.Load("Block/Gun_3D", typeof(GameObject));
		booster = (GameObject)Resources.Load("Block/Booster_3D", typeof(GameObject));
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			GenerateGunner();
		}
	}

	void GenerateGunner() {

		sizeOffset = GameController_3D.instance.blockSize;

		GameObject RamObject = new GameObject();
		RamObject.name = "Gunner";

		GameObject mainEngine = Instantiate(engine, new Vector3(5, 0, 0), Quaternion.identity) as GameObject;
		float posX = mainEngine.transform.position.x;
		float posY = mainEngine.transform.position.y;
		float z = 0;

		mainEngine.name = "Engine";
		mainEngine.transform.parent = RamObject.transform;

		//First Iteration
		GameObject booster1 = Instantiate(booster, new Vector3(posX, posY + sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_boost1 = booster1.AddComponent<FixedJoint>();
		fj_boost1.connectedBody = mainEngine.GetComponent<Rigidbody>();
		booster1.transform.parent = RamObject.transform;

		GameObject gun1 = Instantiate(gun, new Vector3(posX - sizeOffset, posY, z), Quaternion.identity) as GameObject;
		FixedJoint fj_gun1 = gun1.AddComponent<FixedJoint>();
		fj_gun1.connectedBody = mainEngine.GetComponent<Rigidbody>();
		gun1.transform.parent = RamObject.transform;

		GameObject gun2 = Instantiate(gun, new Vector3(posX - sizeOffset * 2, posY, z), Quaternion.identity) as GameObject;
		FixedJoint fj_gun2 = gun2.AddComponent<FixedJoint>();
		fj_gun2.connectedBody = gun1.GetComponent<Rigidbody>();
		gun2.transform.parent = RamObject.transform;

		GameObject gun3 = Instantiate(gun, new Vector3(posX + sizeOffset, posY, z), Quaternion.identity) as GameObject;
		FixedJoint fj_gun3 = gun3.AddComponent<FixedJoint>();
		fj_gun3.connectedBody = mainEngine.GetComponent<Rigidbody>();
		gun3.transform.parent = RamObject.transform;

		GameObject gun4 = Instantiate(gun, new Vector3(posX + sizeOffset * 2, posY, z), Quaternion.identity) as GameObject;
		FixedJoint fj_gun4 = gun4.AddComponent<FixedJoint>();
		fj_gun4.connectedBody = gun3.GetComponent<Rigidbody>();
		gun4.transform.parent = RamObject.transform;

		GameObject gun5 = Instantiate(gun, new Vector3(posX, posY - sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_gun5 = gun5.AddComponent<FixedJoint>();
		fj_gun5.connectedBody = mainEngine.GetComponent<Rigidbody>();
		gun5.transform.parent = RamObject.transform;

		//First Iteration
		/*
		GameObject gun5 = Instantiate(gun, new Vector3(posX, posY - sizeOffset, z), Quaternion.identity) as GameObject;
		gun5.transform.parent = mainEngine.transform;
		*/
	}
}
