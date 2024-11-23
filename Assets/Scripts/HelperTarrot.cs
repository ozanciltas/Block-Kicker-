using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperTarrot : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public Transform nearestRedenemy;
    float OverlapRadius = 12f;
    int enemyLayer;
    public Color myred = new Color(255f, 0f, 0f, 255f);
    string[] enemyLayerList = { "EnemyRed", "EnemyBlue", "EnemyGreen" };
    public string enemyType;
    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer(enemyType);
    }
    private void Update()
    {
        if (nearestRedenemy != null)
        {
            var rotation = Quaternion.LookRotation(nearestRedenemy.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, OverlapRadius, 1 << enemyLayer);
        float minimumdistance = Mathf.Infinity;
        foreach (Collider collider in hitcolliders)
        {
            float distance = Vector3.Distance(transform.position, collider.transform.position);
            if (distance < minimumdistance)
            {
                minimumdistance = distance;
                nearestRedenemy = collider.transform;
            }
        }
        if (nearestRedenemy != null)
        {
            var rotation = Quaternion.LookRotation(nearestRedenemy.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }
}
