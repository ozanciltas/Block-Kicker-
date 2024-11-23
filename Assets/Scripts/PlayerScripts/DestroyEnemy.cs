using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    Transform enemyPos;
    float radius = 20f;
    int enemyLayer;
    string[] enemies = { "red", "blue", "yellow", "green" };
    void Start()
    {

    }
    public void DestroySelectedEnemy(string enem)
    {
        enemyLayer = LayerMask.NameToLayer(enem);
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, radius, 1 << enemyLayer);
        foreach (Collider collider in hitcolliders)
        {
            EnemyHealthChanging escr = collider.GetComponent<EnemyHealthChanging>();
            BigEnemyHealthChanging bscr = collider.GetComponent<BigEnemyHealthChanging>();
            bscr.health = 0;
            escr.health = 0;
        }
    }
}
