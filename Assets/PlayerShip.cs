using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour
{

    enum Direction
    {
        LEFT,
        ROGHT
    }

    public float MaxAngle = 40.0f; // maksymalny kąt przechyłu
    public float SpeedAngle = 30.0f;
    public float ShipSpeed = 10.0f;

    public float BackSpeedAngle = 20.0f;

    public GameObject Bullet;
    public GameObject EnemyMng;

    // private Vector3 originalPosition;
    private Quaternion originalOrentationQuaterion;


    void Start()
    {
        // originalPosition = transform.position;
        originalOrentationQuaterion = transform.rotation;
    }

    void Update()
    {
        bool isLeft = Input.GetKey(KeyCode.LeftArrow);
        bool isRight = Input.GetKey(KeyCode.RightArrow);
        bool isSpace = Input.GetButtonDown("Jump");

        if (isLeft)
        {
            moveShip(Direction.LEFT);
        }
        else if (isRight)
        {
            moveShip(Direction.ROGHT);
        }
        else
        {
            backShip();
        }


        if (isSpace)
        {
            Instantiate(Bullet, this.transform.position, Quaternion.identity);
			this.audio.Play();
        }


        proceedEnemyMenager();
    }



    void moveShip(Direction dir)
    {

        float h = Input.GetAxisRaw("Horizontal");
        float xPos = h * ShipSpeed * Time.deltaTime;
        transform.Translate(xPos, 0f, 0f, Space.World);

        float rotFactorY = SpeedAngle * Time.deltaTime * (dir == Direction.LEFT ? -1.0f : 1.0f);
        transform.Rotate(0.0f, rotFactorY, 0.0f);

    }

    void proceedEnemyMenager()
    {
        if (EnemyMng != null)
        {

        }
    }

    private void backShip()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, originalOrentationQuaterion, Time.deltaTime * BackSpeedAngle);

    }

    public void OnTriggerExit(Collider other)
    {
        //if(other.gameObject.tag == "Enemy")
        //{
           // Debug.Log("Kill");
        //}
    }

    void OnCollisionEnter(Collision c)
    {
       // Debug.Log("Collide pl");
    }

}
