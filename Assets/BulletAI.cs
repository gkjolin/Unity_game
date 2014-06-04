using UnityEngine;
using System.Collections;

public class BulletAI : MonoBehaviour
{

    public delegate void AddPoint();
    public static event AddPoint OnAddPoint;

    //parametry
    public float Speed = 30f;
    
    private Vector3 _target;

 

    void Start()
    {
        _target = transform.position + new Vector3(0f, 20f, 0f);
    }

   

    void Update()
    {
        Vector3 currentPos = transform.position;
        Vector3 newPos = Vector3.MoveTowards(currentPos, _target, Speed * Time.deltaTime);
        transform.position = newPos;
    }

   

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            if (OnAddPoint != null)
                OnAddPoint();
            Destroy(gameObject);
        }
    }

	public void onBecomeInvisible()
	{
		Destroy(gameObject);
	}
}
