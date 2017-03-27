﻿using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public bool gameOver = false;
	public float scrollSpeed = -3f;
	public bool shipControl;
	public float blockSize;
	public int shipSize;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
	}

	void Start () {
		
	}
	
	void Update () {
		
	}
}
