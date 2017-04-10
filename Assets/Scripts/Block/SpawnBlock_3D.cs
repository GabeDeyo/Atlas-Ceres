using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock_3D : MonoBehaviour {

	private GameObject armor;
	private GameObject gun;
	private GameObject booster;

	public List<GameObject> prefabs;

	void Awake() {
		armor = (GameObject)Resources.Load("Block/Armor_3D", typeof(GameObject));
		gun = (GameObject)Resources.Load("Block/Gun_3D", typeof(GameObject));
		booster = (GameObject)Resources.Load("Block/Booster_3D", typeof(GameObject));
	}

	void Start() {
		prefabs.Add(armor);
		prefabs.Add(gun);
		prefabs.Add(booster);
	}
	
	void Update () {
		if (Input.GetKeyDown("return")) {
			InstantiateBlock();
		}
	}

	void InstantiateBlock() {
		GameObject block = Instantiate(prefabs[Random.Range(0, 3)], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		block.tag = "Floater";
		block.layer = 10;

		block.AddComponent<Floater_3D>();
		block.AddComponent<Meld_3D>();
	}
}
