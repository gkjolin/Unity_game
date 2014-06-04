using UnityEngine;
using System.Collections;

public class ScrollTexture : MonoBehaviour {
	// Script taken from:
	// http://answers.unity3d.com/questions/19848/making-textures-scroll-animate-textures.html
	//
	public Vector2 uvAnimationRate = new Vector2( 1.0f, 0.0f );
	public int materialIndex = 0;
	public string textureName = "_MainTex";

	private Vector2 uvOffset = Vector2.zero;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		uvOffset += ( uvAnimationRate * Time.deltaTime );
		if( renderer.enabled ) {
			renderer.materials[ materialIndex ].SetTextureOffset( textureName, uvOffset );
		}
	}
}
