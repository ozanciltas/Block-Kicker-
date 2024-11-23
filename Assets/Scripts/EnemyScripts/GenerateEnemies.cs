using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject bigEnemyPrefab;

    public GameObject enemyPrefab;
    Color[] color = { Color.red, Color.blue, Color.yellow, Color.green };
    string[] layers = { "EnemyRed", "EnemyBlue", "EnemyYellow","EnemyGreen" };
    int enemyNum;
    float xPos;
    float zPos;
    float enemyCount;
    
    int enemyNumB;
    float xPosB;
    float zPosB;
    float bigEnemyCount;

    void Update()
    {
        Spawn();
        SpawnB();
    }
    void Spawn()
    {
        while (enemyCount < 100)
        {
            enemyNum = Random.Range(0, 4);
            xPos = Random.Range(-60, 60);
            zPos = Random.Range(-60, 60);
            while(xPos < 15 && xPos >-15 && zPos <15 && zPos>-15)
            {
                xPos = Random.Range(-60, 60);
                zPos = Random.Range(-60, 60);
            }
            var enemy = Instantiate(enemyPrefab, new Vector3(xPos, 1, zPos),Quaternion.identity);
            enemy.GetComponent<MeshRenderer>().material.color = color[enemyNum];
            enemy.layer = LayerMask.NameToLayer(layers[enemyNum]);
            enemyCount += 1;
        }

    }
    void SpawnB()
    {
        while (bigEnemyCount < 20)
        {
            enemyNumB = Random.Range(0, 4);
            xPosB = Random.Range(-60, 60);
            zPosB = Random.Range(-60, 60);
            while (xPosB < 20 && xPosB > -20 && zPosB < 20 && zPosB > -20)
            {
                xPosB = Random.Range(-60, 60);
                zPosB = Random.Range(-60, 60);
            }
            var enemyB = Instantiate(bigEnemyPrefab, new Vector3(xPosB, 1, zPosB), Quaternion.identity);
            enemyB.GetComponent<MeshRenderer>().material.color = color[enemyNum];
            enemyB.layer = LayerMask.NameToLayer(layers[enemyNumB]);
            bigEnemyCount += 1;
        }
    }
}
