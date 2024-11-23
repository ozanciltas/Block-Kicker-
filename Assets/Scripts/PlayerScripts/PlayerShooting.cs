using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public Transform[] ballSpawnPoint;


    public bool doubleON;
    public bool diagonalOn;
    public bool fireBall;
    public bool freezeBall;
    public bool slowBall;
    public int a = 0;
    public float fireRate = 1f;
    float fireRateDelta;
    public float ballSpeed = 10f;

    ObjectPool pool;

    private void Start()
    {
        pool = GameObject.Find("BallPool").GetComponent<ObjectPool>();
    }
    void Update()
    {
        a = 0;
        if (!doubleON && !diagonalOn)
        {
            fireRateDelta -= Time.deltaTime;
            if (fireRateDelta <= 0)
            {
                Shoot();
                fireRateDelta = fireRate;
            }
        }
        if (doubleON && !diagonalOn)
        {
            fireRateDelta -= Time.deltaTime;
            if (fireRateDelta <= 0)
            {
                ShootDouble();
                fireRateDelta = fireRate;
            }
        }
        if(diagonalOn && doubleON)
        {
            fireRateDelta -= Time.deltaTime;
            if (fireRateDelta <= 0)
            {
                ShootDouble();
                ShootDia();
                fireRateDelta = fireRate;
            }
        }
    }
    void Shoot()
    {
        var ball = pool.TakeFromPool();
        ball.gameObject.SetActive(true);
        ball.transform.position = ballSpawnPoint[0].position;
        ball.transform.rotation = ballSpawnPoint[0].rotation;
        ball.GetComponent<Rigidbody>().velocity = ballSpawnPoint[0].forward * ballSpeed;
    }
    void ShootDouble()
    {
        /*
        var ball1 = Instantiate(ballPrefab[a], ballSpawnPoint[1].position, ballSpawnPoint[1].rotation);
        ball1.GetComponent<Rigidbody>().velocity = ballSpawnPoint[1].forward * ballSpeed;
        
        var ball2 = Instantiate(ballPrefab[a], ballSpawnPoint[2].position, ballSpawnPoint[2].rotation);
        ball2.GetComponent<Rigidbody>().velocity = ballSpawnPoint[2].forward * ballSpeed;
        */
    }
    void ShootDia()
    {
        /*
        var ball3 = Instantiate(ballPrefab[a], ballSpawnPoint[3].position, ballSpawnPoint[1].rotation);
        ball3.GetComponent<Rigidbody>().velocity = ballSpawnPoint[3].forward * ballSpeed;

        var ball4 = Instantiate(ballPrefab[a], ballSpawnPoint[4].position, ballSpawnPoint[2].rotation);
        ball4.GetComponent<Rigidbody>().velocity = ballSpawnPoint[4].forward * ballSpeed;
        */
    }
}
