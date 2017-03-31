using UnityEngine;

public class Meld_3D : MonoBehaviour {

	private Expand_3D expand;
	private FixedJoint joint;

	void Awake() {
		//expand = GameObject.Find("EnvironmentManager").GetComponent<Expand_3D>();
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.name == "Player") {
			ContactPoint contact = collision.contacts[0];

			Destroy(gameObject.GetComponent<Rigidbody>());

			if (this.gameObject.GetComponent<Gun_3D>()) {
				this.gameObject.GetComponent<Gun_3D>().isAttached = true;
			}

			transform.parent = collision.transform;
			//gameObject.transform.SetParent(c.collider.transform);

			gameObject.tag = "Player";
			gameObject.layer = 8;

			float posX = gameObject.transform.localPosition.x;
			float posY = gameObject.transform.localPosition.y;
			float posZ = gameObject.transform.localPosition.z;

			gameObject.transform.localPosition = new Vector3(Mathf.RoundToInt(posX), Mathf.RoundToInt(posY), Mathf.RoundToInt(posZ));
			gameObject.transform.localRotation = collision.transform.rotation;

			GameController_3D.instance.shipSize++;
			//expand.timer = 0;
		}
		/*foreach(ContactPoint c in target.contacts) {
			if(c.collider.tag == "Player") {
				Destroy(this.gameObject.GetComponent<Rigidbody2D>());
				joint = this.gameObject.AddComponent<FixedJoint2D>();
				joint.enableCollision = true;
				this.gameObject.transform.localRotation = Quaternion.identity;
				joint.connectedBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
				joint.anchor = new Vector2(Mathf.RoundToInt(joint.anchor.x), Mathf.RoundToInt(joint.anchor.y));
				
				if (this.gameObject.GetComponent<Gun_3D>()) {
					this.gameObject.GetComponent<Gun_3D>().isAttached = true;
				}

				this.gameObject.transform.SetParent(c.collider.transform);

				this.gameObject.tag = "Player";
				this.gameObject.layer = 8;

				float posX = this.gameObject.transform.localPosition.x;
				float posY = this.gameObject.transform.localPosition.y;

				this.gameObject.transform.localPosition = new Vector2(Mathf.RoundToInt(posX), Mathf.RoundToInt(posY));
				this.gameObject.transform.localRotation = Quaternion.identity;
				
				GameController.instance.shipSize++;
				expand.timer = 0;
			}
		}*/
	}
}
