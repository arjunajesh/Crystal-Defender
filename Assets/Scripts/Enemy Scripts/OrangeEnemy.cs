using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class OrangeEnemy : MonoBehaviour
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
    float gemHealth;
    public GameObject player;
    Player playerScript;


    private void Start()
    {
        gem = GameObject.Find("Gem");
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        gemHealth = gem.GetComponent<Gem>().health;
        health = GetComponent<EnemyStats>().health;
        rb = GetComponent<Rigidbody>();
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
            //gem.gameObject.transform.localScale += new Vector3(-gemDamage, -gemDamage, -gemDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
