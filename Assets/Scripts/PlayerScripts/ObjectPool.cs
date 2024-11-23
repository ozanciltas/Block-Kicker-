using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] ballPrefab;
    static GameObject[] objectPool = new GameObject[40];
    static int front = 0;
    public int rear = -1;
    public void AddToPool(GameObject obj)
    {
        rear++;
        objectPool[rear] = obj;
    }

    public GameObject TakeFromPool()
    {
        GameObject ball = objectPool[front];
        front++;
        if (Poolcount() == 0)
        {
            front = 0;
            rear = objectPool.Length;
        }
        if (Poolcount() == 1)
        {
            objectPool[0] = objectPool[front];
            front = 0;
            rear = objectPool.Length;
        }
        return ball;
    }
    int Poolcount()
    {
        return rear - front;
    }

    private void Awake()
    {
        for (int i = 0; i < objectPool.Length; i++)
        {
            var ball = Instantiate(ballPrefab[0], transform.position, Quaternion.identity);
            AddToPool(ball);
        }
    }


}
