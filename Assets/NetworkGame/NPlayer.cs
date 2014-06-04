using UnityEngine;
using System.Collections;


public class NPlayer {
	public string id { get; set; }

	private GameObject instance;

	private GameObject desiredObject;

	private bool isInstanceExist = false;

	public NPlayer(string id, GameObject desiredObject) {
		this.id = id;
		this.desiredObject = desiredObject;
		//Vector3 pos = new Vector3(0,0,0);
		//this.instance = GameObject.Instantiate(desired, pos, q) as GameObject;
	}

	public void update(Frame f1, Frame f2, float interp) {
		Vector3 c1 = f1.GetCoords(this.id);
		Vector3 c2 = f2.GetCoords(this.id);
		Vector3 pos = (c1 == c2) ? c1 : c1 * interp + (1 - interp) * c2;

		//Debug.Log(c1);
		
		//Debug.Log(interp);
		//Debug.Log(c2);

		if (!this.isInstanceExist) {
			this.isInstanceExist = true;
			this.instance = GameObject.Instantiate(desiredObject, pos, desiredObject.transform.rotation) as GameObject;
		}
		this.instance.transform.position = pos;
	}
}
