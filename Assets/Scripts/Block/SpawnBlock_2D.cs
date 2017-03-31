using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock_2D : MonoBehaviour {

	private GameObject armor;
	private GameObject gun;
	private GameObject booster;

	public List<GameObject> prefabs;

	void Awake() {
		armor = (GameObject)Resources.Load("Block/Armor_2D", typeof(GameObject));
		gun = (GameObject)Resources.Load("Block/Gun_2D", typeof(GameObject));
		booster = (GameObject)Resources.Load("Block/Booster_2D", typeof(GameObject));
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
		GameObject block = Instantiate(prefabs[Random.Range(0, 3)], new Vector3(0, 0, 1), Quaternion.identity) as GameObject;
		block.layer = 10;

		block.AddComponent<Meld_2D>();

		Rigidbody2D rb = block.AddComponent<Rigidbody2D>();
		rb.gravityScale = Random.Range(0.01f, 0.1f);

		rb.AddTorque(Random.Range(-3, 3));
	}
}
