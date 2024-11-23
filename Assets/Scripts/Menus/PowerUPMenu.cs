using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUPMenu : MonoBehaviour
{
    #region GameObjects
    public GameObject powerUpMenuUI;
    [SerializeField] GameObject player;
    [SerializeField] GameObject orbitcenter;
    [SerializeField] GameObject cannon2;
    [SerializeField] GameObject orbitball;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject[] cannonCountDisplay;
    [SerializeField] GameObject[] orbitCountDisplay;
    
    #endregion

    int cannonCount = 0;
    int orbitCount = 0;
    float[] angles = { 180, 270, 90 };
    float[] orbitAngles = { 0, 180, 90, 270 };
    public bool bounceOn = false;
    public bool pierceOn = false;

    private void Awake()
    {
        bounceOn = false;
        pierceOn = false;
    }
    void Resume()
    {
        powerUpMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void PowerUpMenu()
    {
        powerUpMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    #region BounceBall
    public void BoounceBall()
    {
        bounceOn = true;
        Resume();
    }
    #endregion

    #region AddCannon
    public void AddCannon()
    {
        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y*0, player.transform.eulerAngles.z);
        GameObject newcannon = Instantiate(cannon2,player.transform);
        newcannon.transform.RotateAround(player.transform.position, Vector3.up, angles[cannonCount]);
        newcannon.transform.SetParent(player.transform);
        cannonCountDisplay[cannonCount].SetActive(true);
        cannonCount++;
        Resume();
    }
    #endregion

    #region OrbitBall
    public void OrbitBall()
    {
        orbitcenter.transform.eulerAngles = new Vector3(orbitcenter.transform.eulerAngles.x, orbitcenter.transform.eulerAngles.y*0, orbitcenter.transform.eulerAngles.z);
        GameObject orbitBall = Instantiate(orbitball,orbitcenter.transform);
        orbitBall.transform.RotateAround(orbitcenter.transform.position, Vector3.up, orbitAngles[orbitCount]);
        orbitBall.transform.SetParent(orbitcenter.transform);
        orbitCountDisplay[orbitCount].SetActive(true);
        orbitCount++;
        Resume();
    }
    #endregion

    #region BallPowerUP
    public void BallPowerUp()
    {
        //GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        //EnemyHealthChanging scr = enemy.GetComponent<EnemyHealthChanging>();
        //BigEnemyHealthChanging bscr = enemy.GetComponent<BigEnemyHealthChanging>();
        //scr.damage++;
        //bscr.damage++;
        //Resume();
    }
    #endregion

    #region BallSpeedUP
    public void BallSpeedUP()
    {
        GameObject shoot = GameObject.Find("Cannon");
        PlayerShooting pscr = shoot.GetComponent<PlayerShooting>();
        pscr.fireRate -= 0.2f;
        Resume();
    }
    #endregion

    #region Rage
    public void Rage()
    {
        float timer = 10f;
        GameObject shoot = GameObject.Find("Cannon");
        PlayerShooting pscr = shoot.GetComponent<PlayerShooting>();
        float a = pscr.fireRate;
        float b = pscr.ballSpeed;
        while (timer >=0)
        {
            pscr.fireRate  = 0.1f;
            pscr.ballSpeed = 20f;
            timer -= Time.deltaTime;
        }
        pscr.fireRate = a;
        pscr.ballSpeed =b;
        Resume();
    }
    #endregion

    #region SlowBall
    public void SlowBall()
    {
        GameObject cannon = GameObject.Find("Cannon");
        PlayerShooting pscr = cannon.GetComponent<PlayerShooting>();
        pscr.a = 4;
        Resume();
    }
    #endregion

    #region FreezeBall
    public void FreezeBall()
    {
        GameObject cannon = GameObject.Find("Cannon");
        PlayerShooting pscr = cannon.GetComponent<PlayerShooting>();
        pscr.a = 2;
        Resume();
    }
    #endregion

    #region PierceBall
    public void PierceBall()
    {
        pierceOn = true;
        Resume();
    }
    #endregion

    #region FireBall
    public void FireBall()
    {
        GameObject canon = GameObject.Find("Cannon");
        PlayerShooting pscr = canon.GetComponent<PlayerShooting>();
        pscr.a = 1;
        Resume();
    }
    #endregion

    #region DestroyRed
    public void DestroyRed()
    {
        DestroyEnemy rscr = player.GetComponent<DestroyEnemy>();
        rscr.DestroySelectedEnemy("EnemyRed");
        Resume();
    }
    #endregion

    #region DestroyGreen
    public void DestroyGreen()
    {
        DestroyEnemy rscr = player.GetComponent<DestroyEnemy>();
        rscr.DestroySelectedEnemy("EnemyGreen");
        Resume();
    }
    #endregion

    #region DestroyBlue
    public void DestroyBlue()
    {
        DestroyEnemy rscr = player.GetComponent<DestroyEnemy>();
        rscr.DestroySelectedEnemy("EnemyBlue");
        Resume();
    }
    #endregion

    #region DestroyYellow
    public void DestroyYellow()
    {
        DestroyEnemy rscr = player.GetComponent<DestroyEnemy>();
        rscr.DestroySelectedEnemy("EnemyYellow");
        Resume();
    }
    #endregion

    #region DestroyAll
    public void DestroyAll()
    {
        DestroyAll rscr = player.GetComponent<DestroyAll>();
        Resume();
        rscr.DestroyALL();
    }
    #endregion

    #region DoubleBall
    public void DoubleBall()
    {
        GameObject doubleBall = GameObject.Find("Cannon");
        PlayerShooting pscr = doubleBall.GetComponent<PlayerShooting>();
        pscr.doubleON = true;
        Resume();
    }
    #endregion

    #region DiagonalBall
    public void DiagonalBall()
    {
        GameObject diaball = GameObject.Find("Cannon");
        PlayerShooting pscr = diaball.GetComponent<PlayerShooting>();
        pscr.diagonalOn = true;
    }
    #endregion

    #region Lazer
    public void Lazer()
    {
        GameObject lazer = GameObject.Find("Cannon");
        LazerGun lzr = lazer.GetComponent<LazerGun>();
        lzr.lazerOn = true;
        Resume();
    }
    #endregion

}




