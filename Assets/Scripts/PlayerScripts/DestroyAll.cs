using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{
    Transform enemyPos;
    float radius = 20f;
    int enemyLayer;
    int redLayer;
    int blueLayer;
    int greenLayer;
    int yellowLayer;
    void Start()
    {
        redLayer = LayerMask.NameToLayer("EnemyRed");
        blueLayer = LayerMask.NameToLayer("EnemyBlue");
        greenLayer = LayerMask.NameToLayer("EnemyGreen");
        yellowLayer = LayerMask.NameToLayer("EnemyYellow");
        int redMask = 1 << redLayer;
        int blueMask = 1 << blueLayer;
        int greenMask = 1 << greenLayer;
        int yellowMask = 1 << yellowLayer;
        enemyLayer = redMask | blueMask | greenMask | yellowMask;
    }
    public void DestroyALL()
    {
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, radius, enemyLayer);
        foreach (Collider collider in hitcolliders)
        {
            EnemyHealthChanging escr = collider.GetComponent<EnemyHealthChanging>();
            escr.health = 0;
        }
    }
}
