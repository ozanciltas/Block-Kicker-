using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowwFllow : MonoBehaviour
{
    float speed = 1;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        speed = 0.3f;
    }
}
