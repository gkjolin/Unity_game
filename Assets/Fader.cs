using UnityEngine;
using System.Collections;

public class Fader
{
	private static Fader instance;
	private Texture2D texture;

	private float fadeSpeed = 0.2f;
	private int drawDepth = -1000;
	private float alpha = 0.0f;
	private int fadeDir = -1;
	
	public enum Fade{
		None,
		In,
		Out,
	};

	private Fade currentState;

	public static Fader get()
	{
		if (instance == null)
			instance = new Fader();
		return instance;
	}

	private void FadeIn() {
		alpha -= fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		Render();
	}
	
	private void FadeOut() {
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		Render();
	}

	void Render() {
		GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,alpha);
		GUI.depth = drawDepth;		
		Rect screenRect = new Rect(0,0,Screen.width, Screen.height);
		GUI.DrawTexture(screenRect, texture);
	}

	public void Update()
	{
		switch(currentState){
			case Fade.In:
				FadeIn();
				break;
			case Fade.None:
				break;
			case Fade.Out:
				FadeOut();
				break;
		}
	}

	public void setState(Fade newState) {
		currentState = newState;
		OnChangeState();
	}

	private void OnChangeState(){
		switch(currentState){
		case Fade.In:
			setDefaultFadeIn();
			break;
		case Fade.Out:
			setDefaultFadeOut();
			break;
		}
	}
	
	private void setDefaultFadeIn() {
		fadeSpeed = 0.3f;
		alpha = 0.0f;
	}
	private void setDefaultFadeOut() {
		fadeSpeed = 0.2f;
		alpha = 1.0f;
	}

	private Fader() {
		texture = new Texture2D(2, 2, TextureFormat.ARGB32, false);
		texture.SetPixel(0, 0, Color.black);
		texture.SetPixel(1, 0, Color.black);
		texture.SetPixel(0, 1, Color.black);
		texture.SetPixel(1, 1, Color.black);
		texture.Apply();
		setState(Fade.None);
	}
}

