using UnityEngine;
using System.Collections;

public class MiniEnemy : MonoBehaviour
{


	public void Start ()
	{
			
	}

	public void Update ()
	{
		transform.position += new Vector3(0f, -1.5f * Time.deltaTime, 0f);
	}

	public void onBecomeInvisible()
	{
		Destroy(gameObject);
	}

	public void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Bullet")
			Destroy(gameObject);
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Application.LoadLevel("GameOver");
    }
}
