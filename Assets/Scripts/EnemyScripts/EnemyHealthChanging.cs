using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class EnemyHealthChanging : MonoBehaviour
{

    float speed = 1f;
    public bool freezeOn;
    public bool slowOn;

    public ParticleSystem[] particle = new ParticleSystem[4];
    public bool slowBallOn;
    public bool freezeBallOn;
    public TextMeshProUGUI healthCount;
    public float health = 10f;
    public float damage = 1f;
    GameObject player;
    float expValue = 3f;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, speed * Time.deltaTime);

        GameObject levelControl = GameObject.Find("SceneControl");
        BossSpawn bscr = levelControl.GetComponent<BossSpawn>();
        if(health <= 0)
        {
            inDestroy();
            player.GetComponent<LevelUp>().SetExperience(expValue);
            bscr.enemyCount--;
        }
        healthCount.text = health.ToString();
        healthCount.GetComponent<TextMeshProUGUI>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            health = health - damage;
        }
        if(collision.gameObject.tag == "Fireball")
        {
            Debug.Log("Yandý");
            float timer = 5f;
            while (timer >= 0)
            {
                health--;
                timer -= Time.deltaTime;
            }
        }
        if (collision.gameObject.tag == "FreezeBall")
        {
            speed = 0;
        }
        if (collision.gameObject.tag == "Slowball")
        {
            speed -= 0.5f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            health = health - damage;
        }
        if (other.gameObject.tag == "Fireball")
        {
            Debug.Log("Yandý");
            float timer = 5f;
            while (timer >= 0)
            {
                health--;
                timer -= Time.deltaTime;
            }
        }
        if (other.gameObject.tag == "FreezeBall")
        {
            speed = 0;
        }
        if (other.gameObject.tag == "Slowball")
        {
            speed -= 0.5f;
        }
        if (other.gameObject.tag == "OrbitBall")
        {
            health = health - damage * 2;
        }
    }

    void inDestroy()
    {
        int i = 0;
        Color color = gameObject.GetComponent<MeshRenderer>().material.color;
        if (color == Color.red) i = 0;
        if (color == Color.blue) i = 1;
        if (color == Color.yellow) i = 2;
        if (color == Color.green) i = 3;
        Instantiate(particle[i], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
