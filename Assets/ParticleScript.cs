using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

	private ParticleSystem ps;
	
	void Start () {
		ps = this.GetComponent<ParticleSystem>();
	}

	void Update () {
		if(ps)
		{
			if(!ps.IsAlive())
			{
				Destroy(gameObject);
			}
		}
	}
}