﻿using UnityEngine;

public class Meld_2D : MonoBehaviour {

	private Expand_2D expand;
	private FixedJoint2D joint;

	void Awake() {
		expand = GameObject.Find("EnvironmentManager").GetComponent<Expand_2D>();
	}

	void OnCollisionEnter2D(Collision2D target) {
		foreach(ContactPoint2D c in target.contacts) {
			if(c.collider.tag == "Player") {
				Destroy(this.gameObject.GetComponent<Rigidbody2D>());
				/*joint = this.gameObject.AddComponent<FixedJoint2D>();
				joint.enableCollision = true;
				this.gameObject.transform.localRotation = Quaternion.identity;
				joint.connectedBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
				joint.anchor = new Vector2(Mathf.RoundToInt(joint.anchor.x), Mathf.RoundToInt(joint.anchor.y));*/
				
				if (this.gameObject.GetComponent<Gun_2D>()) {
					this.gameObject.GetComponent<Gun_2D>().isAttached = true;
				}

				this.gameObject.transform.SetParent(c.collider.transform);

				this.gameObject.tag = "Player";
				this.gameObject.layer = 8;

				float posX = this.gameObject.transform.localPosition.x;
				float posY = this.gameObject.transform.localPosition.y;

				this.gameObject.transform.localPosition = new Vector2(Mathf.RoundToInt(posX), Mathf.RoundToInt(posY));
				this.gameObject.transform.localRotation = Quaternion.identity;
				
				GameController_2D.instance.shipSize++;
				expand.timer = 0;
			}
		}
	}
}
