using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy3 : Enemy
{
    public float MoveSpeed = 1.5f;
    public float DistanceF_Y = 1.3f;
	public float DistanceF_X = 7.5f;
   
    public override void Start()
    {
        base.Start();
        generatePoints();
    }

   
    public override void Update()
    {
        followPoints();
    }


    private void followPoints()
    {
        transform.position = Vector2.Lerp(transform.position, pointsAv[currentPoint], Time.deltaTime * MoveSpeed);
        if (isInPoint())
            changePoint();
    }

    private void generatePoints()
    {
        currentPos = transform.position;
		pointsAv[0] = new Vector2(currentPos.x - DistanceF_X, currentPos.y + DistanceF_Y);
		pointsAv[3] = new Vector2(currentPos.x + DistanceF_X, currentPos.y + DistanceF_Y);
		pointsAv[1] = new Vector2(currentPos.x + DistanceF_X, currentPos.y - DistanceF_Y);
		pointsAv[2] = new Vector3(currentPos.x - DistanceF_X, currentPos.y - DistanceF_Y);
    }

    private bool isInPoint()
    {
        return Vector2.Distance(new Vector2(transform.position.x, transform.position.y), pointsAv[currentPoint]) < 0.01f;
    }

    private void changePoint()
    {
        currentPoint++;
        if (currentPoint == 4)
            currentPoint = 0;
    }

    private Vector2[] pointsAv = new Vector2[4];

    private int currentPoint = 0;
}
