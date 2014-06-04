using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public float Speed = 0.2f;
	public GameObject Explostion;
    public float YKill = -6.25f;

	private bool _isDead = false;

    public uint Count
    {
        get
        {
            return count;
        }
    }

    public virtual void Start()
    {
        count++;
    }

   
    public virtual void Update()
    {
        moveEnemyDown();
        testYKill();
    }


    public virtual void OnTriggerExit(Collider other)
    {
		if (!_isDead){
			_isDead = true;
			StartCoroutine(EnemyDeath());
		}
    }

	IEnumerator EnemyDeath() {
		Instantiate(Explostion, transform.position, Quaternion.identity);
		renderer.enabled = false;
		collider.enabled = false;
		yield return new WaitForSeconds (1.0f);
		Destroy(gameObject);
	}


    public virtual void OnTriggerStart(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Debug.Log("Player");
    }

    protected virtual void testYKill()
    {
        if (transform.position.y < YKill)
			Application.LoadLevel("GameOver");
    }

    protected virtual void moveEnemyDown()
    {

        currentPos = transform.position;
        currentPos.y -= Speed * Time.deltaTime;

        transform.position = currentPos;
    }

    protected static uint count;
    protected Vector3 currentPos;
}
