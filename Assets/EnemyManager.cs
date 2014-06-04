using UnityEngine;
using System.Collections.Generic;

/**
 *   
 */
public class EnemyManager : MonoBehaviour
{


    public GameObject Enemy;
    public Vector3 StartPosition;
    public float SpaceX;
    public float SpaceY;

    public int EnemyCount = 24;
    public int EnemyMaxRows = 8;

    void Start()
    {
        setObjSize();
        createEnemies();
    }


    void Update()
    {

    }


    private void createEnemies()
    {
        Vector3 pos = StartPosition;
 
        for(int i = 0; i < EnemyMaxRows; i++)
            for(int j = 0; j < EnemyCount / EnemyMaxRows; j++)
            {
                GameObject go = Instantiate(Enemy, pos, Enemy.transform.rotation) as GameObject;
                enemies.Add(go);
                pos.x = StartPosition.x + SpaceX * i;
                pos.y = StartPosition.y - SpaceY * j;
            }
        GameObject go1 = Instantiate(Enemy, pos, Enemy.transform.rotation) as GameObject;
        enemies.Add(go1);
 

    }

    private void setObjSize()
    {
        Vector3 sTmp = Enemy.transform.lossyScale;
       // Debug.Log("Size = " + sTmp);
        objSize = sTmp;
    }

    List<GameObject> enemies = new List<GameObject>();

    public Vector3 EnemySize
    {
        get
        {
            return objSize;
        }
    }

    private Vector3 objSize;


}
