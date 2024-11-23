using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    private void OnTriggerEnter(Collider other)
    {
        inDestroy();
    }
    void inDestroy()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Time.timeScale = 0f;
    }
}
