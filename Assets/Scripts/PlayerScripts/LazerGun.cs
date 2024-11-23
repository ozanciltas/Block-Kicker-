using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGun : MonoBehaviour
{
    public GameObject lazerPrefab;
    public Transform lazerSpawnPoint;
    public bool lazerOn;
    float lazerRate =1f;
    public float lazerRateDelta;
    public float lazerSpeed = 50f;

    private void Update()
    {
        if (lazerOn)
        {
            lazerRateDelta -= Time.deltaTime;
            if (lazerRateDelta <=0)
            {
                StartCoroutine(LazerShoot());
                lazerRateDelta = lazerRate;
            }
        }
    }
    IEnumerator LazerShoot()
    {
        var lazer = Instantiate(lazerPrefab, lazerSpawnPoint.position, lazerSpawnPoint.rotation);
        yield return new WaitForSeconds(0.2f);
        Destroy(lazer);
    }


}
