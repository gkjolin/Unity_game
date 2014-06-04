using UnityEngine;
using System.Collections;

public class Frame{
	public IList information;


	public Frame(IList list) {
		information = list;
	}

	public Vector3 GetCoords(string id) {
		IDictionary dict = information[0] as IDictionary;
		if (dict != null) {
			IDictionary gameObj = dict[id] as IDictionary;
			if (gameObj!= null) {
				return new Vector3(float.Parse(gameObj["x"].ToString()), float.Parse(gameObj["y"].ToString()), 0);
			}
		} 
		return new Vector3();
	}
}
