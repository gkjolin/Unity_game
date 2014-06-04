using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float RotateSpeed = 5f;
    public float EmitTime = 5f;
	public int LivePoints = 4;
	public int RemovePointFactor = 1;
	public GameObject MEnemy;
	public GameObject Explostion;

	private int _time = 0;
	private float _totalMorphTime = 100.0f;
	private bool _isDead = false;
	private float _shakeSpeedFactor = 60.0f;

	public Color baseColor;

    void Start()
    {
        originalRotation = transform.rotation;
		destRotation.eulerAngles = new Vector3(0f, 0f, 0f);
        generatePoints();
		baseColor = this.gameObject.renderer.material.color;
    }

    void FixedUpdate(){}
  
    void Update()
    {
		if (_isDead) {
			ShakeBeforeDeath();
			return;
		}

		if (BossState.Immortal == state) {
			this.gameObject.renderer.material.color = Color.Lerp(Color.red, baseColor, _time/_totalMorphTime);
		} else {
			this.gameObject.renderer.material.color = Color.Lerp(baseColor, Color.red, _time/_totalMorphTime);
		}
	
		_time++;

        if (isMoving)
        {
            moveAndFollowPoints();
            state = BossState.Immortal;

		}
        else
        {
            state = BossState.Mortal;
            calculateTime();
			_time = 0;
		}
        if(LivePoints <= 0)
        {
			_isDead = true;

			StartCoroutine(BossDeath());
        }
    }

	void ShakeBeforeDeath() {
		transform.position = new Vector3(transform.position.x + Mathf.Sin(Time.time * _shakeSpeedFactor) * 0.1f,
		                                 transform.position.y+ Mathf.Sin(Time.time * _shakeSpeedFactor) * 0.1f,
		                                 transform.position.z);
	}

	IEnumerator BossDeath() {
		yield return new WaitForSeconds (3.0f);
		Instantiate(Explostion, transform.position, Quaternion.identity);
		yield return new WaitForSeconds (1.0f);
		renderer.enabled = false;
		yield return new WaitForSeconds (1.5f);
		Application.LoadLevel("WinGame");
	}

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Bullet" && state != BossState.Immortal && LivePoints >= 0)
		{
            LivePoints -= RemovePointFactor;
         	if (LivePoints == 0) {
			}
		}
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(2f, 2f, 120f, 20f), "Boss live " + LivePoints);
    }

    enum BossState
    {
        Immortal,
        Mortal
    }

    private void generatePoints()
    {
        pointsAv = new Vector2[10];
        pointsAv[0] = new Vector2(-12f, 5f);
        pointsAv[1] = new Vector2(12f, 5f);
        pointsAv[2] = new Vector2(14f, 3f);
        pointsAv[3] = new Vector2(-14f, 3f);
        pointsAv[4] = new Vector2(10f, 0f);
        pointsAv[5] = new Vector2(-10f, 0f);
        pointsAv[6] = new Vector2(0f, 5f);
        pointsAv[7] = new Vector2(0f, 3f);
        pointsAv[8] = new Vector2(0f, 0f);
        pointsAv[9] = new Vector2(transform.position.x, transform.position.y);
    }

    private void moveAndFollowPoints()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.deltaTime * RotateSpeed);

        transform.position = Vector2.Lerp(transform.position, pointsAv[currentPoint], Time.deltaTime * MoveSpeed);
        if(isInDistance())
        {
            isMoving = false;
            changePoint();
        }
    }

    private bool isInDistance()
    {
        return Vector2.Distance(new Vector2(transform.position.x, transform.position.y), pointsAv[currentPoint]) < 0.1f;
    }

    private void changePoint()
    {
		int randomize = (int)Random.Range(0, pointsAv.Length - 1f);
		if(randomize != currentPoint)
			currentPoint = randomize;
		else
			changePoint();
       
    }

    private void RotateX()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, destRotation, Time.deltaTime * RotateSpeed);
		if(Quaternion.Angle(transform.rotation, destRotation) <= 0.666f)
			state = BossState.Mortal;
    }

    private void calculateTime()
    {
        RotateX();
        accTime += Time.deltaTime;

		emitEnemies();

        if(accTime >= EmitTime)
        {
            accTime = 0f;
            isMoving = true;
			isEnemyWaveEmited = false;
			state = BossState.Immortal;
        }
    }

	private void emitEnemies()
	{
		if(isEnemyWaveEmited == false)
		{
			Vector3 pos = transform.position;
			Instantiate(MEnemy, pos + new Vector3(0f, -1.5f, 0f), Quaternion.identity);
			Instantiate(MEnemy, pos + new Vector3(-1.5f, -.25f, 0f), Quaternion.identity);
			Instantiate(MEnemy, pos + new Vector3(1.5f, -.25f, 0f), Quaternion.identity);

			isEnemyWaveEmited = true;
		}
	}

    private float accTime = 0f;

	private bool isEnemyWaveEmited = false;

    private Vector2[] pointsAv;
    private bool isMoving = true;
    private int currentPoint = 0;
    private Quaternion originalRotation;
    Quaternion destRotation = new Quaternion();
	BossState state = BossState.Mortal;
}
