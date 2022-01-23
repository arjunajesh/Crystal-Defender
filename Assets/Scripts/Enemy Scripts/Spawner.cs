using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class Spawner : MonoBehaviour
{
    Rigidbody rb;
    public float throwStrength = 10;
    public ParticleSystem deathParticles;
    ParticleSystem theParticles;
    public GameObject gem;
    public float movementSpeed;
    public int scoreAddition = 0;
    public float gemDamage = 0;
    int health;
    public GameObject player;
    Player playerScript;
    public GameObject[] spawnpoints;
    public GameObject minion;
    GameObject spawnedMinion;
    int index = 0;
    float startTime = 0f;
    float timeInterval = 2f;
    private void Start()
    {
        gem = GameObject.Find("Gem");
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        health = GetComponent<EnemyStats>().health;
        rb = GetComponent<Rigidbody>();

        transform.LookAt(gem.transform);

        InvokeRepeating("SpawnMinion", startTime, timeInterval);
    }

    private void FixedUpdate()
    {
        health = GetComponent<EnemyStats>().health;
        transform.position = Vector3.MoveTowards(transform.position, gem.transform.position, movementSpeed * Time.deltaTime);

        if (health <= 0)
        {
            theParticles = Instantiate(deathParticles);
            theParticles.transform.position = transform.position;
            playerScript.score += scoreAddition;
            CameraShaker.Instance.ShakeOnce(1.2f, 3f, .1f, 1f);
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            gem.GetComponent<Gem>().health -= gemDamage;
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
    private void SpawnMinion()
    {
        spawnedMinion = Instantiate(minion);
        spawnedMinion.transform.position = spawnpoints[index].transform.position;
        if (index == 0)
        {
            index = 1;
        }
        else
        {
            index = 0;
        }
    }
}
