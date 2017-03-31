using UnityEngine;

public class TiledBackground_2D : MonoBehaviour {

	public int textureSizeX = 32;
	public int textureSizeY = 64;
	public bool scaleHorizontally = true;
	public bool scaleVertically = true;

	private PixelPerfectCamera_2D cam;

	void Awake () {

		//float newWidth = !scaleHorizontally ? 1 : Mathf.Ceil (Screen.width / (textureSizeX * PixelPerfectCamera.scale));
		//float newHeight = !scaleVertically ? 1 : Mathf.Ceil (Screen.height / (textureSizeY * PixelPerfectCamera.scale));

		//transform.localScale = new Vector3 (newWidth * textureSizeX, newHeight * textureSizeY, 1);

		//GetComponent<Renderer> ().material.mainTextureScale = new Vector3 (newWidth, newHeight, 1);

		cam = Camera.main.GetComponent<PixelPerfectCamera_2D>();
	}

	void Start(){
		this.gameObject.transform.localScale = new Vector2 (cam.nativeResolution.x, cam.nativeResolution.y);
	}

	/*TODO
	 * Use Scale on Block/Ship Collision
	 * Scale in regards to ShipSize
	*/


	//Used to scale background
	public void Scale(float scale){
		float scaleX = this.gameObject.transform.localScale.x;
		float scaleY = this.gameObject.transform.localScale.y;

		this.gameObject.transform.localScale = new Vector3 (scaleX * scale, scaleY * scale, 1);
	}
}
