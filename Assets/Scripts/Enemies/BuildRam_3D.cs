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

		GameObject RamObject = new GameObject();
		RamObject.name = "Ram";

		GameObject mainEngine = Instantiate(engine, new Vector3(-5, 0, 0), Quaternion.identity) as GameObject;
		float posX = mainEngine.transform.position.x;
		float posY = mainEngine.transform.position.y;
		float z = 0;

		mainEngine.transform.parent = RamObject.transform;
		mainEngine.tag = "Enemy";
		mainEngine.layer = 11;

		//First Iteration
		GameObject booster1 = Instantiate(booster, new Vector3(posX, posY + sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_boost1 = booster1.AddComponent<FixedJoint>();
		fj_boost1.connectedBody = mainEngine.GetComponent<Rigidbody>();
		booster1.transform.parent = RamObject.transform;
		booster1.tag = "Enemy";
		booster1.layer = 11;

		GameObject armor1 = Instantiate(armor, new Vector3(posX - sizeOffset, posY, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor1 = armor1.AddComponent<FixedJoint>();
		fj_armor1.connectedBody = mainEngine.GetComponent<Rigidbody>();
		armor1.transform.parent = RamObject.transform;
		armor1.tag = "Enemy";
		armor1.layer = 11;

		GameObject armor2 = Instantiate(armor, new Vector3(posX + sizeOffset, posY, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor2 = armor2.AddComponent<FixedJoint>();
		fj_armor2.connectedBody = mainEngine.GetComponent<Rigidbody>();
		armor2.transform.parent = RamObject.transform;
		armor2.tag = "Enemy";
		armor2.layer = 11;

		GameObject armor3 = Instantiate(armor, new Vector3(posX, posY - sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor3 = armor3.AddComponent<FixedJoint>();
		fj_armor3.connectedBody = mainEngine.GetComponent<Rigidbody>();
		armor3.transform.parent = RamObject.transform;
		armor3.tag = "Enemy";
		armor3.layer = 11;

		GameObject armor4 = Instantiate(armor, new Vector3(posX - sizeOffset, posY - sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor4_a = armor4.AddComponent<FixedJoint>();
		fj_armor4_a.connectedBody = armor2.GetComponent<Rigidbody>();
		FixedJoint fj_armor4_b = armor4.AddComponent<FixedJoint>();
		fj_armor4_b.connectedBody = armor3.GetComponent<Rigidbody>();
		armor4.transform.parent = RamObject.transform;
		armor4.tag = "Enemy";
		armor4.layer = 11;

		GameObject armor5 = Instantiate(armor, new Vector3(posX + sizeOffset, posY - sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor5_a = armor5.AddComponent<FixedJoint>();
		fj_armor5_a.connectedBody = armor2.GetComponent<Rigidbody>();
		FixedJoint fj_armor5_b = armor5.AddComponent<FixedJoint>();
		fj_armor5_b.connectedBody = armor3.GetComponent<Rigidbody>();
		armor5.transform.parent = RamObject.transform;
		armor5.tag = "Enemy";
		armor5.layer = 11;
	}
}
