using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] bosses;
    public GameObject camera;
    public float enemyCount = 120;
    int a = 0;

    void Update()
    {
        GameObject canvas = GameObject.Find("Canvas");
        LevelUp scr = canvas.GetComponent<LevelUp>();

        if (enemyCount == 0)
        {
            camera.SetActive(true);
            SpawnBoss();
        }
    }
    public void SpawnBoss()
    {
        GameObject canvas = GameObject.Find("Canvas");
        LevelUp scr = canvas.GetComponent<LevelUp>();
        while (a<1)
        {
            Instantiate(bosses[0], new Vector3(0, 1, 35), Quaternion.identity);
            a++;
        }

    }
}
