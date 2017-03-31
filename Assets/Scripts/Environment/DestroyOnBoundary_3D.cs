using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBoundary_3D : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}
}
