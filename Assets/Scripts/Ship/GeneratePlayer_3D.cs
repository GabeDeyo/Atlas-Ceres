using UnityEngine;
using System.Collections;

public class GeneratePlayer_3D : MonoBehaviour {

	public float startOffset;

	private GameObject engine;
	private GameObject armor;
	private GameObject gun;
	private GameObject booster;

	private float sizeOffset;

	void Awake(){
		engine = (GameObject)Resources.Load ("Block/Engine_3D", typeof(GameObject));
		armor = (GameObject)Resources.Load ("Block/Armor_3D", typeof(GameObject));
		gun = (GameObject)Resources.Load ("Block/Gun_3D", typeof(GameObject));
		booster = (GameObject)Resources.Load ("Block/Booster_3D", typeof(GameObject));

		sizeOffset = engine.GetComponent<BoxCollider>().size.x;
	}

	void Start(){
		InstantiatePlayer ();
		GameController_3D.instance.blockSize = sizeOffset;
	}

	void InstantiatePlayer(){
		float floor = Camera.main.orthographicSize;

		GameObject PlayerObject = new GameObject();
		PlayerObject.name = "Player";

		GameObject mainEngine = Instantiate (engine, new Vector3 (0, -floor - startOffset, 0), Quaternion.identity) as GameObject;
		float posX = mainEngine.transform.position.x;
		float posY = mainEngine.transform.position.y;
		int z = 0;

		mainEngine.transform.parent = PlayerObject.transform;
		
		Enter_3D enter = mainEngine.AddComponent<Enter_3D>();
		enter.initialTime = 5;
		enter.slowTime = 3;

		mainEngine.AddComponent<ShipController_3D>();

		mainEngine.name = "Engine";
		mainEngine.layer = 8;

		GameObject gun1 = Instantiate(gun, new Vector3(posX, posY + sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_gun1 = gun1.AddComponent<FixedJoint>();
		fj_gun1.connectedBody = mainEngine.GetComponent<Rigidbody>();
		gun1.transform.parent = PlayerObject.transform;
		gun1.tag = "Player";
		gun1.layer = 8;
		gun1.GetComponent<Gun_3D>().isAttached = true;

		GameObject armor1 = Instantiate(armor, new Vector3(posX - sizeOffset, posY, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor1 = armor1.AddComponent<FixedJoint>();
		fj_armor1.connectedBody = mainEngine.GetComponent<Rigidbody>();
		armor1.transform.parent = PlayerObject.transform;
		armor1.tag = "Player";
		armor1.layer = 8;

		GameObject armor2 = Instantiate(armor, new Vector3(posX + sizeOffset, posY, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor2 = armor2.AddComponent<FixedJoint>();
		fj_armor2.connectedBody = mainEngine.GetComponent<Rigidbody>();
		armor2.transform.parent = PlayerObject.transform;
		armor2.tag = "Player";
		armor2.layer = 8;

		GameObject armor3 = Instantiate(armor, new Vector3(posX, posY - sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor3 = armor3.AddComponent<FixedJoint>();
		fj_armor3.connectedBody = mainEngine.GetComponent<Rigidbody>();
		armor3.transform.parent = PlayerObject.transform;
		armor3.tag = "Player";
		armor3.layer = 8;

		GameObject armor4 = Instantiate(armor, new Vector3(armor3.transform.position.x - sizeOffset, armor3.transform.position.y, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor4_a = armor4.AddComponent<FixedJoint>();
		fj_armor4_a.connectedBody = armor1.GetComponent<Rigidbody>();
		FixedJoint fj_armor4_b = armor4.AddComponent<FixedJoint>();
		fj_armor4_b.connectedBody = armor3.GetComponent<Rigidbody>();
		armor4.transform.parent = PlayerObject.transform;
		armor4.tag = "Player";
		armor4.layer = 8;

		GameObject armor5 = Instantiate(armor, new Vector3(armor3.transform.position.x + sizeOffset, armor3.transform.position.y, z), Quaternion.identity) as GameObject;
		FixedJoint fj_armor5_a = armor5.AddComponent<FixedJoint>();
		fj_armor5_a.connectedBody = armor2.GetComponent<Rigidbody>();
		FixedJoint fj_armor5_b = armor5.AddComponent<FixedJoint>();
		fj_armor5_b.connectedBody = armor3.GetComponent<Rigidbody>();
		armor5.transform.parent = PlayerObject.transform;
		armor5.tag = "Player";
		armor5.layer = 8;

		GameObject gun2 = Instantiate(gun, new Vector3(armor4.transform.position.x - sizeOffset, armor4.transform.position.y, z), Quaternion.identity) as GameObject;
		FixedJoint fj_gun2 = gun2.AddComponent<FixedJoint>();
		fj_gun2.connectedBody = armor4.GetComponent<Rigidbody>();
		gun2.transform.parent = PlayerObject.transform;
		gun2.tag = "Player";
		gun2.layer = 8;
		gun2.GetComponent<Gun_3D>().isAttached = true;

		GameObject gun3 = Instantiate(gun, new Vector3(armor5.transform.position.x + sizeOffset, armor5.transform.position.y, z), Quaternion.identity) as GameObject;
		FixedJoint fj_gun3 = gun3.AddComponent<FixedJoint>();
		fj_gun3.connectedBody = armor5.GetComponent<Rigidbody>();
		gun3.transform.parent = PlayerObject.transform;
		gun3.tag = "Player";
		gun3.layer = 8;
		gun3.GetComponent<Gun_3D>().isAttached = true;

		GameObject booster1 = Instantiate(booster, new Vector3(gun2.transform.position.x, gun2.transform.position.y - sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_boost1 = booster1.AddComponent<FixedJoint>();
		fj_boost1.connectedBody = gun2.GetComponent<Rigidbody>();
		booster1.transform.parent = PlayerObject.transform;
		booster1.tag = "Player";
		booster1.layer = 8;

		GameObject booster2 = Instantiate(booster, new Vector3(armor3.transform.position.x, armor3.transform.position.y - sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_boost2 = booster2.AddComponent<FixedJoint>();
		fj_boost2.connectedBody = armor3.GetComponent<Rigidbody>();
		booster2.transform.parent = PlayerObject.transform;
		booster2.tag = "Player";
		booster2.layer = 8;

		GameObject booster3 = Instantiate(booster, new Vector3(gun3.transform.position.x, gun3.transform.position.y - sizeOffset, z), Quaternion.identity) as GameObject;
		FixedJoint fj_boost3 = booster3.AddComponent<FixedJoint>();
		fj_boost3.connectedBody = gun3.GetComponent<Rigidbody>();
		booster3.transform.parent = PlayerObject.transform;
		booster3.tag = "Player";
		booster3.layer = 8;

		GameController_3D.instance.shipSize = (int)Camera.main.orthographicSize;
	}
}
