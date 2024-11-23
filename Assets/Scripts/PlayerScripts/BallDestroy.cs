using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour
{
    bool pireceOn = false;
    bool bounceON = false;
    PlayerShooting ps;
    GameObject lvlControl;
    GameObject player;
    private void Update()
    {
        player = GameObject.Find("Player");
        ps = GameObject.Find("Cannon").GetComponent<PlayerShooting>();
        lvlControl = GameObject.Find("Canvas");
        PowerUPMenu scr = lvlControl.GetComponent<PowerUPMenu>();
        if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) >= 18)
        {
            this.gameObject.SetActive(false);
        }
        /*
        if (scr.bounceOn)
        {
            bounceON = true;
        }
        if (scr.pierceOn)
        {
            pireceOn = true;
        }
        */
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (!bounceON && !pireceOn && collision.gameObject.tag == "Enemy")
        {
            this.gameObject.SetActive(false);

        }
        if (pireceOn)
        {
            SphereCollider sc = gameObject.GetComponent<SphereCollider>();
            sc.isTrigger = true;
        }
        if(bounceON)
        {
            SphereCollider sc = gameObject.GetComponent<SphereCollider>();
            sc.isTrigger = false;
        }
        
    }
}
