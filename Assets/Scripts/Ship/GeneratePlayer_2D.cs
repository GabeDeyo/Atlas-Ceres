using UnityEngine;
using System.Collections;

public class GeneratePlayer_2D : MonoBehaviour {

	public float startOffset;

	private GameObject engine;
	private GameObject armor;
	private GameObject gun;
	private GameObject booster;

	private float sizeOffset;

	void Awake(){
		engine = (GameObject)Resources.Load ("Block/Engine_2D", typeof(GameObject));
		armor = (GameObject)Resources.Load ("Block/Armor_2D", typeof(GameObject));
		gun = (GameObject)Resources.Load ("Block/Gun_2D", typeof(GameObject));
		booster = (GameObject)Resources.Load ("Block/Booster_2D", typeof(GameObject));

		sizeOffset = engine.GetComponent<BoxCollider2D>().size.x;
	}

	void Start(){
		InstantiatePlayer ();
		GameController_2D.instance.blockSize = sizeOffset;
	}

	void InstantiatePlayer(){
		float floor = Camera.main.orthographicSize;

		GameObject mainEngine = Instantiate (engine, new Vector3 (0, -floor - startOffset, 1), Quaternion.identity) as GameObject;
		float posX = mainEngine.transform.position.x;
		float posY = mainEngine.transform.position.y;
		int z = 1;

		Rigidbody2D rb = mainEngine.AddComponent<Rigidbody2D>();
		rb.gravityScale = 0;
		rb.freezeRotation = true;

		Enter_2D enter = mainEngine.AddComponent<Enter_2D>();
		enter.initialTime = 5;
		enter.slowTime = 3;

		mainEngine.AddComponent<ShipController_2D>();

		mainEngine.name = "Player";
		mainEngine.layer = 8;

		GameObject gun1 = Instantiate (gun, new Vector3 (posX, posY + sizeOffset, z), Quaternion.identity) as GameObject;
		gun1.transform.parent = mainEngine.transform;
		gun1.tag = "Player";
		gun1.layer = 8;
		gun1.GetComponent<Gun_2D>().isAttached = true;

		GameObject armor1 = Instantiate (armor, new Vector3 (posX - sizeOffset, posY, z), Quaternion.identity) as GameObject;
		armor1.transform.parent = mainEngine.transform;
		armor1.tag = "Player";
		armor1.layer = 8;

		GameObject armor2 = Instantiate (armor, new Vector3 (posX + sizeOffset, posY, 1), Quaternion.identity) as GameObject;
		armor2.transform.parent = mainEngine.transform;
		armor2.tag = "Player";
		armor2.layer = 8;

		GameObject armor3 = Instantiate (armor, new Vector3 (posX, posY - sizeOffset, 1), Quaternion.identity) as GameObject;
		armor3.transform.parent = mainEngine.transform;
		armor3.tag = "Player";
		armor3.layer = 8;

		GameObject armor4 = Instantiate (armor, new Vector3 (armor3.transform.position.x - sizeOffset, armor3.transform.position.y, 1), Quaternion.identity) as GameObject;
		armor4.transform.parent = armor3.transform;
		armor4.tag = "Player";
		armor4.layer = 8;

		GameObject gun2 = Instantiate (gun, new Vector3 (armor4.transform.position.x - sizeOffset, armor4.transform.position.y, 1), Quaternion.identity) as GameObject;
		gun2.transform.parent = armor4.transform;
		gun2.tag = "Player";
		gun2.layer = 8;
		gun2.GetComponent<Gun_2D>().isAttached = true;

		GameObject booster1 = Instantiate (booster, new Vector3 (gun2.transform.position.x, armor4.transform.position.y - sizeOffset, 1), Quaternion.identity) as GameObject;
		booster1.transform.parent = gun2.transform;
		booster1.tag = "Player";
		booster1.layer = 8;

		GameObject booster2 = Instantiate (booster, new Vector3 (armor3.transform.position.x, armor3.transform.position.y - sizeOffset, 1), Quaternion.identity) as GameObject;
		booster2.transform.parent = armor3.transform;
		booster2.tag = "Player";
		booster2.layer = 8;

		GameObject armor5 = Instantiate (armor, new Vector3 (armor3.transform.position.x + sizeOffset, armor3.transform.position.y, 1), Quaternion.identity) as GameObject;
		armor5.transform.parent = armor3.transform;
		armor5.tag = "Player";
		armor5.layer = 8;

		GameObject gun3 = Instantiate (gun, new Vector3 (armor5.transform.position.x + sizeOffset, armor5.transform.position.y, 1), Quaternion.identity) as GameObject;
		gun3.transform.parent = armor5.transform;
		gun3.tag = "Player";
		gun3.layer = 8;
		gun3.GetComponent<Gun_2D>().isAttached = true;

		GameObject booster3 = Instantiate (booster, new Vector3 (gun3.transform.position.x, gun3.transform.position.y - sizeOffset, 1), Quaternion.identity) as GameObject;
		booster3.transform.parent = gun3.transform;
		booster3.tag = "Player";
		booster3.layer = 8;

		GameController_2D.instance.shipSize = (int)Camera.main.orthographicSize;
	}
}
